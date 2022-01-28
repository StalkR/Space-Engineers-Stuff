/*
 * Based off of whips radar for the lcd stuff, modified to work with weapon core by dude.
 * 
 * version 1.3
 * 
 * NEW: Ships that are targeting you will be colored yellow.
 * 
 * To see the radar screen, name an LCD 'Radar'
 * To see a list of nearby targets, name an LCD 'Target LCD'
 * To have lights and/or sound blocks trigger when an enemy is around, add 'alert' to their name.
 * Will show targets around you up to your current max weapon range. 
 * To adjust the visible range of the radar display, use the 'range ##' (in meters) argument. Default is 10km. (Example argument: range 10000 )
 */


string textPanelName = "Radar";
string referenceName = "Cockpit";

const string INI_SECTION_GENERAL = "General";
const string INI_SHOW_ASTEROIDS = "Show asteroids";
const string INI_RADAR_NAME = "Text surface name tag";
const string INI_REF_NAME = "Optional reference block name";
const string INI_USE_RANGE_OVERRIDE = "Use range override";
const string INI_RANGE_OVERRIDE = "Range override (m)";
const string INI_PROJ_ANGLE = "Projection angle in degrees (0 is flat)";
const string INI_DRAW_QUADRANTS = "Draw quadrants";

const string INI_SECTION_COLORS = "Colors";
const string INI_TITLE_BAR = "Title bar";
const string INI_TEXT = "Text";
const string INI_BACKGROUND = "Background";
const string INI_RADAR_LINES = "Lines";
const string INI_PLANE = "Plane";
const string INI_ENEMY = "Enemy icon";
const string INI_ENEMY_ELEVATION = "Enemy elevation";
const string INI_NEUTRAL = "Neutral icon";
const string INI_NEUTRAL_ELEVATION = "Neutral elevation";
const string INI_FRIENDLY = "Friendly icon";
const string INI_FRIENDLY_ELEVATION = "Friendly elevation";

const string INI_SECTION_TEXT_SURF_PROVIDER = "Text Surface Config";
const string INI_TEXT_SURFACE_TEMPLATE = "Show on screen";

double _biggestGridRadius = 0;
float rangeOverride = 10000;
bool useRangeOverride = true;
bool showAsteroids = false;
bool drawQuadrants = false;

Color titleBarColor = new Color(50, 50, 50, 5);
Color backColor = new Color(0, 0, 0, 255);
Color lineColor = new Color(60, 60, 60, 10);
Color planeColor = new Color(50, 50, 50, 5);
Color enemyIconColor = new Color(150, 0, 0, 255);
Color enemyElevationColor = new Color(75, 0, 0, 100);
Color neutralIconColor = new Color(150, 150, 150, 255);
Color neutralElevationColor = new Color(75, 75, 75, 100);
Color allyIconColor = new Color(0, 150, 0, 255);
Color allyElevationColor = new Color(0, 75, 0, 100);
Color textColor = new Color(100, 100, 100, 100);
Color missileLockColor = new Color(0, 100, 100, 255);

float MaxRange
{
    get
    {
        return rangeOverride;
    }
}

List<IMyShipController> Controllers
{
    get
    {
        return allControllers;
    }
}

float projectionAngle = 50f;

Scheduler scheduler;
RuntimeTracker runtimeTracker;
ScheduledAction grabBlockAction;

Dictionary<long, TargetData> targetDataDict = new Dictionary<long, TargetData>();
List<IMyTerminalBlock> turrets = new List<IMyTerminalBlock>();
List<IMySensorBlock> sensors = new List<IMySensorBlock>();
List<IMyTextSurface> textSurfaces = new List<IMyTextSurface>();
List<IMyShipController> taggedControllers = new List<IMyShipController>();
List<IMyShipController> allControllers = new List<IMyShipController>();
List<IMySoundBlock> soundBlocks = new List<IMySoundBlock>();
List<IMyLightingBlock> warningLights = new List<IMyLightingBlock>();
HashSet<long> myGridIds = new HashSet<long>();
IMyTerminalBlock reference;
IMyShipController lastActiveShipController = null;

const double cycleTime = 1.0 / 60.0;
string lastSetupResult = "";
bool isSetup = false;
bool _clearSpriteCache = false;
readonly RadarSurface radarSurface;
readonly MyIni generalIni = new MyIni();
readonly MyIni textSurfaceIni = new MyIni();
readonly MyCommandLine _commandLine = new MyCommandLine();
WcPbApi wcapi;
bool wcapiActive = false;
Dictionary<MyDetectedEntityInfo, float> wcTargets;
List<MyDetectedEntityInfo> wcObstructions;
static MyDetectedEntityInfo currentTarget;

Program()
{
    ParseCustomDataIni();
    GrabBlocks();
    radarSurface = new RadarSurface(titleBarColor, backColor, lineColor, planeColor, textColor, missileLockColor, projectionAngle, MaxRange, drawQuadrants);

    Runtime.UpdateFrequency = UpdateFrequency.Update1;
    runtimeTracker = new RuntimeTracker(this);

    scheduler = new Scheduler(this);
    grabBlockAction = new ScheduledAction(GrabBlocks, 0.1);
    scheduler.AddScheduledAction(grabBlockAction);
    scheduler.AddScheduledAction(UpdateRadarRange, 1);
    scheduler.AddScheduledAction(PrintDetailedInfo, 1);

    scheduler.AddQueuedAction(GetTurretTargets, cycleTime);
    scheduler.AddQueuedAction(radarSurface.SortContacts, cycleTime);

    float step = 1f / 8f;
    scheduler.AddQueuedAction(() => Draw(0 * step, 1 * step), cycleTime);
    scheduler.AddQueuedAction(() => Draw(1 * step, 2 * step), cycleTime);
    scheduler.AddQueuedAction(() => Draw(2 * step, 3 * step), cycleTime);
    scheduler.AddQueuedAction(() => Draw(3 * step, 4 * step), cycleTime);
    scheduler.AddQueuedAction(() => Draw(4 * step, 5 * step), cycleTime);
    scheduler.AddQueuedAction(() => Draw(5 * step, 6 * step), cycleTime);
    scheduler.AddQueuedAction(() => Draw(6 * step, 7 * step), cycleTime);
    scheduler.AddQueuedAction(() => Draw(7 * step, 8 * step), cycleTime);


    wcapi = new WcPbApi();
}

void Main(string arg, UpdateType updateSource)
{
    runtimeTracker.AddRuntime();

    if (_commandLine.TryParse(arg))
        HandleArguments();

    scheduler.Update();


    runtimeTracker.AddInstructions();
}


void HandleArguments()
{
    int argCount = _commandLine.ArgumentCount;

    if (argCount == 0)
        return;

    if (_commandLine.Argument(0).ToLowerInvariant() == "range")
    {
        if (argCount != 2)
        {
            return;
        }

        float range = 0;
        if (float.TryParse(_commandLine.Argument(1), out range))
        {
            useRangeOverride = true;
            rangeOverride = range;

            UpdateRadarRange();

            generalIni.Clear();
            generalIni.TryParse(Me.CustomData);
            generalIni.Set(INI_SECTION_GENERAL, INI_RANGE_OVERRIDE, rangeOverride);
            generalIni.Set(INI_SECTION_GENERAL, INI_USE_RANGE_OVERRIDE, useRangeOverride);
            Me.CustomData = generalIni.ToString();
        }
        else if (string.Equals(_commandLine.Argument(1), "default"))
        {
            useRangeOverride = false;

            UpdateRadarRange();

            generalIni.Clear();
            generalIni.TryParse(Me.CustomData);
            generalIni.Set(INI_SECTION_GENERAL, INI_USE_RANGE_OVERRIDE, useRangeOverride);
            Me.CustomData = generalIni.ToString();
        }
        return;
    }
}

void Draw(float startProportion, float endProportion)
{
    int start = (int)(startProportion * textSurfaces.Count);
    int end = (int)(endProportion * textSurfaces.Count);

    for (int i = start; i < end; ++i)
    {
        var textSurface = textSurfaces[i];
        radarSurface.DrawRadar(textSurface, _clearSpriteCache);
    }
}

void PrintDetailedInfo()
{
    Echo($"Next refresh in {Math.Max(grabBlockAction.RunInterval - grabBlockAction.TimeSinceLastRun, 0):N0} seconds");
    Echo($"Range: {MaxRange} m");
    Echo($"Turrets: {turrets.Count}");
    Echo($"Sensors: {sensors.Count}");
    Echo($"Text surfaces: {textSurfaces.Count}");
    Echo($"Reference: {reference?.CustomName}");
    Echo($"{lastSetupResult}");
    Echo(runtimeTracker.Write());
}

void UpdateRadarRange()
{
    radarSurface.Range = MaxRange;
}



List<MyDetectedEntityInfo> sensorEntities = new List<MyDetectedEntityInfo>();
void GetSensorTargets()
{
    foreach (var sensor in sensors)
    {
        if (IsClosed(sensor))
            continue;

        sensorEntities.Clear();
        sensor.DetectedEntities(sensorEntities);
        foreach (var target in sensorEntities)
        {
            AddTargetData(target, 0);
        }
    }
}

void AddTargetData(MyDetectedEntityInfo targetInfo, float threat = 0f)
{
    TargetData targetData = new TargetData(targetInfo);
    targetData.Threat = threat;

    targetDataDict[targetInfo.EntityId] = targetData;
}

bool enemyNearby;
void GetTurretTargets()
{
    if (!isSetup)
        return;

    radarSurface.ClearContacts();


    if (!wcapiActive)
    {
        wcapiActive = wcapi.Activate(Me);
    }

    if (wcapiActive)
    {
        wcTargets = new Dictionary<MyDetectedEntityInfo, float>();
        wcapi.GetSortedThreats(Me, wcTargets);
        foreach (var target in wcTargets)
        {
            AddTargetData(target.Key, target.Value);
        }
        wcObstructions = new List<MyDetectedEntityInfo>();
        wcapi.GetObstructions(Me, wcObstructions);
        foreach (var target in wcObstructions)
        {
            if ((target.Type == MyDetectedEntityType.Asteroid && showAsteroids) || (target.Type == MyDetectedEntityType.Planet && showAsteroids) || wcapi.HasGridAi(target.EntityId))
            {
                AddTargetData(target, -1.0f);
            }
        }
    }
    reference = GetControlledShipController(Controllers);
    if (reference == null)
    {
        if (lastActiveShipController != null)
        {
            reference = lastActiveShipController;
        }
        else if (reference == null && Controllers.Count != 0)
        {
            reference = Controllers[0];
        }
        else
        {
            reference = Me;
        }
    }

    if (reference is IMyShipController)
        lastActiveShipController = (IMyShipController)reference;

    MyDetectedEntityInfo? t = wcapi.GetAiFocus(Me.CubeGrid.EntityId);
    currentTarget = default(MyDetectedEntityInfo);
    enemyNearby = false;
    foreach (var kvp in targetDataDict)
    {
        if (kvp.Key == Me.CubeGrid.EntityId)
            continue;

        var targetData = kvp.Value;

        Color targetIconColor = neutralIconColor;
        Color targetElevationColor = neutralElevationColor;
        RadarSurface.Relation relation = RadarSurface.Relation.Neutral;
        switch (targetData.Info.Relationship)
        {
            case MyRelationsBetweenPlayerAndBlock.Enemies:
                targetIconColor = enemyIconColor;
                targetElevationColor = enemyElevationColor;
                relation = RadarSurface.Relation.Hostile;
                enemyNearby = true;
                if (Me.CubeGrid.EntityId == wcapi.GetAiFocus(targetData.Info.EntityId, 0).GetValueOrDefault().EntityId)
                {
                    targetIconColor = Color.Yellow;
                }
                break;

            case MyRelationsBetweenPlayerAndBlock.Owner:
            case MyRelationsBetweenPlayerAndBlock.FactionShare:
            case MyRelationsBetweenPlayerAndBlock.Friends:
            case MyRelationsBetweenPlayerAndBlock.NoOwnership:
                if (targetData.Threat < 0)
                {
                    targetIconColor = allyIconColor;
                    targetElevationColor = allyElevationColor;
                    relation = RadarSurface.Relation.Allied;
                }
                break;
        }

        if (targetData.Info.Type == MyDetectedEntityType.CharacterHuman)
        {
            targetIconColor = Color.Lerp(targetIconColor, Color.Yellow, 0.5f);
            targetElevationColor = Color.Lerp(targetElevationColor, Color.Yellow, 0.5f);
        }

        if (t.HasValue && kvp.Key == t.Value.EntityId)
        {
            currentTarget = t.Value;
            targetData.TargetLock = true;
        }

        targetData.Distance = Vector3D.Distance(targetData.Info.Position, Me.CubeGrid.GetPosition());

        if (Vector3D.DistanceSquared(targetData.Info.Position, reference.GetPosition()) < (MaxRange * MaxRange))
            radarSurface.AddContact(targetData.Info.Position, reference.WorldMatrix, targetData.Info.Type, targetIconColor, targetElevationColor, targetData.Info.Name, relation, targetData.TargetLock, targetData.Distance, targetData.Info.Velocity, targetData.Threat);
    }

    if (enemyNearby)
    {
        if (soundBlocks.Count > 0)
        {
            foreach (var block in soundBlocks)
            {
                if (block != null && !block.Enabled)
                {
                    block.Enabled = true;
                    block.Play();
                }
            }
        }
        if (warningLights.Count > 0)
        {
            foreach (var light in warningLights)
            {
                if (light != null && !light.Enabled)
                {
                    light.Enabled = true;
                }
            }
        }
    }
    else
    {
        if (soundBlocks.Count > 0)
        {
            foreach (var block in soundBlocks)
            {
                if (block != null && block.Enabled)
                {
                    block.Stop();
                    block.Enabled = false;
                }
            }
        }
        if (warningLights.Count > 0)
        {
            foreach (var light in warningLights)
            {
                if (light != null && light.Enabled)
                {
                    light.Enabled = false;
                }
            }
        }
    }


    targetDataDict.Clear();
}

struct TargetData
{
    public MyDetectedEntityInfo Info;
    public bool TargetLock;
    public double Distance;
    public float Threat;

    public TargetData(MyDetectedEntityInfo info, bool targetLock = false, double distance = 0, float threat = 0)
    {
        Info = info;
        TargetLock = targetLock;
        Distance = distance;
        Threat = threat;
    }
}

class RadarSurface
{
    float _range = 0f;
    public float Range
    {
        get
        {
            return _range;
        }
        set
        {
            if (value == _range)
                return;
            _range = value;
        }
    }
    public enum Relation { None = 0, Allied = 1, Neutral = 2, Hostile = 3 }
    public readonly StringBuilder Debug = new StringBuilder();

    string FONT = "Debug";
    const float TITLE_TEXT_SIZE = 1.2f;
    const float HUD_TEXT_SIZE = 0.9f;
    const float RANGE_TEXT_SIZE = 1.0f;
    const float TGT_ELEVATION_LINE_WIDTH = 2f;
    const float QUADRANT_LINE_WIDTH = 2f;
    const float TITLE_BAR_HEIGHT = 40;

    Color _titleBarColor;
    Color _backColor;
    Color _lineColor;
    Color _quadrantLineColor;
    Color _planeColor;
    Color _textColor;
    Color _targetLockColor;
    float _projectionAngleDeg;
    float _radarProjectionCos;
    float _radarProjectionSin;
    bool _drawQuadrants;
    int _allyCount = 0;
    int _hostileCount = 0;
    Vector2 _quadrantLineDirection;

    readonly Vector2 DROP_SHADOW_OFFSET = new Vector2(2, 2);
    readonly Vector2 TGT_ICON_SIZE = new Vector2(10, 10);
    readonly Vector2 SHIP_ICON_SIZE = new Vector2(8, 4);
    List<Output> targetOutput;
    readonly List<TargetInfo> _targetList = new List<TargetInfo>();
    readonly List<TargetInfo> _targetsBelowPlane = new List<TargetInfo>();
    readonly List<TargetInfo> _targetsAbovePlane = new List<TargetInfo>();
    readonly Dictionary<Relation, string> _spriteMap = new Dictionary<Relation, string>()
{
{ Relation.None, "None" },
{ Relation.Allied, "SquareSimple" },
{ Relation.Neutral, "Triangle" },
{ Relation.Hostile, "Circle" },
};

    struct TargetInfo
    {
        public Vector3 Position;
        public Color IconColor;
        public Color ElevationColor;
        public string Icon;
        public bool TargetLock;
        public double Distance;
        public Vector3D Velocity;
        public int ThreatScore;
        public MyDetectedEntityType Type;
        public string Name;
        public bool TargetingMe;
    }

    public RadarSurface(Color titleBarColor, Color backColor, Color lineColor, Color planeColor, Color textColor, Color targetLockColor, float projectionAngleDeg, float range, bool drawQuadrants)
    {
        UpdateFields(titleBarColor, backColor, lineColor, planeColor, textColor, targetLockColor, projectionAngleDeg, range, drawQuadrants);
    }

    public void UpdateFields(Color titleBarColor, Color backColor, Color lineColor, Color planeColor, Color textColor, Color targetLockColor, float projectionAngleDeg, float range, bool drawQuadrants)
    {
        _titleBarColor = titleBarColor;
        _backColor = backColor;
        _lineColor = lineColor;
        _quadrantLineColor = new Color((byte)(lineColor.R / 2), (byte)(lineColor.G / 2), (byte)(lineColor.B / 2), (byte)(lineColor.A / 2));
        _planeColor = planeColor;
        _textColor = textColor;
        _projectionAngleDeg = projectionAngleDeg;
        _drawQuadrants = drawQuadrants;
        _targetLockColor = targetLockColor;
        Range = range;


        var rads = MathHelper.ToRadians(_projectionAngleDeg);
        _radarProjectionCos = (float)Math.Cos(rads);
        _radarProjectionSin = (float)Math.Sin(rads);

        _quadrantLineDirection = new Vector2(0.25f * MathHelper.Sqrt2, 0.25f * MathHelper.Sqrt2 * _radarProjectionCos);
    }

    public void AddContact(Vector3D position, MatrixD worldMatrix, MyDetectedEntityType type, Color iconColor, Color elevationLineColor, string name, Relation relation, bool targetLock, double distance = 0, Vector3D velocity = new Vector3D(), float threat = 0)
    {
        int threatScore = 0;

        if (threat > 0)
            threatScore = 1;
        if (threat >= 0.0625)
            threatScore = 2;
        if (threat >= 0.125)
            threatScore = 3;
        if (threat >= 0.25)
            threatScore = 4;
        if (threat >= 0.5)
            threatScore = 5;
        if (threat >= 1)
            threatScore = 6;
        if (threat >= 2)
            threatScore = 7;
        if (threat >= 3)
            threatScore = 8;
        if (threat >= 4)
            threatScore = 9;
        if (threat >= 5)
            threatScore = 10;

        var transformedDirection = Vector3D.TransformNormal(position - worldMatrix.Translation, Matrix.Transpose(worldMatrix));
        float xOffset = (float)(transformedDirection.X / Range);
        float yOffset = (float)(transformedDirection.Z / Range);
        float zOffset = (float)(transformedDirection.Y / Range);

        string spriteName = "";
        _spriteMap.TryGetValue(relation, out spriteName);

        var targetInfo = new TargetInfo()
        {
            Position = new Vector3(xOffset, yOffset, zOffset),
            ElevationColor = elevationLineColor,
            IconColor = iconColor,
            Icon = spriteName,
            TargetLock = targetLock,
            Distance = distance,
            Velocity = velocity,
            ThreatScore = threatScore,
            Type = type,
            Name = name
        };

        switch (relation)
        {
            case Relation.Allied:
                ++_allyCount;
                break;

            case Relation.Hostile:
                ++_hostileCount;
                break;
        }

        _targetList.Add(targetInfo);
    }

    public void SortContacts()
    {
        _targetsBelowPlane.Clear();
        _targetsAbovePlane.Clear();

        _targetList.Sort((a, b) => (a.Position.Y).CompareTo(b.Position.Y));

        foreach (var target in _targetList)
        {
            if (target.Position.Z >= 0)
                _targetsAbovePlane.Add(target);
            else
                _targetsBelowPlane.Add(target);
        }
    }

    public void ClearContacts()
    {
        _targetList.Clear();
        _targetsAbovePlane.Clear();
        _targetsBelowPlane.Clear();
        _allyCount = 0;
        _hostileCount = 0;
    }

    static void DrawBoxCorners(MySpriteDrawFrame frame, Vector2 boxSize, Vector2 centerPos, float lineLength, float lineWidth, Color color)
    {
        Vector2 horizontalSize = new Vector2(lineLength, lineWidth);
        Vector2 verticalSize = new Vector2(lineWidth, lineLength);

        Vector2 horizontalOffset = 0.5f * horizontalSize;
        Vector2 verticalOffset = 0.5f * verticalSize;

        Vector2 boxHalfSize = 0.5f * boxSize;
        Vector2 boxTopLeft = centerPos - boxHalfSize;
        Vector2 boxBottomRight = centerPos + boxHalfSize;
        Vector2 boxTopRight = centerPos + new Vector2(boxHalfSize.X, -boxHalfSize.Y);
        Vector2 boxBottomLeft = centerPos + new Vector2(-boxHalfSize.X, boxHalfSize.Y);

        MySprite sprite;

        sprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", size: horizontalSize, position: boxTopLeft + horizontalOffset, rotation: 0, color: color);
        frame.Add(sprite);

        sprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", size: verticalSize, position: boxTopLeft + verticalOffset, rotation: 0, color: color);
        frame.Add(sprite);

        sprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", size: horizontalSize, position: boxTopRight + new Vector2(-horizontalOffset.X, horizontalOffset.Y), rotation: 0, color: color);
        frame.Add(sprite);

        sprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", size: verticalSize, position: boxTopRight + new Vector2(-verticalOffset.X, verticalOffset.Y), rotation: 0, color: color);
        frame.Add(sprite);

        sprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", size: horizontalSize, position: boxBottomLeft + new Vector2(horizontalOffset.X, -horizontalOffset.Y), rotation: 0, color: color);
        frame.Add(sprite);

        sprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", size: verticalSize, position: boxBottomLeft + new Vector2(verticalOffset.X, -verticalOffset.Y), rotation: 0, color: color);
        frame.Add(sprite);

        sprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", size: horizontalSize, position: boxBottomRight - horizontalOffset, rotation: 0, color: color);
        frame.Add(sprite);

        sprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", size: verticalSize, position: boxBottomRight - verticalOffset, rotation: 0, color: color);
        frame.Add(sprite);
    }

    public void DrawRadar(IMyTextSurface surface, bool clearSpriteCache)
    {
        surface.ContentType = ContentType.SCRIPT;
        surface.Script = "";

        Vector2 surfaceSize = surface.TextureSize;
        Vector2 screenCenter = surfaceSize * 0.5f;
        Vector2 viewportSize = surface.SurfaceSize;
        Vector2 scale = viewportSize / 512f;
        float minScale = Math.Min(scale.X, scale.Y);
        float sideLength = Math.Min(viewportSize.X, viewportSize.Y - TITLE_BAR_HEIGHT * minScale);

        Vector2 radarCenterPos = screenCenter;
        Vector2 radarPlaneSize = new Vector2(sideLength, sideLength * _radarProjectionCos);

        targetOutput = new List<Output>();
        targetOutput.Add(new Output("----------------------------------------------", Color.Gray));

        using (var frame = surface.DrawFrame())
        {
            if (clearSpriteCache)
            {
                frame.Add(new MySprite());
            }

            MySprite sprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", color: _backColor);
            sprite.Position = screenCenter;
            frame.Add(sprite);

            DrawRadarPlaneBackground(frame, radarCenterPos, radarPlaneSize);

            foreach (var targetInfo in _targetsBelowPlane)
            {
                DrawTargetIcon(frame, radarCenterPos, radarPlaneSize, targetInfo, minScale);
            }

            DrawRadarPlane(frame, viewportSize, screenCenter, radarCenterPos, radarPlaneSize, minScale);

            foreach (var targetInfo in _targetsAbovePlane)
            {
                DrawTargetIcon(frame, radarCenterPos, radarPlaneSize, targetInfo, minScale);
            }

            DrawRadarText(frame, screenCenter, viewportSize, minScale);
        }

        if (targetLCDs != null && targetLCDs.Count > 0)
        {
            foreach (var lcd in targetLCDs)
            {
                var targetFrame = lcd.Key.DrawFrame();
                targetFrame.Add(new MySprite());
                DrawScreen(ref targetFrame, targetOutput, lcd.Value);
                targetFrame.Dispose();
            }
        }
    }

    void DrawRadarText(MySpriteDrawFrame frame, Vector2 screenCenter, Vector2 viewportSize, float scale)
    {
        MySprite sprite;
        float textSize = scale * HUD_TEXT_SIZE;
        Vector2 halfScreenSize = viewportSize * 0.5f;
        Vector2 dropShadowOffset = scale * DROP_SHADOW_OFFSET;

        sprite = MySprite.CreateText($"Hostile: {_hostileCount}", FONT, Color.Black, textSize, TextAlignment.CENTER);
        sprite.Data = $"Enemies: {_hostileCount}";
        sprite.Position = screenCenter + new Vector2(-(halfScreenSize.X * 0.5f) + 10, halfScreenSize.Y - (70 * scale)) + dropShadowOffset;
        frame.Add(sprite);
        sprite.Color = Color.Red;
        sprite.Position -= dropShadowOffset;
        frame.Add(sprite);

        sprite.Data = $"Allies: {_allyCount}";
        sprite.Color = Color.Black;
        sprite.Position = screenCenter + new Vector2((halfScreenSize.X * 0.5f) - 10, halfScreenSize.Y - (70 * scale)) + dropShadowOffset;
        frame.Add(sprite);
        sprite.Color = Color.Lime;
        sprite.Position -= dropShadowOffset;
        frame.Add(sprite);
    }

    void DrawLineQuadrantSymmetry(MySpriteDrawFrame frame, Vector2 center, Vector2 point1, Vector2 point2, float width, Color color)
    {
        DrawLine(frame, center + point1, center + point2, width, color);
        DrawLine(frame, center - point1, center - point2, width, color);
        point1.X *= -1;
        point2.X *= -1;
        DrawLine(frame, center + point1, center + point2, width, color);
        DrawLine(frame, center - point1, center - point2, width, color);
    }

    void DrawLine(MySpriteDrawFrame frame, Vector2 point1, Vector2 point2, float width, Color color)
    {
        Vector2 position = 0.5f * (point1 + point2);
        Vector2 diff = point1 - point2;
        float length = diff.Length();
        if (length > 0)
            diff /= length;

        Vector2 size = new Vector2(length, width);
        float angle = (float)Math.Acos(Vector2.Dot(diff, Vector2.UnitX));
        angle *= Math.Sign(Vector2.Dot(diff, Vector2.UnitY));

        MySprite sprite = MySprite.CreateSprite("SquareSimple", position, size);
        sprite.RotationOrScale = angle;
        sprite.Color = color;
        frame.Add(sprite);
    }

    void DrawRadarPlaneBackground(MySpriteDrawFrame frame, Vector2 screenCenter, Vector2 radarPlaneSize)
    {
        MySprite sprite = new MySprite(SpriteType.TEXTURE, "Circle", size: radarPlaneSize, color: _planeColor);
        sprite.Position = screenCenter;
        frame.Add(sprite);
    }

    void DrawRadarPlane(MySpriteDrawFrame frame, Vector2 viewportSize, Vector2 screenCenter, Vector2 radarScreenCenter, Vector2 radarPlaneSize, float scale)
    {
        MySprite sprite;
        Vector2 halfScreenSize = viewportSize * 0.5f;
        float titleBarHeight = TITLE_BAR_HEIGHT * scale;

        sprite = MySprite.CreateSprite("SquareSimple",
            screenCenter + new Vector2(0f, -halfScreenSize.Y + titleBarHeight * 0.5f),
            new Vector2(viewportSize.X, titleBarHeight));
        sprite.Color = _titleBarColor;
        frame.Add(sprite);

        string title = currentTarget.IsEmpty() ? "No Target" : currentTarget.Name;
        sprite = MySprite.CreateText(title, FONT, _textColor, scale * TITLE_TEXT_SIZE, TextAlignment.CENTER);
        sprite.Position = screenCenter + new Vector2(0, -halfScreenSize.Y + 4.25f * scale);
        frame.Add(sprite);

        sprite = new MySprite(SpriteType.TEXTURE, "Circle", size: radarPlaneSize * 0.8f, color: _lineColor);
        sprite.Position = radarScreenCenter;
        frame.Add(sprite);

        sprite = new MySprite(SpriteType.TEXTURE, "Circle", size: radarPlaneSize, color: _lineColor);
        sprite.Position = radarScreenCenter;
        frame.Add(sprite);

        var iconSize = SHIP_ICON_SIZE * scale;
        sprite = new MySprite(SpriteType.TEXTURE, "Triangle", size: iconSize, color: _lineColor);
        sprite.Position = radarScreenCenter + new Vector2(0f, -0.2f * iconSize.Y);
        frame.Add(sprite);

        Vector2 quadrantLine = radarPlaneSize.X * _quadrantLineDirection;
        if (_drawQuadrants)
        {
            float lineWidth = QUADRANT_LINE_WIDTH * scale;
            DrawLineQuadrantSymmetry(frame, radarScreenCenter, 0.2f * quadrantLine, 1.0f * quadrantLine, lineWidth, _quadrantLineColor);
        }

    }

    void DrawTargetIcon(MySpriteDrawFrame frame, Vector2 screenCenter, Vector2 radarPlaneSize, TargetInfo targetInfo, float scale)
    {
        Vector3 targetPosPixels = targetInfo.Position * new Vector3(1, _radarProjectionCos, _radarProjectionSin) * radarPlaneSize.X * 0.5f;

        Vector2 targetPosPlane = new Vector2(targetPosPixels.X, targetPosPixels.Y);
        Vector2 iconPos = targetPosPlane - targetPosPixels.Z * Vector2.UnitY;

        RoundVector2(ref iconPos);
        RoundVector2(ref targetPosPlane);

        float elevationLineWidth = Math.Max(1f, TGT_ELEVATION_LINE_WIDTH * scale);
        MySprite elevationSprite = new MySprite(SpriteType.TEXTURE, "SquareSimple", color: targetInfo.ElevationColor, size: new Vector2(elevationLineWidth, targetPosPixels.Z));
        elevationSprite.Position = screenCenter + (iconPos + targetPosPlane) * 0.5f;
        RoundVector2(ref elevationSprite.Position);
        RoundVector2(ref elevationSprite.Size);

        Vector2 iconSize = TGT_ICON_SIZE * scale;
        MySprite iconSprite = new MySprite(SpriteType.TEXTURE, targetInfo.Icon, color: targetInfo.IconColor, size: iconSize);
        iconSprite.Position = screenCenter + iconPos;
        RoundVector2(ref iconSprite.Position);
        RoundVector2(ref iconSprite.Size);


        MySprite threatSprite = MySprite.CreateText(targetInfo.ThreatScore.ToString(), color: Color.Black, scale: 0.9f, fontId: "Debug");
        threatSprite.Position = screenCenter + iconPos + new Vector2(20, -10);
        RoundVector2(ref threatSprite.Position);
        RoundVector2(ref threatSprite.Size);

        MySprite iconShadow = iconSprite;
        iconShadow.Color = Color.Black;
        iconShadow.Size += Vector2.One * 2f * (float)Math.Max(1f, Math.Round(scale * 4f));

        iconSize.Y *= _radarProjectionCos;
        MySprite projectedIconSprite = new MySprite(SpriteType.TEXTURE, "Circle", color: targetInfo.ElevationColor, size: iconSize);
        projectedIconSprite.Position = screenCenter + targetPosPlane;
        RoundVector2(ref projectedIconSprite.Position);
        RoundVector2(ref projectedIconSprite.Size);

        bool showProjectedElevation = Math.Abs(iconPos.Y - targetPosPlane.Y) > iconSize.Y;


        Vector2 dropShadowOffset = scale * DROP_SHADOW_OFFSET;
        Vector2 targetHighlight = new Vector2(3, 3);
        if (targetPosPixels.Z >= 0)
        {
            if (showProjectedElevation)
                frame.Add(projectedIconSprite);
            frame.Add(elevationSprite);
            if (targetInfo.TargetLock)
            {
                MySprite iconHighlight = iconShadow;
                iconHighlight.Size += targetHighlight;
                iconHighlight.Color = iconSprite.Color;
                frame.Add(iconHighlight);
            }
            frame.Add(iconShadow);
            frame.Add(iconSprite);
            if (targetInfo.Icon == "Circle")
            {
                frame.Add(threatSprite);
                threatSprite.Color = targetInfo.IconColor;
                threatSprite.Position -= dropShadowOffset;
                frame.Add(threatSprite);
            }
        }
        else
        {
            iconSprite.RotationOrScale = MathHelper.Pi;
            iconShadow.RotationOrScale = MathHelper.Pi;

            frame.Add(elevationSprite);
            if (targetInfo.TargetLock)
            {
                MySprite iconHighlight = iconShadow;
                iconHighlight.Size += targetHighlight;
                iconHighlight.Color = iconSprite.Color;
                frame.Add(iconHighlight);
            }
            frame.Add(iconShadow);
            frame.Add(iconSprite);
            if (showProjectedElevation)
                frame.Add(projectedIconSprite);
            if (targetInfo.Icon == "Circle")
            {
                frame.Add(threatSprite);
                threatSprite.Color = targetInfo.IconColor;
                threatSprite.Position -= dropShadowOffset;
                frame.Add(threatSprite);
            }
        }

        string type = "";
        switch (targetInfo.Type)
        {
            case MyDetectedEntityType.CharacterHuman:
                type = "Suit";
                break;
            case MyDetectedEntityType.LargeGrid:
                type = "LG";
                break;
            case MyDetectedEntityType.SmallGrid:
                type = "SG";
                break;
            case MyDetectedEntityType.Asteroid:
                type = "Ast";
                break;
            case MyDetectedEntityType.Planet:
                type = "Planet";
                break;
            default:
                type = "?";
                break;
        }
        if (targetInfo.TargetLock)
        {
            targetOutput.Insert(0, new Output($"      {targetInfo.Distance:N1}m @ {targetInfo.Velocity.Length():N0}m/s", targetInfo.IconColor));
            targetOutput.Insert(0, new Output($" > [ {targetInfo.ThreatScore:N0} - {type} ] {targetInfo.Name}", targetInfo.IconColor));
        }
        else
        {
            targetOutput.Add(new Output($"   [ {targetInfo.ThreatScore:N0} - {type} ] {targetInfo.Name}", targetInfo.IconColor));
            targetOutput.Add(new Output($"      {targetInfo.Distance:N1}m @ {targetInfo.Velocity.Length():N0}m/s", targetInfo.IconColor));
        }

        if (targetInfo.TargetLock)
        {
            MySprite sprite = MySprite.CreateText($"Target Distance: {targetInfo.Distance:N0}m Speed: {targetInfo.Velocity.Length():N0}", "Debug", targetInfo.IconColor, RANGE_TEXT_SIZE * scale, TextAlignment.CENTER);
            sprite.Position = screenCenter + new Vector2(0, radarPlaneSize.Y * 0.5f + scale * 4f);
            frame.Add(sprite);
        }
    }

    void RoundVector2(ref Vector2? vec)
    {
        if (vec.HasValue)
            vec = new Vector2((float)Math.Round(vec.Value.X), (float)Math.Round(vec.Value.Y));
    }

    void RoundVector2(ref Vector2 vec)
    {
        vec.X = (float)Math.Round(vec.X);
        vec.Y = (float)Math.Round(vec.Y);
    }
}


static Dictionary<IMyTextSurface, RectangleF> targetLCDs = new Dictionary<IMyTextSurface, RectangleF>();
static IMyTextSurface targetLCD;

public struct Output
{
    public string Text;
    public Color Color;

    public Output(string text, Color color)
    {
        Text = text;
        Color = color;
    }
}

public static void DrawScreen(ref MySpriteDrawFrame frame, List<Output> displaytext, RectangleF viewport)
{
    var position = new Vector2(10, viewport.Position.Y + 10);
    MySprite sprite;
    foreach (var item in displaytext)
    {
        sprite = new MySprite()
        {
            Type = SpriteType.TEXT,
            Data = item.Text,
            Position = position,
            RotationOrScale = 1.2f,
            Color = item.Color,
            Alignment = TextAlignment.LEFT,
            FontId = "Debug"
        };
        frame.Add(sprite);
        position += new Vector2(0, 30);
    }
}


void AddTextSurfaces(IMyTerminalBlock block, List<IMyTextSurface> textSurfaces)
{
    var textSurface = block as IMyTextSurface;
    if (textSurface != null)
    {
        textSurfaces.Add(textSurface);
        return;
    }

    var surfaceProvider = block as IMyTextSurfaceProvider;
    if (surfaceProvider == null)
        return;

    textSurfaceIni.Clear();
    bool parsed = textSurfaceIni.TryParse(block.CustomData);

    if (!parsed && !string.IsNullOrWhiteSpace(block.CustomData))
    {
        textSurfaceIni.EndContent = block.CustomData;
    }

    int surfaceCount = surfaceProvider.SurfaceCount;
    for (int i = 0; i < surfaceCount; ++i)
    {
        string iniKey = $"{INI_TEXT_SURFACE_TEMPLATE}, {i}";
        bool display = textSurfaceIni.Get(INI_SECTION_TEXT_SURF_PROVIDER, iniKey).ToBoolean(i == 0 && !(block is IMyProgrammableBlock));
        if (display)
        {
            textSurfaces.Add(surfaceProvider.GetSurface(i));
        }

        textSurfaceIni.Set(INI_SECTION_TEXT_SURF_PROVIDER, iniKey, display);
    }

    string output = textSurfaceIni.ToString();
    if (!string.Equals(output, block.CustomData))
        block.CustomData = output;
}

void WriteCustomDataIni()
{
    generalIni.Set(INI_SECTION_GENERAL, INI_SHOW_ASTEROIDS, showAsteroids);
    generalIni.Set(INI_SECTION_GENERAL, INI_RADAR_NAME, textPanelName);
    generalIni.Set(INI_SECTION_GENERAL, INI_USE_RANGE_OVERRIDE, useRangeOverride);
    generalIni.Set(INI_SECTION_GENERAL, INI_RANGE_OVERRIDE, rangeOverride);
    generalIni.Set(INI_SECTION_GENERAL, INI_PROJ_ANGLE, projectionAngle);
    generalIni.Set(INI_SECTION_GENERAL, INI_DRAW_QUADRANTS, drawQuadrants);
    generalIni.Set(INI_SECTION_GENERAL, INI_REF_NAME, referenceName);

    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_TITLE_BAR, titleBarColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_TEXT, textColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_BACKGROUND, backColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_RADAR_LINES, lineColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_PLANE, planeColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_ENEMY, enemyIconColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_ENEMY_ELEVATION, enemyElevationColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_NEUTRAL, neutralIconColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_NEUTRAL_ELEVATION, neutralElevationColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_FRIENDLY, allyIconColor, generalIni);
    MyIniHelper.SetColor(INI_SECTION_COLORS, INI_FRIENDLY_ELEVATION, allyElevationColor, generalIni);
    generalIni.SetSectionComment(INI_SECTION_COLORS, "Colors are defined with RGBA");

    string output = generalIni.ToString();
    if (!string.Equals(output, Me.CustomData))
        Me.CustomData = output;
}

void ParseCustomDataIni()
{
    generalIni.Clear();

    if (generalIni.TryParse(Me.CustomData))
    {
        showAsteroids = generalIni.Get(INI_SECTION_GENERAL, INI_SHOW_ASTEROIDS).ToBoolean(showAsteroids);
        textPanelName = generalIni.Get(INI_SECTION_GENERAL, INI_RADAR_NAME).ToString(textPanelName);
        referenceName = generalIni.Get(INI_SECTION_GENERAL, INI_REF_NAME).ToString(referenceName);
        useRangeOverride = generalIni.Get(INI_SECTION_GENERAL, INI_USE_RANGE_OVERRIDE).ToBoolean(useRangeOverride);
        rangeOverride = generalIni.Get(INI_SECTION_GENERAL, INI_RANGE_OVERRIDE).ToSingle(rangeOverride);
        projectionAngle = generalIni.Get(INI_SECTION_GENERAL, INI_PROJ_ANGLE).ToSingle(projectionAngle);
        drawQuadrants = generalIni.Get(INI_SECTION_GENERAL, INI_DRAW_QUADRANTS).ToBoolean(drawQuadrants);

        titleBarColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_TITLE_BAR, generalIni, titleBarColor);
        textColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_TEXT, generalIni, textColor);
        backColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_BACKGROUND, generalIni, backColor);
        lineColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_RADAR_LINES, generalIni, lineColor);
        planeColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_PLANE, generalIni, planeColor);
        enemyIconColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_ENEMY, generalIni, enemyIconColor);
        enemyElevationColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_ENEMY_ELEVATION, generalIni, enemyElevationColor);
        neutralIconColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_NEUTRAL, generalIni, neutralIconColor);
        neutralElevationColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_NEUTRAL_ELEVATION, generalIni, neutralElevationColor);
        allyIconColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_FRIENDLY, generalIni, allyIconColor);
        allyElevationColor = MyIniHelper.GetColor(INI_SECTION_COLORS, INI_FRIENDLY_ELEVATION, generalIni, allyElevationColor);
    }
    else if (!string.IsNullOrWhiteSpace(Me.CustomData))
    {
        generalIni.EndContent = Me.CustomData;
    }

    WriteCustomDataIni();

    if (radarSurface != null)
    {
        radarSurface.UpdateFields(titleBarColor, backColor, lineColor, planeColor, textColor, missileLockColor, projectionAngle, MaxRange, drawQuadrants);
    }
}

public static class MyIniHelper
{
public static void SetColor(string sectionName, string itemName, Color color, MyIni ini)
    {

        string colorString = $"{color.R}, {color.G}, {color.B}, {color.A}";

        ini.Set(sectionName, itemName, colorString);
    }

public static Color GetColor(string sectionName, string itemName, MyIni ini, Color? defaultChar = null)
    {
        string rgbString = ini.Get(sectionName, itemName).ToString("null");
        string[] rgbSplit = rgbString.Split(',');

        int r = 0;
        int g = 0;
        int b = 0;
        int a = 0;
        if (rgbSplit.Length != 4)
        {
            if (defaultChar.HasValue)
                return defaultChar.Value;
            else
                return Color.Transparent;
        }

        int.TryParse(rgbSplit[0].Trim(), out r);
        int.TryParse(rgbSplit[1].Trim(), out g);
        int.TryParse(rgbSplit[2].Trim(), out b);
        bool hasAlpha = int.TryParse(rgbSplit[3].Trim(), out a);
        if (!hasAlpha)
            a = 255;

        r = MathHelper.Clamp(r, 0, 255);
        g = MathHelper.Clamp(g, 0, 255);
        b = MathHelper.Clamp(b, 0, 255);
        a = MathHelper.Clamp(a, 0, 255);

        return new Color(r, g, b, a);
    }
}


IMyShipController GetControlledShipController(List<IMyShipController> SCs)
{
    foreach (IMyShipController thisController in SCs)
    {
        if (IsClosed(thisController))
            continue;

        if (thisController.IsUnderControl && thisController.CanControlShip)
            return thisController;
    }

    return null;
}

public static bool IsClosed(IMyTerminalBlock block)
{
    return block.WorldMatrix == MatrixD.Identity;
}

public static bool StringContains(string source, string toCheck, StringComparison comp = StringComparison.OrdinalIgnoreCase)
{
    return source?.IndexOf(toCheck, comp) >= 0;
}

bool PopulateLists(IMyTerminalBlock block)
{
    if (!block.IsSameConstructAs(Me))
        return false;

    if (StringContains(block.CustomName, textPanelName))
    {
        AddTextSurfaces(block, textSurfaces);
    }

    if (block.CustomName.Contains("Target LCD"))
    {
        targetLCD = block as IMyTextSurface;
        if (targetLCD != null)
        {
            targetLCD.ContentType = ContentType.SCRIPT;
            targetLCD.ScriptBackgroundColor = Color.Black;
            targetLCDs[block as IMyTextSurface] = new RectangleF((targetLCD.TextureSize - targetLCD.SurfaceSize) / 2f, targetLCD.SurfaceSize);
            return false;
        }
    }

    if (block is IMySoundBlock && block.CustomName.ToLower().Contains("alert"))
    {
        soundBlocks.Add(block as IMySoundBlock);
        return false;
    }

    if (block is IMyLightingBlock && block.CustomName.ToLower().Contains("alert"))
    {
        warningLights.Add(block as IMyLightingBlock);
        return false;
    }

    if (wcapi.HasCoreWeapon(block))
    {
        turrets.Add(block);
        return false;
    }

    var controller = block as IMyShipController;
    if (controller != null)
    {
        allControllers.Add(controller);
        if (StringContains(block.CustomName, referenceName))
            taggedControllers.Add(controller);
        return false;
    }

    var sensor = block as IMySensorBlock;
    if (sensor != null)
    {
        sensors.Add(sensor);
        return false;
    }

    return false;
}

void GrabBlocks()
{
    if (!wcapiActive)
    {
        try
        {
            wcapiActive = wcapi.Activate(Me);
        }
        catch
        {
            wcapiActive = false;
            return;
        }
    }

    _clearSpriteCache = !_clearSpriteCache;

    myGridIds.Clear();
    sensors.Clear();
    turrets.Clear();
    allControllers.Clear();
    taggedControllers.Clear();
    textSurfaces.Clear();
    targetLCDs.Clear();

    GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(null, PopulateLists);

    StringBuilder sb = new StringBuilder();

    if (turrets.Count == 0)
        sb.AppendLine($"No turrets found. Radar will not function without a weapon core turret on your grid.");

    if (!wcapiActive)
        sb.AppendLine($"ERROR: WC API NOT ACTIVATED");

    if (textSurfaces.Count == 0)
        sb.AppendLine($"No text panels or text surface providers with name tag '{textPanelName}' were found.");

    if (allControllers.Count == 0)
        sb.AppendLine($"No ship controllers were found. Using orientation of this block...");
    else
    {
        if (taggedControllers.Count == 0)
            sb.AppendLine($"No ship controllers named '{referenceName}' were found. Using all available ship controllers. (This is NOT an error!)");
        else
            sb.AppendLine($"One or more ship controllers with name tag '{referenceName}' were found. Using these to orient the radar.");
    }

    lastSetupResult = sb.ToString();

    if (textSurfaces.Count == 0)
        isSetup = false;
    else
    {
        isSetup = true;
        ParseCustomDataIni();
    }
}

public class RuntimeTracker
{
    public int Capacity { get; set; }
    public double Sensitivity { get; set; }
    public double MaxRuntime { get; private set; }
    public double MaxInstructions { get; private set; }
    public double AverageRuntime { get; private set; }
    public double AverageInstructions { get; private set; }
    public double LastRuntime { get; private set; }
    public double LastInstructions { get; private set; }

    readonly Queue<double> _runtimes = new Queue<double>();
    readonly Queue<double> _instructions = new Queue<double>();
    readonly StringBuilder _sb = new StringBuilder();
    readonly int _instructionLimit;
    readonly Program _program;
    const double MS_PER_TICK = 16.6666;

    public RuntimeTracker(Program program, int capacity = 100, double sensitivity = 0.005)
    {
        _program = program;
        Capacity = capacity;
        Sensitivity = sensitivity;
        _instructionLimit = _program.Runtime.MaxInstructionCount;
    }

    public void AddRuntime()
    {
        double runtime = _program.Runtime.LastRunTimeMs;
        LastRuntime = runtime;
        AverageRuntime += (Sensitivity * runtime);
        int roundedTicksSinceLastRuntime = (int)Math.Round(_program.Runtime.TimeSinceLastRun.TotalMilliseconds / MS_PER_TICK);
        if (roundedTicksSinceLastRuntime == 1)
        {
            AverageRuntime *= (1 - Sensitivity);
        }
        else if (roundedTicksSinceLastRuntime > 1)
        {
            AverageRuntime *= Math.Pow((1 - Sensitivity), roundedTicksSinceLastRuntime);
        }

        _runtimes.Enqueue(runtime);
        if (_runtimes.Count == Capacity)
        {
            _runtimes.Dequeue();
        }

        MaxRuntime = _runtimes.Max();
    }

    public void AddInstructions()
    {
        double instructions = _program.Runtime.CurrentInstructionCount;
        LastInstructions = instructions;
        AverageInstructions = Sensitivity * (instructions - AverageInstructions) + AverageInstructions;

        _instructions.Enqueue(instructions);
        if (_instructions.Count == Capacity)
        {
            _instructions.Dequeue();
        }

        MaxInstructions = _instructions.Max();
    }

    public string Write()
    {
        _sb.Clear();
        _sb.AppendLine("General Runtime Info");
        _sb.AppendLine($"  Avg instructions: {AverageInstructions:n2}");
        _sb.AppendLine($"  Last instructions: {LastInstructions:n0}");
        _sb.AppendLine($"  Max instructions: {MaxInstructions:n0}");
        _sb.AppendLine($"  Avg complexity: {MaxInstructions / _instructionLimit:0.000}%");
        _sb.AppendLine($"  Avg runtime: {AverageRuntime:n4} ms");
        _sb.AppendLine($"  Last runtime: {LastRuntime:n4} ms");
        _sb.AppendLine($"  Max runtime: {MaxRuntime:n4} ms");
        return _sb.ToString();
    }
}

public class Scheduler
{
    readonly List<ScheduledAction> _scheduledActions = new List<ScheduledAction>();
    readonly List<ScheduledAction> _actionsToDispose = new List<ScheduledAction>();
    Queue<ScheduledAction> _queuedActions = new Queue<ScheduledAction>();
    const double runtimeToRealtime = (1.0 / 60.0) / 0.0166666;
    private readonly Program _program;
    private ScheduledAction _currentlyQueuedAction = null;

public Scheduler(Program program)
    {
        _program = program;
    }

public void Update()
    {
        double deltaTime = Math.Max(0, _program.Runtime.TimeSinceLastRun.TotalSeconds * runtimeToRealtime);

        _actionsToDispose.Clear();
        foreach (ScheduledAction action in _scheduledActions)
        {
            action.Update(deltaTime);
            if (action.JustRan && action.DisposeAfterRun)
            {
                _actionsToDispose.Add(action);
            }
        }

        _scheduledActions.RemoveAll((x) => _actionsToDispose.Contains(x));

        if (_currentlyQueuedAction == null)
        {
            if (_queuedActions.Count != 0)
                _currentlyQueuedAction = _queuedActions.Dequeue();
        }

        if (_currentlyQueuedAction != null)
        {
            _currentlyQueuedAction.Update(deltaTime);
            if (_currentlyQueuedAction.JustRan)
            {
                if (!_currentlyQueuedAction.DisposeAfterRun)
                    _queuedActions.Enqueue(_currentlyQueuedAction);

                _currentlyQueuedAction = null;
            }
        }
    }

public void AddScheduledAction(Action action, double updateFrequency, bool disposeAfterRun = false)
    {
        ScheduledAction scheduledAction = new ScheduledAction(action, updateFrequency, disposeAfterRun);
        _scheduledActions.Add(scheduledAction);
    }

public void AddScheduledAction(ScheduledAction scheduledAction)
    {
        _scheduledActions.Add(scheduledAction);
    }

public void AddQueuedAction(Action action, double updateInterval, bool disposeAfterRun = false)
    {
        if (updateInterval <= 0)
        {
            updateInterval = 0.001;
        }
        ScheduledAction scheduledAction = new ScheduledAction(action, 1.0 / updateInterval, disposeAfterRun);
        _queuedActions.Enqueue(scheduledAction);
    }

public void AddQueuedAction(ScheduledAction scheduledAction)
    {
        _queuedActions.Enqueue(scheduledAction);
    }

public void RemoveRunningAction()
    {
        foreach (ScheduledAction action in _scheduledActions)
        {
            if (action.Running)
            {
                _actionsToDispose.Add(action);
                return;
            }
        }
    }

public void AddScheduledActionSafe(Action action, double updateFrequency, bool disposeAfterRun = false)
    {
        ScheduledAction scheduledAction = new ScheduledAction(action, updateFrequency, disposeAfterRun);
        ScheduledAction queueAddition = new ScheduledAction(delegate { AddScheduledAction(scheduledAction); }, 0.001, true);
        AddQueuedAction(queueAddition);
    }

public void AddScheduledActionSafe(ScheduledAction scheduledAction)
    {
        ScheduledAction queueAddition = new ScheduledAction(delegate { AddScheduledAction(scheduledAction); }, 0.001, true);
        AddQueuedAction(queueAddition);
    }
}

public class ScheduledAction
{
    public bool JustRan { get; private set; } = false;
    public bool DisposeAfterRun { get; private set; } = false;
    public double TimeSinceLastRun { get; private set; } = 0;
    public readonly double RunInterval;
    public bool Running { get; private set; } = false;

    private readonly double _runFrequency;
    private readonly Action _action;
    protected bool _justRun = false;

public ScheduledAction(Action action, double runFrequency, bool removeAfterRun = false)
    {
        _action = action;
        _runFrequency = runFrequency;
        RunInterval = 1.0 / _runFrequency;
        DisposeAfterRun = removeAfterRun;
    }

    public virtual void Update(double deltaTime)
    {
        TimeSinceLastRun += deltaTime;

        if (TimeSinceLastRun >= RunInterval)
        {
            Running = true;
            _action.Invoke();
            TimeSinceLastRun = 0;

            Running = false;
            JustRan = true;
        }
        else
        {
            JustRan = false;
        }
    }
}

}
public class WcPbApi
{
    private Action<ICollection<MyDefinitionId>> _getCoreWeapons;
    private Action<ICollection<MyDefinitionId>> _getCoreStaticLaunchers;
    private Action<ICollection<MyDefinitionId>> _getCoreTurrets;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, IDictionary<string, int>, bool> _getBlockWeaponMap;
    private Func<long, MyTuple<bool, int, int>> _getProjectilesLockedOn;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, IDictionary<MyDetectedEntityInfo, float>> _getSortedThreats;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>> _getObstructions;
    private Func<long, int, MyDetectedEntityInfo> _getAiFocus;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, long, int, bool> _setAiFocus;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, MyDetectedEntityInfo> _getWeaponTarget;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, long, int> _setWeaponTarget;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, bool, int> _fireWeaponOnce;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, bool, bool, int> _toggleWeaponFire;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, bool, bool, bool> _isWeaponReadyToFire;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, float> _getMaxWeaponRange;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, ICollection<string>, int, bool> _getTurretTargetTypes;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, ICollection<string>, int> _setTurretTargetTypes;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, float> _setBlockTrackingRange;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, long, int, bool> _isTargetAligned;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, long, int, MyTuple<bool, VRageMath.Vector3D?>> _isTargetAlignedExtended;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, long, int, bool> _canShootTarget;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, long, int, VRageMath.Vector3D?> _getPredictedTargetPos;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, float> _getHeatLevel;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, float> _currentPowerConsumption;
    private Func<MyDefinitionId, float> _getMaxPower;
    private Func<long, bool> _hasGridAi;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, bool> _hasCoreWeapon;
    private Func<long, float> _getOptimalDps;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, string> _getActiveAmmo;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, string> _setActiveAmmo;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, Action<long, int, ulong, long, VRageMath.Vector3D, bool>> _monitorProjectile;
    private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, Action<long, int, ulong, long, VRageMath.Vector3D, bool>> _unMonitorProjectile;
    private Func<ulong, MyTuple<VRageMath.Vector3D, VRageMath.Vector3D, float, float, long, string>> _getProjectileState;
    private Func<long, float> _getConstructEffectiveDps;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, long> _getPlayerController;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, Matrix> _getWeaponAzimuthMatrix;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, Matrix> _getWeaponElevationMatrix;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, long, bool, bool, bool> _isTargetValid;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, int, MyTuple<VRageMath.Vector3D, VRageMath.Vector3D>> _getWeaponScope;
    private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock, MyTuple<bool, bool>> _isInRange;

    public bool Activate(Sandbox.ModAPI.Ingame.IMyTerminalBlock pbBlock)
    {
        var dict = pbBlock.GetProperty("WcPbAPI")?.As<Dictionary<string, Delegate>>().GetValue(pbBlock);
        if (dict == null) throw new Exception("WcPbAPI failed to activate");
        return ApiAssign(dict);
    }

    public bool ApiAssign(IReadOnlyDictionary<string, Delegate> delegates)
    {
        if (delegates == null)
            return false;

        AssignMethod(delegates, "GetCoreWeapons", ref _getCoreWeapons);
        AssignMethod(delegates, "GetCoreStaticLaunchers", ref _getCoreStaticLaunchers);
        AssignMethod(delegates, "GetCoreTurrets", ref _getCoreTurrets);
        AssignMethod(delegates, "GetBlockWeaponMap", ref _getBlockWeaponMap);
        AssignMethod(delegates, "GetProjectilesLockedOn", ref _getProjectilesLockedOn);
        AssignMethod(delegates, "GetSortedThreats", ref _getSortedThreats);
        AssignMethod(delegates, "GetObstructions", ref _getObstructions);
        AssignMethod(delegates, "GetAiFocus", ref _getAiFocus);
        AssignMethod(delegates, "SetAiFocus", ref _setAiFocus);
        AssignMethod(delegates, "GetWeaponTarget", ref _getWeaponTarget);
        AssignMethod(delegates, "SetWeaponTarget", ref _setWeaponTarget);
        AssignMethod(delegates, "FireWeaponOnce", ref _fireWeaponOnce);
        AssignMethod(delegates, "ToggleWeaponFire", ref _toggleWeaponFire);
        AssignMethod(delegates, "IsWeaponReadyToFire", ref _isWeaponReadyToFire);
        AssignMethod(delegates, "GetMaxWeaponRange", ref _getMaxWeaponRange);
        AssignMethod(delegates, "GetTurretTargetTypes", ref _getTurretTargetTypes);
        AssignMethod(delegates, "SetTurretTargetTypes", ref _setTurretTargetTypes);
        AssignMethod(delegates, "SetBlockTrackingRange", ref _setBlockTrackingRange);
        AssignMethod(delegates, "IsTargetAligned", ref _isTargetAligned);
        AssignMethod(delegates, "IsTargetAlignedExtended", ref _isTargetAlignedExtended);
        AssignMethod(delegates, "CanShootTarget", ref _canShootTarget);
        AssignMethod(delegates, "GetPredictedTargetPosition", ref _getPredictedTargetPos);
        AssignMethod(delegates, "GetHeatLevel", ref _getHeatLevel);
        AssignMethod(delegates, "GetCurrentPower", ref _currentPowerConsumption);
        AssignMethod(delegates, "GetMaxPower", ref _getMaxPower);
        AssignMethod(delegates, "HasGridAi", ref _hasGridAi);
        AssignMethod(delegates, "HasCoreWeapon", ref _hasCoreWeapon);
        AssignMethod(delegates, "GetOptimalDps", ref _getOptimalDps);
        AssignMethod(delegates, "GetActiveAmmo", ref _getActiveAmmo);
        AssignMethod(delegates, "SetActiveAmmo", ref _setActiveAmmo);
        AssignMethod(delegates, "MonitorProjectile", ref _monitorProjectile);
        AssignMethod(delegates, "UnMonitorProjectile", ref _unMonitorProjectile);
        AssignMethod(delegates, "GetProjectileState", ref _getProjectileState);
        AssignMethod(delegates, "GetConstructEffectiveDps", ref _getConstructEffectiveDps);
        AssignMethod(delegates, "GetPlayerController", ref _getPlayerController);
        AssignMethod(delegates, "GetWeaponAzimuthMatrix", ref _getWeaponAzimuthMatrix);
        AssignMethod(delegates, "GetWeaponElevationMatrix", ref _getWeaponElevationMatrix);
        AssignMethod(delegates, "IsTargetValid", ref _isTargetValid);
        AssignMethod(delegates, "GetWeaponScope", ref _getWeaponScope);
        AssignMethod(delegates, "IsInRange", ref _isInRange);
        return true;
    }

    private void AssignMethod<T>(IReadOnlyDictionary<string, Delegate> delegates, string name, ref T field) where T : class
    {
        if (delegates == null)
        {
            field = null;
            return;
        }

        Delegate del;
        if (!delegates.TryGetValue(name, out del))
            throw new Exception($"{GetType().Name} Couldnt find {name} delegate of type {typeof(T)}");

        field = del as T;
        if (field == null)
            throw new Exception(
                $"{GetType().Name} Delegate {name} is not type {typeof(T)} instead its {del.GetType()}");
    }

    public void GetAllCoreWeapons(ICollection<MyDefinitionId> collection) => _getCoreWeapons?.Invoke(collection);

    public void GetAllCoreStaticLaunchers(ICollection<MyDefinitionId> collection) =>
        _getCoreStaticLaunchers?.Invoke(collection);

    public void GetAllCoreTurrets(ICollection<MyDefinitionId> collection) => _getCoreTurrets?.Invoke(collection);

    public bool GetBlockWeaponMap(Sandbox.ModAPI.Ingame.IMyTerminalBlock weaponBlock, IDictionary<string, int> collection) =>
        _getBlockWeaponMap?.Invoke(weaponBlock, collection) ?? false;

    public MyTuple<bool, int, int> GetProjectilesLockedOn(long victim) =>
        _getProjectilesLockedOn?.Invoke(victim) ?? new MyTuple<bool, int, int>();

    public void GetSortedThreats(Sandbox.ModAPI.Ingame.IMyTerminalBlock pBlock, IDictionary<MyDetectedEntityInfo, float> collection) =>
        _getSortedThreats?.Invoke(pBlock, collection);
    public void GetObstructions(Sandbox.ModAPI.Ingame.IMyTerminalBlock pBlock, ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo> collection) =>
        _getObstructions?.Invoke(pBlock, collection);
    public MyDetectedEntityInfo? GetAiFocus(long shooter, int priority = 0) => _getAiFocus?.Invoke(shooter, priority);

    public bool SetAiFocus(Sandbox.ModAPI.Ingame.IMyTerminalBlock pBlock, long target, int priority = 0) =>
        _setAiFocus?.Invoke(pBlock, target, priority) ?? false;

    public MyDetectedEntityInfo? GetWeaponTarget(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId = 0) =>
        _getWeaponTarget?.Invoke(weapon, weaponId);

    public void SetWeaponTarget(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, long target, int weaponId = 0) =>
        _setWeaponTarget?.Invoke(weapon, target, weaponId);

    public void FireWeaponOnce(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, bool allWeapons = true, int weaponId = 0) =>
        _fireWeaponOnce?.Invoke(weapon, allWeapons, weaponId);

    public void ToggleWeaponFire(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, bool on, bool allWeapons, int weaponId = 0) =>
        _toggleWeaponFire?.Invoke(weapon, on, allWeapons, weaponId);

    public bool IsWeaponReadyToFire(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId = 0, bool anyWeaponReady = true,
        bool shootReady = false) =>
        _isWeaponReadyToFire?.Invoke(weapon, weaponId, anyWeaponReady, shootReady) ?? false;

    public float GetMaxWeaponRange(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId) =>
        _getMaxWeaponRange?.Invoke(weapon, weaponId) ?? 0f;

    public bool GetTurretTargetTypes(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, IList<string> collection, int weaponId = 0) =>
        _getTurretTargetTypes?.Invoke(weapon, collection, weaponId) ?? false;

    public void SetTurretTargetTypes(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, IList<string> collection, int weaponId = 0) =>
        _setTurretTargetTypes?.Invoke(weapon, collection, weaponId);

    public void SetBlockTrackingRange(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, float range) =>
        _setBlockTrackingRange?.Invoke(weapon, range);

    public bool IsTargetAligned(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, long targetEnt, int weaponId) =>
        _isTargetAligned?.Invoke(weapon, targetEnt, weaponId) ?? false;

    public MyTuple<bool, Vector3D?> IsTargetAlignedExtended(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, long targetEnt, int weaponId) =>
        _isTargetAlignedExtended?.Invoke(weapon, targetEnt, weaponId) ?? new MyTuple<bool, VRageMath.Vector3D?>();

    public bool CanShootTarget(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, long targetEnt, int weaponId) =>
        _canShootTarget?.Invoke(weapon, targetEnt, weaponId) ?? false;

    public VRageMath.Vector3D? GetPredictedTargetPosition(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, long targetEnt, int weaponId) =>
        _getPredictedTargetPos?.Invoke(weapon, targetEnt, weaponId) ?? null;

    public float GetHeatLevel(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon) => _getHeatLevel?.Invoke(weapon) ?? 0f;
    public float GetCurrentPower(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon) => _currentPowerConsumption?.Invoke(weapon) ?? 0f;
    public float GetMaxPower(MyDefinitionId weaponDef) => _getMaxPower?.Invoke(weaponDef) ?? 0f;
    public bool HasGridAi(long entity) => _hasGridAi?.Invoke(entity) ?? false;
    public bool HasCoreWeapon(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon) => _hasCoreWeapon?.Invoke(weapon) ?? false;
    public float GetOptimalDps(long entity) => _getOptimalDps?.Invoke(entity) ?? 0f;

    public string GetActiveAmmo(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId) =>
        _getActiveAmmo?.Invoke(weapon, weaponId) ?? null;

    public void SetActiveAmmo(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId, string ammoType) =>
        _setActiveAmmo?.Invoke(weapon, weaponId, ammoType);

    public void MonitorProjectileCallback(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId, Action<long, int, ulong, long, VRageMath.Vector3D, bool> action) =>
        _monitorProjectile?.Invoke(weapon, weaponId, action);

    public void UnMonitorProjectileCallback(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId, Action<long, int, ulong, long, VRageMath.Vector3D, bool> action) =>
        _unMonitorProjectile?.Invoke(weapon, weaponId, action);

    public MyTuple<VRageMath.Vector3D, VRageMath.Vector3D, float, float, long, string> GetProjectileState(ulong projectileId) =>
        _getProjectileState?.Invoke(projectileId) ?? new MyTuple<VRageMath.Vector3D, VRageMath.Vector3D, float, float, long, string>();

    public float GetConstructEffectiveDps(long entity) => _getConstructEffectiveDps?.Invoke(entity) ?? 0f;

    public long GetPlayerController(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon) => _getPlayerController?.Invoke(weapon) ?? -1;

    public Matrix GetWeaponAzimuthMatrix(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId) =>
        _getWeaponAzimuthMatrix?.Invoke(weapon, weaponId) ?? Matrix.Zero;

    public Matrix GetWeaponElevationMatrix(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId) =>
        _getWeaponElevationMatrix?.Invoke(weapon, weaponId) ?? Matrix.Zero;

    public bool IsTargetValid(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, long targetId, bool onlyThreats, bool checkRelations) =>
        _isTargetValid?.Invoke(weapon, targetId, onlyThreats, checkRelations) ?? false;

    public MyTuple<VRageMath.Vector3D, VRageMath.Vector3D> GetWeaponScope(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon, int weaponId) =>
        _getWeaponScope?.Invoke(weapon, weaponId) ?? new MyTuple<VRageMath.Vector3D, VRageMath.Vector3D>();
    public MyTuple<bool, bool> IsInRange(Sandbox.ModAPI.Ingame.IMyTerminalBlock block) =>
        _isInRange?.Invoke(block) ?? new MyTuple<bool, bool>();