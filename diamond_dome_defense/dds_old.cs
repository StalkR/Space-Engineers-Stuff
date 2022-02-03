/*
 * R e a d m e
 * -----------
 * 
 * In this file you can include any instructions or other comments you want to have injected onto the 
 * top of your final script. You can safely delete this file if you do not want any such comments.
 */
class GeneralSettings{public Program Context;public WcPbApi WCAPI;public int η=600;public int ζ=45;public int ε=3600;
public double δ=5000;public int γ=30;public int MaxDesignatorUpdatesPerTick=1;public float ι=1;public int α=15;public bool ί=
true;public int ή=45;public bool έ=true;public int ά=2;public int Ϋ=3;public int Ϊ=60;public bool Ω=true;public double ΰ=12;
public int κ=15;public double σ=3000;public int ύ=15;public int ϋ=3;public int ϊ=15;public int ω=90;public int ψ=2;public int
χ=15;public int φ=60;public double υ=5;public double ό=2;public double τ=4;public bool ς=true;public double ρ=12;public
double π=36;public double ο=2000;public double ξ=0.5;public double ν=0.75;public double μ=800;public int λ=60;public int Ψ=600
;public int Χ=300;public int ͱ=600;public int Ώ=15;public double Ύ=60;public double Ό=0.995;public bool Ί=true;public
bool RotorUseLimitSnap=false;public float Έ=1f;public float Ά=60f;public float ΐ=60f;public float ͽ=50f;public float ͻ=60f;
public int ͺ=90;public int ͷ=300;public double Ͷ=88;public double ʹ=79;public int ͳ=30;public int Ͳ=120;public bool ͼ=true;
public bool Β=false;public float Λ=0f;public bool Φ=false;public int Τ=500;}const double Σ=400;const double Ρ=0;const double Π
=400;const double Ο=800;const double Ξ=0;const double Ν=0;const bool Υ=false;const bool Μ=true;const double Κ=100;const
double Ι=600;const double Θ=200;const double Η=800;const double Ζ=4;const double Ε=1;const bool Δ=true;const bool Α=true;class
Γ{public Į ώ=new Į(Σ,Ρ,Π,Ο,Ξ,Ν,Υ,Μ);public Į Њ=new Į(Κ,Ι,Θ,Η,Ζ,Ε,Δ,Α);}const string Ј="5.6(GV7 WC)";const string Ї=
"Diamond Dome";const string І="DDS";const string Ѕ="AGM";const string DESIGNATOR_GRP_TAG="DDS Designator";const string Ѓ="DDS Camera";
const string Ђ="DDS Aiming";const string Љ="DDS Door";const string Ё="DDS Display";const string Ͽ="DDS Turret";const string Ͼ
="Azimuth";const string Ͻ="Elevation";const string ϼ="Aiming";const string ϻ="Reload";const string Ϻ="Forward";const
string Ϲ="Status";const string Ѐ="Alert";const string ϸ="AIM";const string Ћ="DDS Missile";const string О="DDS Torpedo";const
string Н="[CGE]";const string М="FIRE";const string Л="LARGEST";const string К="BIG";const string Й="EXTEND";const string И=
"TRACK";const string З="RELEASE";const string Ж="SET";const string Е="CENTER";const string Д="OFFSET";const string Г="RANDOM";
const string В="RANGE";const string Б="INCRANGE";const string А="DECRANGE";const string Џ="CYCLEOFFSET";const string Ў=
"TOGGLE";const string Ѝ="ENABLE";const string Ќ="DISABLE";const string Ϸ="AUTOLAUNCH";const string ϡ="AUTOLAUNCH_ON";const
string Ϗ="AUTOLAUNCH_OFF";const string ϟ="DEBUGMODE";const double Ϟ=0.707;const int ϝ=7;const int Ϝ=30;const int ϛ=240;const
int Ϛ=120;const double ϙ=0.75;const int Ϡ=60;const double Ϙ=0.005;const int ϖ=(int)(1/Ϙ);const double ϕ=1.0/60.0;const int
ϔ=60;const UpdateType ϓ=UpdateType.Terminal|UpdateType.Trigger|UpdateType.Script;const string ϒ="IGCMSG_TK_IF";const
string ϑ="IGCMSG_TR_TK";const string ϐ="IGCMSG_TR_DL";const string ϗ="IGCMSG_TR_SW";const string Ϣ="CGE_MSG_TR_DL";const
string ϫ="SIMJ";const float ϵ=0.032f;Color ϳ=Color.White;Color ϲ=new Color(40,5,100);Color ϱ=new Color(245,230,255);Color ϰ=
new Color(40,15,5);Color ϯ=Color.White;Color Ϯ=new Color(0,0,0);Color ϭ=new Color(50,50,50);Color ϴ=new Color(255,255,255);
Color Ϭ=new Color(100,100,0);Color Ϫ=Color.White;Color ϩ=Color.Green;Color Ϩ=Color.White;Color ϧ=Color.DarkOrchid;Color Ϧ=
Color.White;Color ϥ=new Color(0,0,90);char[]Ϥ=new char[]{':'};char[]ϣ=new char[]{'\u2014','\\','|','/','\u2014','\\','|','/'}
;IComparer<ő>Ͱ=new ж();Random ı=new Random();List<IMyTerminalBlock>ɰ=new List<IMyTerminalBlock>(0);StringBuilder ǟ=new
StringBuilder();StringBuilder debug=new StringBuilder();int ʏ=0;GeneralSettings gs;Dictionary<MyDetectedEntityInfo,float>
WCThreatsScratchpad=new Dictionary<MyDetectedEntityInfo,float>();Γ ʎ;IMyRemoteControl ʍ;List<U>ʌ;RoundRobin<U>ʋ;RoundRobin<U>ʐ;List<
IMyTextSurface>ʊ;int ʈ=1;int ʇ=0;int ʆ=0;List<Designator>designators;RoundRobin<Designator>designatorTargetRR;RoundRobin<Designator>
designatorOperationRR;int ʂ=-10000;List<IMyCameraBlock>ʉ;Ş ʑ;int ʚ;а targetManager;ђ ʢ;SortedDictionary<double,ő>ʡ;double ʠ=0;int ʟ;bool ʞ=
false;int assignmentState=0;List<IMyProgrammableBlock>ʜ;List<IMyProgrammableBlock>ʣ;List<ŀ>ʛ;Dictionary<string,ŀ>ʙ;byte[]ʘ=
new byte[8];long[]ʗ=new long[1];int ʖ=0;Ƴ ʕ;IEnumerator<int>ʔ;IMyBroadcastListener ʓ;IMyBroadcastListener ʒ;Queue<f>ʁ;Queue
<ő>ʀ;int ɟ=0;bool ɬ=false;double ɫ=100;double ɪ=0;int ɩ=0;int ɨ=0;long ɧ=0;bool ɦ=true;Ǩ ɭ;bool debugMode;int ɣ=0;int
clock=0;int ɢ=0;bool ɡ=false;Program(){Runtime.UpdateFrequency=UpdateFrequency.Update1;ɭ=new Ǩ(Runtime,ϖ,Ϙ);gs=new
GeneralSettings();ʎ=new Γ();gs.Context=this;gs.WCAPI=new WcPbApi();if(!gs.WCAPI.Activate(Me))gs.WCAPI=null;}void Main(string ɠ,
UpdateType ɤ){if(!ɡ){if(!InitLoop()){return;}ʟ=-100000;assignmentState=0;ɦ=true;debugMode=false;ɭ.ǋ();clock=-1;ɡ=true;return;}ɭ.Ǒ(
);if(debugMode)ɭ.ǥ("InterGridComms");if(ɠ.Length>0){if(ɠ.Equals(ϑ)){ѱ();}else{if((ɤ&ϓ)!=0){Ѽ(ɠ);}}}if(debugMode)ɭ.ǣ(
"InterGridComms");ɧ+=Runtime.TimeSinceLastRun.Ticks;if((ɤ&UpdateType.Update1)==0||ɧ==0){return;}ɧ=0;clock++;if(!ɦ){if(clock%Ϡ==0){ō();}
return;}if(debugMode)ɭ.ǥ("AutoMissileLaunch");if(clock>=ʖ){Ѵ();}if(debugMode)ɭ.ǣ("AutoMissileLaunch");if(debugMode)ɭ.ǥ(
"MissileReload");if(gs.Χ>0&&clock%gs.Χ==0){Ѳ();}if(debugMode)ɭ.ǣ("MissileReload");if(debugMode)ɭ.ǥ("ManualAimReload");if(gs.η>0&&clock%
gs.η==0){ReloadMainBlocks();}if(debugMode)ɭ.ǣ("ManualAimReload");if(debugMode)ɭ.ǥ("ManualRaycast");ʭ();if(debugMode)ɭ.ǣ(
"ManualRaycast");if(debugMode)ɭ.ǥ("Designator");UpdateDesignatorTargets();if(debugMode)ɭ.ǣ("Designator");if(debugMode)ɭ.ǥ("Allies");ҕ()
;if(debugMode)ɭ.ǣ("Allies");if(targetManager.ћ()>0){ʞ=true;if(debugMode)ɭ.ǥ("RaycastTracking");if(clock>=ʚ){ʶ();}if(
debugMode)ɭ.ǣ("RaycastTracking");if(debugMode)ɭ.ǥ("AssignTargets");if(clock%gs.ψ==0){қ();}if(debugMode)ɭ.ǣ("AssignTargets");if(
debugMode)ɭ.ǥ("PDCAimFireReload");ѳ();if(debugMode)ɭ.ǣ("PDCAimFireReload");}else if(ʞ){ʞ=false;foreach(U ɯ in ʌ){ɯ.ø=null;ɯ.
ReleaseWeapons();ɯ.ȫ();}assignmentState=0;}if(debugMode)ɭ.ǥ("TransmitIGCMessages");if(targetManager.ћ()>0||ʁ.Count()>0){ӌ();}Ӈ();if(
debugMode)ɭ.ǣ("TransmitIGCMessages");if(clock%gs.ͳ==0){Ү();}if(clock%Ϡ==0){ō();}ɭ.ǡ();}void ɷ(){try{ő ɿ;IMyTerminalBlock ɽ=(ʑ.Î.
Count>0?ʑ.Î[0]:(IMyTerminalBlock)Me);MyDetectedEntityInfo ɼ=new MyDetectedEntityInfo(9801,ϫ,MyDetectedEntityType.LargeGrid,ɽ.
WorldMatrix.Translation+(ɽ.WorldMatrix.Forward*0.1),ɽ.WorldMatrix,Vector3D.Zero,MyRelationsBetweenPlayerAndBlock.Enemies,ɽ.
WorldAABB.Inflate(100),1);targetManager.UpdateTarget(ref ɼ,1,out ɿ);ѱ();Ѽ(ϫ);Ѵ();ӄ(ɿ,false,true);һ(ʣ,ɿ,э.ь,null,false,true);
double ɻ=gs.δ;gs.δ=0.1f;ʛ=new List<ŀ>();ʛ.Add(new ŀ("AIM0",Me,null,null));ʭ();gs.δ=ɻ;ʛ=null;ʶ();қ();ѳ();ʶ();қ();ѳ();
targetManager.і();targetManager.ј();ʞ=false;foreach(U ɯ in ʌ){ɯ.ø=null;ɯ.ReleaseWeapons();ɯ.ȫ();}assignmentState=0;ʁ.Clear();ʀ.Clear(
);ӌ();ӌ();ʁ.Clear();ʀ.Clear();ɬ=false;ɟ=0;}catch(Exception){}}bool InitLoop(){if(ɢ==0){ɮ();List<IMyRemoteControl>ɹ=new
List<IMyRemoteControl>(0);GridTerminalSystem.GetBlocksOfType(ɹ,(Ƌ)=>{if(ʍ==null){ʍ=Ƌ;}return false;});if(ʍ!=null){float ɾ=ʍ.
SpeedLimit;ʍ.SpeedLimit=float.MaxValue;ɫ=ʍ.SpeedLimit;ʍ.SpeedLimit=ɾ;}if(gs.ͼ){List<IMyTerminalBlock>ɸ=new List<IMyTerminalBlock>(
);GridTerminalSystem.GetBlocksOfType(ɸ,(Ƌ)=>{return(Ƌ is IMyMechanicalConnectionBlock||Ƌ is IMyShipConnector);});List<ƶ>ɶ
=new List<ƶ>();foreach(IMyTerminalBlock ɵ in ɸ){if(ɵ is IMyMechanicalConnectionBlock){IMyMechanicalConnectionBlock ɴ=ɵ as
IMyMechanicalConnectionBlock;if(ɴ.Top!=null){ɶ.Add(new ƶ(ɴ.Top.CubeGrid,ɴ.Top.Position));}}else{IMyShipConnector ɳ=ɵ as IMyShipConnector;if(ɳ!=null
&&ɳ.OtherConnector!=null){ɶ.Add(new ƶ(ɳ.OtherConnector.CubeGrid,ɳ.OtherConnector.Position));}}}if(gs.Β){ƴ ɲ=new ƴ();ʔ=ɲ.Ǉ(
new ƶ(Me.CubeGrid,Me.Position),ɶ,gs.Λ,gs.Τ);ʕ=ɲ;ɢ=1;}else{Ɵ ɱ=new Ɵ(new ƶ(Me.CubeGrid,Me.Position),ɶ,gs.Λ,Me);ʕ=ɱ;ɢ=2;}}
else{ʕ=null;}ʑ=new Ş(new List<IMyCameraBlock>(0));targetManager=new а();ʢ=new ђ();ʡ=new SortedDictionary<double,ő>();
ReloadMainBlocks();Ѳ();ʁ=new Queue<f>();ʀ=new Queue<ő>();gs.δ=Math.Min(Math.Max(gs.δ,1000),100000);ʓ=IGC.RegisterBroadcastListener(ϑ);ʒ=
IGC.RegisterBroadcastListener(ϒ);ɪ=Me.CubeGrid.WorldAABB.HalfExtents.Length();ɷ();}if(ɢ==1){if(ʔ.MoveNext()){Echo(
"--- Creating Occlusion Checker ---\nBlocks Processed:"+ʔ.Current);return false;}else{Echo("--- Occlusion Checker Created ---");ʔ.Dispose();ʔ=null;ɢ=2;}}return true;}void ɮ(){
int ʥ=Me.CustomData.GetHashCode();if(ʏ==0||ʏ!=ʥ){ʏ=ʥ;MyIni ʳ=new MyIni();if(ʳ.TryParse(Me.CustomData)){if(ʳ.ContainsSection
(І)){gs.η=ʳ.Get(І,"MainBlocksReloadTicks").ToInt32(gs.η);gs.ζ=ʳ.Get(І,"TargetTracksTransmitIntervalTicks").ToInt32(gs.ζ);
gs.ε=ʳ.Get(І,"ManualAimBroadcastDurationTicks").ToInt32(gs.ε);gs.δ=ʳ.Get(І,"ManualAimRaycastDistance").ToDouble(gs.δ);gs.γ
=ʳ.Get(І,"ManualAimRaycastRefreshInterval").ToInt32(gs.γ);gs.MaxDesignatorUpdatesPerTick=ʳ.Get(І,
"MaxDesignatorUpdatesPerTick").ToInt32(gs.MaxDesignatorUpdatesPerTick);gs.ι=ʳ.Get(І,"MaxPDCUpdatesPerTick").ToSingle(gs.ι);gs.α=ʳ.Get(І,
"MinPDCRefreshRate").ToInt32(gs.α);gs.ί=ʳ.Get(І,"UseDesignatorReset").ToBoolean(gs.ί);gs.ή=ʳ.Get(І,"DesignatorResetInterval").ToInt32(gs.ή)
;gs.έ=ʳ.Get(І,"UseRangeSweeper").ToBoolean(gs.έ);gs.Ϋ=ʳ.Get(І,"RangeSweeperPerTick").ToInt32(gs.Ϋ);gs.ά=ʳ.Get(І,
"RangeSweeperInterval").ToInt32(gs.ά);gs.Ϊ=ʳ.Get(І,"TargetFoundHoldTicks").ToInt32(gs.Ϊ);gs.Ω=ʳ.Get(І,"UsePDCSpray").ToBoolean(gs.Ω);gs.ΰ=ʳ.
Get(І,"PDCSprayMinTargetSize").ToDouble(gs.ΰ);gs.σ=ʳ.Get(І,"MaxRaycastTrackingDistance").ToDouble(gs.σ);gs.ύ=ʳ.Get(І,
"RaycastTargetRefreshTicks").ToInt32(gs.ύ);gs.ϋ=Math.Max(ʳ.Get(І,"RaycastGlobalRefreshTicks").ToInt32(gs.ϋ),1);gs.ϊ=ʳ.Get(І,
"PriorityMinRefreshTicks").ToInt32(gs.ϊ);gs.ω=ʳ.Get(І,"PriorityMaxRefreshTicks").ToInt32(gs.ω);gs.ψ=Math.Max(ʳ.Get(І,"priorityGlobalRefreshTicks"
).ToInt32(gs.ψ),1);gs.χ=ʳ.Get(І,"TargetSlippedTicks").ToInt32(gs.χ);gs.φ=ʳ.Get(І,"TargetLostTicks").ToInt32(gs.φ);gs.κ=ʳ.
Get(І,"RandomOffsetProbeInterval").ToInt32(gs.κ);gs.υ=ʳ.Get(І,"RaycastExtensionDistance").ToDouble(gs.υ);gs.ό=ʳ.Get(І,
"MinTargetSizeEngage").ToDouble(gs.ό);gs.τ=ʳ.Get(І,"MinTargetSizePriority").ToDouble(gs.τ);gs.ς=ʳ.Get(І,"AutoMissileLaunch").ToBoolean(gs.ς);
gs.ρ=ʳ.Get(І,"MissileMinTargetSize").ToDouble(gs.ρ);gs.π=ʳ.Get(І,"MissileCountPerSize").ToDouble(gs.π);gs.ο=ʳ.Get(І,
"MaxMissileLaunchDistance").ToDouble(gs.ο);gs.ξ=ʳ.Get(І,"MissileOffsetRadiusFactor").ToDouble(gs.ξ);gs.ν=ʳ.Get(І,"MissileOffsetProbability").
ToDouble(gs.ν);gs.λ=ʳ.Get(І,"MissileStaggerWaitTicks").ToInt32(gs.λ);gs.Ψ=ʳ.Get(І,"MissileReassignIntervalTicks").ToInt32(gs.Ψ);
gs.Χ=ʳ.Get(І,"MissilePBGridReloadTicks").ToInt32(gs.Χ);gs.ͱ=ʳ.Get(І,"MissileTransmitDurationTicks").ToInt32(gs.ͱ);gs.Ώ=ʳ.
Get(І,"MissileTransmitIntervalTicks").ToInt32(gs.Ώ);gs.Ύ=ʳ.Get(І,"MissileLaunchSpeedLimit").ToDouble(gs.Ύ);gs.Ό=ʳ.Get(І,
"PDCFireDotLimit").ToDouble(gs.Ό);gs.Ί=ʳ.Get(І,"ConstantFireMode").ToBoolean(gs.Ί);gs.RotorUseLimitSnap=ʳ.Get(І,"RotorUseLimitSnap").
ToBoolean(gs.RotorUseLimitSnap);gs.Έ=ʳ.Get(І,"RotorCtrlDeltaGain").ToSingle(gs.Έ);gs.ͺ=ʳ.Get(І,"ReloadCheckTicks").ToInt32(gs.ͺ);
gs.ͷ=ʳ.Get(І,"ReloadedCooldownTicks").ToInt32(gs.ͷ);gs.Ͷ=ʳ.Get(І,"ReloadMaxAngle").ToDouble(gs.Ͷ);gs.ʹ=ʳ.Get(І,
"ReloadLockStateAngle").ToDouble(gs.ʹ);gs.ͳ=Math.Max(ʳ.Get(І,"DisplaysRefreshInterval").ToInt32(gs.ͳ),1);gs.Ͳ=ʳ.Get(І,"AllyTrackLostTicks").
ToInt32(gs.Ͳ);gs.ͼ=ʳ.Get(І,"CheckSelfOcclusion").ToBoolean(gs.ͼ);gs.Β=ʳ.Get(І,"UseAABBOcclusionChecker").ToBoolean(gs.Β);gs.Λ=ʳ
.Get(І,"OcclusionExtraClearance").ToSingle(gs.Λ);gs.Φ=ʳ.Get(І,"UseFourPointOcclusion").ToBoolean(gs.Φ);gs.Τ=ʳ.Get(І,
"OcclusionCheckerInitBlockLimit").ToInt32(gs.Τ);}}}}void ReloadMainBlocks(){CompileDesignators();ˌ();ː();ʱ();ʧ();}void CompileDesignators(){List<
IMyLargeTurretBase>turrets;GetBlocksFromGroups(out turrets,DESIGNATOR_GRP_TAG);if(turrets==null){turrets=new List<IMyLargeTurretBase>(0);}
List<Designator>newDesignators=new List<Designator>(turrets.Count);foreach(IMyLargeTurretBase İ in turrets){newDesignators.
Add(new Designator(İ));}designators=newDesignators;designatorTargetRR=new RoundRobin<Designator>(newDesignators,
FuncDesignatorHasTarget);designatorOperationRR=new RoundRobin<Designator>(newDesignators,FuncDesignatorIsWorking);}void ˌ(){List<IMyCameraBlock
>ˋ;GetBlocksFromGroups(out ˋ,Ѓ,(Ƌ)=>{Ƌ.EnableRaycast=true;Ƌ.Enabled=true;return true;});if(ˋ==null){ˋ=new List<
IMyCameraBlock>(0);}ʉ=ˋ;ʑ.Î=ʉ;}void ː(){Dictionary<long,U>ˊ=null;{if(ʌ!=null&&ʌ.Count>0){ˊ=new Dictionary<long,U>();foreach(U ʲ in ʌ){
if(!ˊ.ContainsKey(ʲ.Ô.EntityId)){ˊ.Add(ʲ.Ô.EntityId,ʲ);}}}}HashSet<IMyTerminalBlock>ˈ=new HashSet<IMyTerminalBlock>();List
<IMyMotorStator>ˇ=new List<IMyMotorStator>();Dictionary<long,List<IMyMotorStator>>ˆ=new Dictionary<long,List<
IMyMotorStator>>();Dictionary<long,List<IMyUserControllableGun>>ˁ=new Dictionary<long,List<IMyUserControllableGun>>();Dictionary<long,
IMyTerminalBlock>ˀ=new Dictionary<long,IMyTerminalBlock>();Dictionary<long,IMyShipController>ʿ=new Dictionary<long,IMyShipController>();
Dictionary<long,IMyShipConnector>ˉ=new Dictionary<long,IMyShipConnector>();List<IMyBlockGroup>ʮ=new List<IMyBlockGroup>();List<U>ˤ
=new List<U>();GridTerminalSystem.GetBlockGroups(ʮ,(Ƌ)=>{return Ƌ.Name.IndexOf(Ͽ,StringComparison.OrdinalIgnoreCase)>-1;}
);foreach(IMyBlockGroup Ū in ʮ){Ū.GetBlocksOfType(ɰ,(ɵ)=>{if(Me.IsSameConstructAs(ɵ)&&ˈ.Add(ɵ)){if(ɵ is IMyMotorStator){
if(п(ɵ,Ͼ)){ˇ.Add(ɵ as IMyMotorStator);}else if(п(ɵ,Ͻ)){if(ˆ.ContainsKey(ɵ.CubeGrid.EntityId)){ˆ[ɵ.CubeGrid.EntityId].Add(ɵ
as IMyMotorStator);}else{List<IMyMotorStator>ˮ=new List<IMyMotorStator>();ˮ.Add(ɵ as IMyMotorStator);ˆ.Add(ɵ.CubeGrid.
EntityId,ˮ);}}}else if(ɵ is IMyUserControllableGun){if(ˁ.ContainsKey(ɵ.CubeGrid.EntityId)){ˁ[ɵ.CubeGrid.EntityId].Add(ɵ as
IMyUserControllableGun);}else{List<IMyUserControllableGun>ˮ=new List<IMyUserControllableGun>();ˮ.Add(ɵ as IMyUserControllableGun);ˁ.Add(ɵ.
CubeGrid.EntityId,ˮ);}}else if(ɵ is IMyShipController){if(!ʿ.ContainsKey(ɵ.CubeGrid.EntityId)){ʿ.Add(ɵ.CubeGrid.EntityId,ɵ as
IMyShipController);}}else if(ɵ is IMyShipConnector){if(!ˉ.ContainsKey(ɵ.CubeGrid.EntityId)){if(п(ɵ,ϻ)){ˉ.Add(ɵ.CubeGrid.EntityId,ɵ as
IMyShipConnector);}}}else if(п(ɵ,ϼ)){if(!ˀ.ContainsKey(ɵ.CubeGrid.EntityId)){ˀ.Add(ɵ.CubeGrid.EntityId,ɵ);}}}return false;});}foreach(
IMyMotorStator à in ˇ){if(à.TopGrid!=null){List<IMyMotorStator>ˬ;if(ˆ.TryGetValue(à.TopGrid.EntityId,out ˬ)){List<IMyMotorStator>ß=new
List<IMyMotorStator>();List<List<IMyUserControllableGun>>Õ=new List<List<IMyUserControllableGun>>();List<IMyTerminalBlock>â=
new List<IMyTerminalBlock>();Į ˣ=null;IMyTerminalBlock ˢ=null;foreach(IMyMotorStator ñ in ˬ){if(ñ.TopGrid!=null){List<
IMyUserControllableGun>ˡ;if(ˁ.TryGetValue(ñ.TopGrid.EntityId,out ˡ)){IMyTerminalBlock ô;if(ˀ.ContainsKey(ñ.TopGrid.EntityId)){ô=ˀ[ñ.TopGrid.
EntityId];}else{ô=ˡ[0];}ß.Add(ñ);Õ.Add(ˡ);â.Add(ô);if(ˣ==null&&ˡ.Count>0){ˣ=Ҳ(ˡ[0]);}if(ˢ==null){ˢ=ô;}}}}if(ß.Count>0){
IMyShipController Þ;if(ʿ.ContainsKey(ß[0].TopGrid.EntityId)){Þ=ʿ[ß[0].TopGrid.EntityId];}else{Þ=ʍ;}if(ˣ==null){ˣ=ʎ.ώ;}U ʲ=new U(à.
CustomName,à,ß,â,Þ,Õ,ˣ,gs);IMyShipConnector ˠ=null;if(ˉ.ContainsKey(ß[0].CubeGrid.EntityId)){ˠ=ˉ[ß[0].CubeGrid.EntityId];}
IMyShipConnector ʾ=null;if(ˉ.ContainsKey(ˢ.CubeGrid.EntityId)){ʾ=ˉ[ˢ.CubeGrid.EntityId];}if(ˠ!=null&&ʾ!=null){ʲ.õ=ˠ;ʲ.ý=ʾ;}if(ˊ!=null&&ˊ
.ContainsKey(ʲ.Ô.EntityId)){ʲ.é(ˊ[ʲ.Ô.EntityId]);}else{ʲ.ReleaseWeapons(true);ʲ.ȫ();}ˤ.Add(ʲ);}}}}if(gs.ι==0){ʈ=Math.Max(
(int)Math.Ceiling(gs.α*ˤ.Count/(double)ϔ),1);ʇ=0;}else{if(gs.ι<1f&&gs.ι>0){ʈ=1;ʇ=Math.Min((int)Math.Floor(1f/gs.ι),ϔ);}
else{ʈ=Math.Max(Math.Min(ˤ.Count,(int)Math.Ceiling(gs.ι)),1);ʇ=0;}}double ʽ=(double)ˤ.Count/ʈ;double ʦ=ʽ/Math.Max(gs.ω,1);
foreach(U ʲ in ˤ){ʲ.ù=ʦ;ʲ.Ĕ=MathHelperD.ToRadians(gs.Ͷ);ʲ.ē=MathHelperD.ToRadians(gs.ʹ);ʲ.ú=ʕ;}ʌ=ˤ;ʋ=new RoundRobin<U>(ˤ,Ѯ);ʐ=
new RoundRobin<U>(ˤ,Ѯ);}void ʱ(){List<ŀ>ʰ=new List<ŀ>();Dictionary<string,ŀ>ʯ=new Dictionary<string,ŀ>();List<IMyBlockGroup
>ʮ=new List<IMyBlockGroup>();GridTerminalSystem.GetBlockGroups(ʮ,(Ƌ)=>{return п(Ƌ,Ђ);});foreach(IMyBlockGroup Ū in ʮ){Ū.
GetBlocksOfType(ɰ,(Ƌ)=>{int ŗ=1;int ʬ=Ƌ.CustomName.IndexOf(ϸ,StringComparison.OrdinalIgnoreCase);if(ʬ>-1){if(ʬ+Ϻ.Length<Ƌ.CustomName.
Length){if(int.TryParse($"{Ƌ.CustomName[ʬ+ϸ.Length]}",out ŗ)){if(ŗ<1||ŗ>9){ŗ=1;}}else{ŗ=1;}}}string ʫ=ϸ+ŗ;ŀ ʨ;if(ʯ.ContainsKey
(ʫ)){ʨ=ʯ[ʫ];}else{if(ʙ!=null&&ʙ.ContainsKey(ʫ)){ʨ=ʙ[ʫ];}else{ʨ=new ŀ(ʫ,null,null,null);ʨ.Ř=gs.δ;}ʰ.Add(ʨ);ʯ.Add(ʫ,ʨ);}if(
п(Ƌ,Ϻ)){ʨ.ľ=Ƌ;ʨ.Ņ=Ƌ as IMyLargeTurretBase;}else if(п(Ƌ,Ѐ)){ʨ.Ŕ=Ƌ;}else if(п(Ƌ,Ϲ)){IMyTextSurfaceProvider ʪ=Ƌ as
IMyTextSurfaceProvider;if(ʪ!=null){try{ʨ.ō=ʪ.GetSurface(0);}catch(Exception){}}}else{if(ʨ.ľ==null){ʨ.ľ=Ƌ;ʨ.Ņ=Ƌ as IMyLargeTurretBase;}if(ʨ.ō==
null&&Ƌ is IMyTextSurfaceProvider){try{ʨ.ō=((IMyTextSurfaceProvider)Ƌ).GetSurface(0);}catch(Exception){}}}return false;});
break;}int ʩ=0;while(ʩ<ʰ.Count){ŀ ʨ=ʰ[ʩ];if(ʨ.ľ==null){if(ʩ+1==ʰ.Count){ʰ.RemoveAt(ʩ);}else{ʰ[ʩ]=ʰ[ʰ.Count-1];ʰ.RemoveAt(ʰ.
Count-1);}ʯ.Remove(ʨ.Ŀ);}ʩ++;}ʛ=ʰ;ʙ=ʯ;}void ʧ(){GetBlocksFromGroups(out ʊ,Ё);}void ʭ(){if(ʛ?.Count>0&&gs.γ>0&&(clock%gs.γ<ʛ.
Count)){ŀ ʨ=ʛ[clock%gs.γ];if(Ҷ(ʨ.ľ)&&ʨ.Ŝ){Vector3D Ƥ=ʨ.œ();Vector3D Ę=ʨ.ľ.WorldMatrix.Translation+(Ƥ*ʨ.Ř);
MyDetectedEntityInfo Ŵ;ʑ.µ(ref Ę,out Ŵ,gs.υ);if(!Ŵ.IsEmpty()&&ҵ(ref Ŵ)){ʨ.Ś=Ŵ.EntityId;ʨ.Ő=(Ŵ.HitPosition.HasValue?Ŵ.HitPosition.Value:Ŵ.
Position);ʨ.ę=Ŵ.Velocity;ʨ.ŏ=clock;Vector3D ʼ=ʨ.Ő-ʨ.ľ.WorldMatrix.Translation;ʼ=Vector3D.ProjectOnVector(ref ʼ,ref Ƥ)+ʨ.ľ.
WorldMatrix.Translation;ʨ.ī=Vector3D.TransformNormal(ʼ-Ŵ.Position,MatrixD.Transpose(Ŵ.Orientation));ő ž;targetManager.UpdateTarget(
ref Ŵ,clock,out ž);if(ž!=null){ʨ.Ŝ=false;if(Ҷ(ʨ.Ŕ)){if(ʨ.Ŕ is IMySoundBlock){((IMySoundBlock)ʨ.Ŕ).Play();}else if(ʨ.Ŕ is
IMyTimerBlock){((IMyTimerBlock)ʨ.Ŕ).Trigger();}else{IMyFunctionalBlock ʻ=ʨ.Ŕ as IMyFunctionalBlock;if(ʻ!=null&&!ʻ.Enabled){ʻ.Enabled=
true;}}}ž.ğ=ʨ.ğ;ž.Ğ=ʨ.Ğ;foreach(f ʺ in ʁ){if(ʺ.m==ʨ){ʺ.m=ž;ʺ.d=clock+gs.ͱ;}}}}}else if(ʨ.Ś>0&&!targetManager.Ѭ(ʨ.Ś)){ʨ.Ś=-1;
}}}void UpdateDesignatorTargets(){if(gs.WCAPI!=null){WCThreatsScratchpad.Clear();gs.WCAPI.GetSortedThreats(Me,
WCThreatsScratchpad);foreach(var target in WCThreatsScratchpad.Keys){MyDetectedEntityInfo entityInfo=target;if(targetManager.UpdateTarget(
ref entityInfo,clock)){ʟ=clock+gs.ϊ;}}}else{designatorTargetRR.Begin();int maxCount=(gs.MaxDesignatorUpdatesPerTick==0?
designators.Count:gs.MaxDesignatorUpdatesPerTick);for(int Q=0;Q<maxCount;Q++){Designator designator=designatorTargetRR.GetNext();if
(designator!=null){MyDetectedEntityInfo entityInfo=designator.Turret.GetTargetedEntity();if(targetManager.UpdateTarget(
ref entityInfo,clock)){ʟ=clock+gs.ϊ;}ʂ=clock;if(gs.ί){if(clock>=designator.NextResetClock){designator.Turret.
ResetTargetingToDefault();designator.Turret.EnableIdleRotation=false;designator.NextResetClock=clock+gs.ή;}}}else{break;}}if(gs.έ){if(clock<=ʂ+
gs.Ϊ){designatorOperationRR.Begin();maxCount=(gs.Ϋ==0?designators.Count:gs.Ϋ);for(int Q=0;Q<maxCount;Q++){Designator ʷ=
designatorOperationRR.GetNext();if(ʷ!=null){if(clock>=ʷ.ĳ){ʷ.į();ʷ.ĳ=clock+gs.ά;}}else{break;}}}}}}void ʶ(){ő ž=targetManager.ѧ();if(ž!=null)
{if(clock-ž.ļ>=gs.ύ){if(ʑ.Î.Count>0){double ʵ=(ž.ğ==0?gs.σ:ž.ğ);if((ž.Ő-Me.WorldMatrix.Translation).LengthSquared()<=ʵ*ʵ)
{Vector3D Ę=ž.Ő+(ž.ę*(clock-ž.ŏ)*ϕ);MyDetectedEntityInfo Ŵ;if(ʑ.µ(ref Ę,out Ŵ,gs.υ)){Ҍ(ref Ŵ);}ʚ=clock+gs.ϋ;}}
targetManager.ѭ(ž.Ō,clock);Ҁ(ž);}}if(gs.Ω&&gs.κ>0&&clock%gs.κ==0){ő ʴ=targetManager.Ѧ();if(ʴ!=null&&ʴ.ĥ!=null&&ʴ.Ģ>=gs.ΰ*gs.ΰ){double
ʵ=(ʴ.ğ==0?gs.σ:ʴ.ğ);Vector3D Ґ=ʴ.Ŏ+(ʴ.ę*(clock-ʴ.ŏ)*ϕ);if((Ґ-Me.WorldMatrix.Translation).LengthSquared()<=ʵ*ʵ){double Ҏ=
Math.Sqrt(ʴ.Ģ)*0.5*ϙ;Vector3D ҍ=new Vector3D(((ı.NextDouble()*2)-1)*Ҏ,((ı.NextDouble()*2)-1)*Ҏ,((ı.NextDouble()*2)-1)*Ҏ);
Vector3D Ę=Ґ+Vector3D.TransformNormal(ҍ,ʴ.ĥ.Value);MyDetectedEntityInfo Ŵ;if(ʑ.µ(ref Ę,out Ŵ,gs.υ)){Ҍ(ref Ŵ);}ʚ=clock+gs.ϋ;}}}}
void Ҍ(ref MyDetectedEntityInfo Ŵ){if(Ŵ.IsEmpty()){return;}if(ҵ(ref Ŵ)){ő ž;targetManager.UpdateTarget(ref Ŵ,clock,out ž);if
(ž==null){return;}ž.Ģ=Ŵ.BoundingBox.Extents.LengthSquared();if(ž.ġ==0){ž.ġ=ž.Ģ;}if(gs.Ω&&ž.Ģ>=gs.ΰ*gs.ΰ&&Ŵ.HitPosition.
HasValue){if(ž.Ě==null){ž.Ě=new List<ī>(ϝ);}Vector3D ҏ=Vector3D.TransformNormal(Ŵ.HitPosition.Value-Ŵ.Position,MatrixD.Transpose
(Ŵ.Orientation));if(ž.Ě.Count>=ϝ){int ҋ=0;double ҁ=double.MaxValue;for(int Q=0;Q<ž.Ě.Count;Q++){if(clock>ž.Ě[Q].Ļ+ϛ){ҋ=Q;
ҁ=0;break;}double w=(ž.Ě[Q].Ĳ-ҏ).LengthSquared();if(w<ҁ){ҋ=Q;ҁ=w;}}if(ҁ<double.MaxValue){ž.Ě[ҋ]=new ī(ref ҏ,clock);}}else
{ž.Ě.Add(new ī(ref ҏ,clock));}}}else{targetManager.ї(Ŵ.EntityId);targetManager.љ(Ŵ.EntityId);}}void Ҁ(ő ž){Vector3D Ȗ=Me.
GetPosition();Vector3D ѿ=(ʍ!=null?ʍ.GetShipVelocities().LinearVelocity:Vector3D.Zero);if(ž.Ģ>0&&ž.Ģ<gs.ό*gs.ό){targetManager.ї(ž.Ō)
;targetManager.љ(ž.Ō);}else if(clock-ž.ŏ<=gs.φ){double Ҋ=Ҕ(ɪ,Ȗ,ѿ,ž);Ҋ+=ı.NextDouble()*0.000000000001;ž.ĩ=Ҋ;ʠ=Math.Max(Ҋ,ʠ
);if(ʍ==null||ʍ.GetShipVelocities().LinearVelocity.LengthSquared()<=gs.Ύ*gs.Ύ){if(ž.Ģ>=gs.ρ*gs.ρ){if(ž.ě==0||clock>=ž.ě+
gs.Ψ){ž.ě=clock;double ґ=(ž.Ğ==0?gs.ο:ž.Ğ);if((ž.Ő-Me.WorldMatrix.Translation).LengthSquared()<=ґ*ґ){if(ž.Ģ==0){ž.Ĝ=1;}
else{ž.Ĝ=(int)Math.Ceiling(Math.Sqrt(ž.Ģ)/Math.Max(gs.π,1));}}}}}}else{targetManager.љ(ž.Ō);}}void ҕ(){ǰ Ѡ=ʢ.ŉ();if(Ѡ!=null)
{if(clock-Ѡ.Ħ>gs.Ͳ){ʢ.ň(Ѡ.Ō);}}}void қ(){switch(assignmentState){case 0:if(clock>=ʟ){if(targetManager.ћ()>0){ʟ=clock+gs.ω
;ʡ.Clear();ʠ=0;List<ő>Қ=targetManager.Ѩ();foreach(ő ž in Қ){if(!ʡ.ContainsKey(ž.ĩ)){ʡ.Add(ž.ĩ,ž);ʠ=Math.Max(ž.ĩ,ʠ);}}ʋ.ǩ(
);ʋ.Begin();assignmentState=1;}}break;case 1:U ʲ=ʋ.GetNext();if(ʲ!=null){if(ʲ!=null&&!ʲ.IsDamaged){double ҙ=0;ő Ҙ=null;
double җ=0;ő Ҝ=null;foreach(KeyValuePair<double,ő>Җ in ʡ){if(ʲ.IsTargetable(Җ.Value,clock)){ҙ=Җ.Key;Ҙ=Җ.Value;if(ʲ.ÿ>0){if(Ҙ.Ģ
>=ʲ.ÿ*ʲ.ÿ){җ=ҙ;Ҝ=Ҙ;break;}}else{break;}}}if(Ҝ!=null){ҙ=җ;Ҙ=Ҝ;}if(Ҙ!=null){ʲ.ø=Ҙ;if(ʡ.ContainsKey(ҙ)){ʡ.Remove(ҙ);ʠ+=1000;ҙ
=ʠ;ʡ.Add(ҙ,Ҙ);}}else{if(ʲ.ø!=null&&!targetManager.Ѭ(ʲ.ø.Ō)){ʲ.ø=null;}ʲ.ReleaseWeapons();ʲ.ȫ();}}}else{assignmentState=0;
}break;}}double Ҕ(double ɪ,Vector3D Ȗ,Vector3D ѿ,ő ž){Vector3D ғ=ž.Ő-Ȗ;double Ҋ=ғ.Length();PlaneD Ғ;if(ѿ.LengthSquared()<
0.01){Ғ=new PlaneD(Ȗ,Vector3D.Normalize(ғ));}else{Ғ=new PlaneD(Ȗ,Ȗ+ѿ,Ȗ+ғ.Cross(ѿ));}Vector3D Ѿ=Ғ.Intersection(ref ž.Ő,ref ž.
ę);Vector3D ѽ=Ѿ-ž.Ő;if(ѽ.Dot(ref ž.ę)<0){Ҋ+=gs.μ*4;}else{double Ɣ=Math.Sqrt(ѽ.LengthSquared()/Math.Max(ž.ę.LengthSquared(
),0.000000000000001));if((Ѿ-(Ȗ+(ѿ*Ɣ))).LengthSquared()>ɪ*ɪ){Ҋ+=gs.μ*2;}else if(ž.Ģ<=0){Ҋ+=gs.μ;}else if(ž.Ģ<gs.τ*gs.τ){Ҋ
+=gs.μ*3;}}if(ž.ġ>ž.Ģ){Ҋ+=gs.μ*Math.Max(ž.ĝ,1);}else{Ҋ+=gs.μ*Math.Min(ž.ĝ,1);}return Ҋ;}void ѳ(){if(ʇ>0){if(clock>=ʆ){ʆ=
clock+ʇ;}else{return;}}ʐ.Begin();int ʸ=(ʈ==0?ʌ.Count:ʈ);for(int Q=0;Q<ʸ;Q++){U ʲ=ʐ.GetNext();if(ʲ!=null){if(clock>=ʲ.č+gs.ͺ){
ʲ.č=clock;if(ʲ.Ȓ()){if(clock>=ʲ.ė+gs.ͷ){ʲ.ė=clock;ʲ.Ȕ(clock);}}}if(ʲ.ĕ==U.Ƽ.ƻ){if(ʲ.ø!=null){ʲ.Ȑ(ʲ.ø,clock);}}else{ʲ.Ȕ(
clock);}}else{break;}}}void Ѳ(){List<IMyBlockGroup>ʮ=new List<IMyBlockGroup>();ʜ=new List<IMyProgrammableBlock>();
GridTerminalSystem.GetBlockGroups(ʮ,(Ƌ)=>{return п(Ƌ,Ћ);});foreach(IMyBlockGroup Ū in ʮ){Ū.GetBlocksOfType(ʜ,(Ƌ)=>{if(Ƌ.Enabled&&Me.
IsSameConstructAs(Ƌ)){return ч.ф(Ƌ);}else{return false;}});break;}ʮ.Clear();ʣ=new List<IMyProgrammableBlock>();GridTerminalSystem.
GetBlockGroups(ʮ,(Ƌ)=>{return п(Ƌ,О);});foreach(IMyBlockGroup Ū in ʮ){Ū.GetBlocksOfType(ʣ,(Ƌ)=>{if(Ƌ.Enabled&&Me.IsSameConstructAs(Ƌ))
{return ч.ф(Ƌ);}else{return false;}});break;}}void ѱ(){while(ʓ.HasPendingMessage){object Ѱ=ʓ.AcceptMessage().Data;if(Ѱ is
MyTuple<long,long,Vector3D,Vector3D,double>){MyTuple<long,long,Vector3D,Vector3D,double>ѯ=(MyTuple<long,long,Vector3D,Vector3D,
double>)Ѱ;if(!targetManager.Ѭ(ѯ.Item2)||clock-targetManager.ѩ(ѯ.Item2).Ħ>=gs.χ){Ǭ ѥ=new Ǭ();ѥ.Ō=ѯ.Item2;ѥ.Ő=ѯ.Item3;ѥ.ę=ѯ.
Item4;targetManager.UpdateTarget(ѥ,clock-1,false);if(ѯ.Item5>0){ő ž=targetManager.ѩ(ѥ.Ō);if(ž!=null&&ž.Ģ==0){ž.Ģ=ѯ.Item5;}}}}
}while(ʒ.HasPendingMessage){object Ѱ=ʒ.AcceptMessage().Data;if(Ѱ is MyTuple<long,long,Vector3D,Vector3D,double>){MyTuple<
long,Vector3D,Vector3D,double,int,long>Ѹ=(MyTuple<long,Vector3D,Vector3D,double,int,long>)Ѱ;if(!targetManager.Ѭ(Ѹ.Item1)||
clock-targetManager.ѩ(Ѹ.Item1).Ħ>=gs.χ){if((Ѹ.Item5&(int)щ.ш)==0){Ǭ ѥ=new Ǭ();ѥ.Ō=Ѹ.Item1;ѥ.Ő=Ѹ.Item2;ѥ.ę=Ѹ.Item3;
targetManager.UpdateTarget(ѥ,clock-1,false);if(Ѹ.Item4>0){ő ž=targetManager.ѩ(ѥ.Ō);if(ž!=null){if(ž.Ģ==0){ž.Ģ=Ѹ.Item4;}ž.ģ=(Ѹ.Item5&(
int)щ.ģ)>0;}}}else{ǰ Ѡ=new ǰ(Ѹ.Item1);Ѡ.Ő=Ѹ.Item2;Ѡ.ę=Ѹ.Item3;Ѡ.Ǫ=Ѹ.Item4;Ѡ.ģ=(Ѹ.Item5&(int)щ.ģ)>0;ʢ.ў(Ѡ,clock);}}}}}void Ѽ
(string ѻ){string[]р=ѻ.Split(Ϥ,StringSplitOptions.RemoveEmptyEntries);if(р.Length==0)return;string Ѻ=р[0].Trim().ToUpper(
);ŀ ʨ=null;if(Ѻ.StartsWith(ϸ,StringComparison.OrdinalIgnoreCase)){int ŗ;if(Ѻ.Length==ϸ.Length){ŗ=1;}else if(!int.TryParse
(Ѻ.Substring(ϸ.Length).Trim(),out ŗ)){ŗ=0;}if(ŗ>=1&&ʙ.ContainsKey(ϸ+ŗ)){ʨ=ʙ[ϸ+ŗ];}if(ʨ!=null&&р.Length<=1){return;}}if(ʨ
!=null){Ѻ=р[1].Trim().ToUpper();}else if(ʛ?.Count>0){ʨ=ʛ[0];}switch(Ѻ){case М:bool ѹ=н(р,К);List<IMyProgrammableBlock>ѷ=(ѹ
?ʣ:ʜ);if(н(р,Л)){ő ʴ=targetManager.Ѧ();if(ʴ!=null){һ(ѷ,ʴ,ʨ?.ř??э.ь,ʨ?.ī,ѹ);}}else if(ʨ!=null){bool ѵ=н(р,Й);if(ʨ.Ś>0&&
targetManager.Ѭ(ʨ.Ś)){ő Ѷ=targetManager.ѩ(ʨ.Ś);if(Ѷ!=null){if(ѵ){Ѷ.Ğ=Math.Max(ʨ.Ř,gs.ο);}һ(ѷ,Ѷ,ʨ.ř,ʨ.ī,ѹ);}}else{ʨ.Ŝ=true;ʨ.Ś=-1;ʨ.ī=
Vector3D.Zero;ʨ.Ő=ʨ.ľ.WorldMatrix.Translation+(ʨ.œ()*ʨ.Ř);ʨ.ğ=Math.Max(ʨ.Ř,gs.σ);ʨ.Ğ=(ѵ?Math.Max(ʨ.Ř,gs.ο):0);һ(ѷ,ʨ,ʨ.ř,ʨ.ī,ѹ);}
}break;case И:if(ʨ!=null){if(ʨ.Ŝ&&ʨ.Ś==-1){ʨ.Ŝ=false;ʨ.ī=Vector3D.Zero;}else{bool ѵ=н(р,Й);ʨ.Ŝ=true;ʨ.Ś=-1;ʨ.ī=Vector3D.
Zero;ʨ.Ő=ʨ.ľ.WorldMatrix.Translation+(ʨ.œ()*ʨ.Ř);ʨ.ğ=Math.Max(ʨ.Ř,gs.σ);ʨ.Ğ=(ѵ?Math.Max(ʨ.Ř,gs.ο):0);}}break;case З:if(ʨ!=
null){ʨ.Ŝ=false;ʨ.Ś=-1;ʨ.ī=Vector3D.Zero;}break;case Ж:if(ʨ!=null&&р.Length>=3){switch(р[2].ToUpper().Trim()){case Е:ʨ.ř=э.ь
;break;case Д:ʨ.ř=э.ы;break;case Г:ʨ.ř=э.ъ;break;case В:if(р.Length>=4){double ǲ;if(double.TryParse(р[3].Trim(),out ǲ)){ʨ
.Ř=Math.Min(Math.Max(ǲ,1000),100000);;}}break;}}break;case Џ:if(ʨ!=null){ʨ.ř=(э)(((int)ʨ.ř+1)%3);}break;case Б:if(ʨ!=null
){ʨ.Ř=Math.Min(Math.Max(ʨ.Ř+1000,1000),100000);;}break;case А:if(ʨ!=null){ʨ.Ř=Math.Min(Math.Max(ʨ.Ř-1000,1000),100000);;}
break;case Ў:ɦ=!ɦ;if(!ɦ){foreach(U ʲ in ʌ){ʲ.ø=null;ʲ.ReleaseWeapons(true);ʲ.ȫ();}}break;case Ѝ:ɦ=true;break;case Ќ:ɦ=false;
foreach(U ʲ in ʌ){ʲ.ø=null;ʲ.ReleaseWeapons(true);ʲ.ȫ();}break;case Ϸ:gs.ς=!gs.ς;break;case ϡ:gs.ς=true;break;case Ϗ:gs.ς=false
;break;case ϟ:debugMode=!debugMode;break;}}void Ѵ(){if(gs.ς){if(targetManager.ћ()>0){ő ž=targetManager.ѧ();if(ž!=null){if
(ž.Ĝ>0&&targetManager.Ѭ(ž.Ō)){ž.Ĝ--;bool Ӄ=(ž.Ĝ<=0?true:(ı.NextDouble()<=gs.ν));ӄ(ž,Ӄ);ʖ=clock+gs.λ;}}}}}void ӄ(ő ž,bool
Ӄ=false,bool ӂ=false){IMyProgrammableBlock Ӂ=null;double ǭ=double.MaxValue;foreach(IMyProgrammableBlock ɵ in ʜ){if(ɵ.
IsWorking&&GridTerminalSystem.GetBlockWithId(ɵ.EntityId)!=null){double Ӆ=(ɵ.WorldMatrix.Translation-ž.Ő).LengthSquared();if(Ӆ<ǭ){
ǭ=Ӆ;Ӂ=ɵ;}}}if(Ӂ!=null&&!ӂ){f ʺ=new f();ʺ.e=Һ();ʺ.m=ž;ʺ.d=clock+gs.ͱ;ʺ.X=Ӄ;ʁ.Enqueue(ʺ);f ҿ=new f();ҿ.m=ž;ҿ.d=int.MaxValue
;ҿ.W=true;ʁ.Enqueue(ҿ);MyTuple<long,long,long,int,float>Ҿ=new MyTuple<long,long,long,int,float>();Ҿ.Item1=Me.EntityId;Ҿ.
Item2=ʺ.e;Ҿ.Item3=Me.EntityId;Ҿ.Item4|=(int)я.ю;Ҿ.Item5=(Ӄ?(float)(Math.Sqrt(ž.Ģ)*0.5*gs.ξ):0f);bool ҽ=IGC.SendUnicastMessage
(Ӂ.EntityId,"",Ҿ);if(!ҽ){MyIni Ҽ=new MyIni();if(Ӂ.CustomData.Length>0)Ҽ.TryParse(Ӂ.CustomData);Ҽ.Set(Ѕ,"UniqueId",Ҿ.Item2
);Ҽ.Set(Ѕ,"GroupId",Ҿ.Item3);if(Ӄ){Ҽ.Set(Ѕ,"OffsetTargeting",Ҿ.Item4);Ҽ.Set(Ѕ,"RandomOffsetAmount",Ҿ.Item5);}Ӂ.CustomData
=Ҽ.ToString();Ӂ.TryRun("FIRE:"+Me.EntityId);}ʜ.Remove(Ӂ);}}void һ(List<IMyProgrammableBlock>ѷ,ő ž,э Ӏ=э.ь,Vector3D?ҏ=null
,bool ӆ=false,bool ӂ=false){for(int Q=0;Q<ѷ.Count;Q++){IMyProgrammableBlock Ӎ=ѷ[Q];if(Ӎ.IsWorking&&GridTerminalSystem.
GetBlockWithId(Ӎ.EntityId)!=null&&!ӂ){f ʺ=new f();ʺ.e=Һ();ʺ.m=ž;ʺ.d=clock+gs.ε;if(ӆ&&п(Ӎ,Н))ʺ.V=Ӎ;ʁ.Enqueue(ʺ);MyIni Ҽ=null;MyTuple<
long,long,long,int,float>Ҿ=new MyTuple<long,long,long,int,float>();Ҿ.Item1=Me.EntityId;Ҿ.Item2=ʺ.e;Ҿ.Item3=Me.EntityId;
switch(Ӏ){case э.ы:Ҿ.Item4|=(int)я.ю;Ҽ=new MyIni();if(Ӎ.CustomData.Length>0)Ҽ.TryParse(Ӎ.CustomData);Ҽ.Set(Ѕ,
"ProbeOffsetVector",Ҹ(ҏ!=null?ҏ.Value:Vector3D.Zero));Ӎ.CustomData=Ҽ.ToString();break;case э.ъ:Ҿ.Item4|=(int)я.ю;Ҿ.Item5=(float)(Math.Sqrt(
ž.Ģ)*0.5*gs.ξ);break;default:Ҿ.Item5=0f;break;}bool ҽ=IGC.SendUnicastMessage(Ӎ.EntityId,"",Ҿ);if(!ҽ){if(Ҽ==null){Ҽ=new
MyIni();if(Ӎ.CustomData.Length>0)Ҽ.TryParse(Ӎ.CustomData);}Ҽ.Set(Ѕ,"UniqueId",Ҿ.Item2);Ҽ.Set(Ѕ,"GroupId",Ҿ.Item3);switch(Ӏ){
case э.ы:Ҽ.Set(Ѕ,"OffsetTargeting",Ҿ.Item4);Ҽ.Set(Ѕ,"ProbeOffsetVector",Ҹ(ҏ!=null?ҏ.Value:Vector3D.Zero));break;case э.ъ:Ҽ.
Set(Ѕ,"OffsetTargeting",Ҿ.Item4);Ҽ.Set(Ѕ,"RandomOffsetAmount",Ҿ.Item5);break;}Ӎ.CustomData=Ҽ.ToString();Ӎ.TryRun("FIRE:"+Me
.EntityId);}if(ѷ.Count==1){ѷ.Clear();}else{ѷ[Q]=ѷ[ѷ.Count-1];ѷ.RemoveAt(ѷ.Count-1);}break;}}}void ӌ(){ɬ=false;if(ɟ==0){Ӌ(
);if(!ɬ){ӈ();}ɟ=1;}else{ӈ();if(!ɬ){Ӌ();}ɟ=0;}}void Ӌ(){while(ʁ.Count>0){f ƿ=ʁ.Dequeue();if(clock<=ƿ.d){if(!(ƿ.m.Ō==-1||
targetManager.Ѭ(ƿ.m.Ō))){break;}if(clock>=ƿ.Y){if(ƿ.V==null){MyTuple<bool,long,long,long,Vector3D,Vector3D>ӊ=new MyTuple<bool,long,
long,long,Vector3D,Vector3D>();ӊ.Item1=ƿ.W;ӊ.Item2=(ƿ.W?Me.EntityId:ƿ.e);ӊ.Item3=0;ӊ.Item4=ƿ.m.Ō;ӊ.Item5=ƿ.m.Ő+(ƿ.m.ę*(clock
-ƿ.m.ŏ+1)*ϕ);ӊ.Item6=ƿ.m.ę;IGC.SendBroadcastMessage(ƿ.W?ϗ:ϐ,ӊ);}else{Vector3D Ę=ƿ.m.Ő+(ƿ.m.ę*(clock-ƿ.m.ŏ+1)*ϕ);MyIni Ӊ=
new MyIni();Ӊ.Set(Ϣ,"EntityId",ƿ.m.Ō);Ӊ.Set(Ϣ,"PositionX",Ę.X);Ӊ.Set(Ϣ,"PositionY",Ę.Y);Ӊ.Set(Ϣ,"PositionZ",Ę.Z);Ӊ.Set(Ϣ,
"VelocityX",ƿ.m.ę.X);Ӊ.Set(Ϣ,"VelocityY",ƿ.m.ę.Y);Ӊ.Set(Ϣ,"VelocityZ",ƿ.m.ę.Z);ƿ.V.TryRun(Ϣ+Ӊ.ToString());}ƿ.Y=clock+gs.Ώ;ɬ=true;}
if(!ƿ.W){ʁ.Enqueue(ƿ);}break;}}}void ӈ(){if(clock>=ɩ&&ʀ.Count==0){if(targetManager.ћ()>0){List<ő>Қ=targetManager.Ѩ();Қ.
Sort(Ͱ);foreach(ő ž in Қ){ʀ.Enqueue(ž);}}ɩ=clock+gs.ζ;}while(ʀ.Count>0){ő ž=ʀ.Dequeue();if(targetManager.ѫ(ž.Ō,clock-gs.φ)){
MyTuple<long,Vector3D,Vector3D,double,int,long>Ѹ=new MyTuple<long,Vector3D,Vector3D,double,int,long>();Ѹ.Item1=ž.Ō;Ѹ.Item2=ž.Ő+
(ž.ę*(clock-ž.ŏ+1)*ϕ);Ѹ.Item3=ž.ę;Ѹ.Item4=ž.Ģ;if(ž.ģ)Ѹ.Item5|=(int)щ.ģ;Ѹ.Item6=0;IGC.SendBroadcastMessage(ϒ,Ѹ);ɬ=true;
break;}}}void Ӈ(){if(clock>=ɨ){MyTuple<long,Vector3D,Vector3D,double,int,long>Ѹ=new MyTuple<long,Vector3D,Vector3D,double,int
,long>();Ѹ.Item1=Me.CubeGrid.EntityId;Ѹ.Item2=Me.CubeGrid.WorldAABB.Center;Ѹ.Item3=(ʍ!=null?ʍ.GetShipVelocities().
LinearVelocity:Vector3D.Zero);Ѹ.Item4=ɪ*ɪ*4;Ѹ.Item5|=(int)щ.ш;if(Me.CubeGrid.GridSizeEnum==MyCubeSize.Large)Ѹ.Item5|=(int)щ.ģ;Ѹ.Item6=
0;IGC.SendBroadcastMessage(ϒ,Ѹ);ɨ=clock+gs.ζ;}}void Ү(){foreach(ŀ ʨ in ʛ){if(ʨ.ō!=null){IMyTextSurface Ҭ=ʨ.ō;Vector2 ҫ;
Vector2 Ҫ;if(Ҭ.SurfaceSize.X==Ҭ.SurfaceSize.Y){ҫ=(Ҭ.TextureSize-Ҭ.SurfaceSize)*0.5f;Ҫ=new Vector2(Ҭ.SurfaceSize.X)*
0.0009765625f;}else if(Ҭ.SurfaceSize.X>Ҭ.SurfaceSize.Y){ҫ=(Ҭ.TextureSize-Ҭ.SurfaceSize+new Vector2(Ҭ.SurfaceSize.X-Ҭ.SurfaceSize.Y,0f
))*0.5f;Ҫ=new Vector2(Ҭ.SurfaceSize.Y)*0.0009765625f;}else{ҫ=(Ҭ.TextureSize-Ҭ.SurfaceSize+new Vector2(0f,Ҭ.SurfaceSize.Y-
Ҭ.SurfaceSize.X))*0.5f;Ҫ=new Vector2(Ҭ.SurfaceSize.Y)*0.0009765625f;}List<MySprite>ҩ=new List<MySprite>();ҩ.Add(new
MySprite(SpriteType.TEXTURE,"SquareSimple",Ҭ.TextureSize*0.5f,null,Color.Black));Vector2 Ҩ=Ҫ*new Vector2(1024f,100f);Vector2 ҧ=
new Vector2(Ҩ.X*0.5f,0f);Vector2 Ҧ=Ҩ*0.5f;Vector2 ҭ=new Vector2(0f,Ҩ.Y);Vector2 ҥ=new Vector2(0f,Ҫ.Y*20f);Vector2 ң=Ҫ*new
Vector2(480f,100f);Vector2 Ң=new Vector2(ң.X*0.5f,0f);Vector2 ҡ=ң*0.5f;Vector2 Ҡ=Ҫ*new Vector2(544f,0f);float ҟ=ϵ*Ҩ.Y;Vector2 Ҟ
=ҫ+ҥ;string ҝ;Color Ҥ;Color ү;ҩ.Add(new MySprite(SpriteType.TEXTURE,"SquareSimple",Ҟ+Ҧ,Ҩ,ϲ));ҩ.Add(new MySprite(
SpriteType.TEXT,$"{Ї} v{Ј}",Ҟ+ҧ,null,ϳ,"DEBUG",TextAlignment.CENTER,ҟ));Ҟ+=ҭ;ҩ.Add(new MySprite(SpriteType.TEXTURE,"SquareSimple",
Ҟ+Ҧ,Ҩ,ϰ));ҩ.Add(new MySprite(SpriteType.TEXT,$"Manual Targeter {ʨ.Ŀ}",Ҟ+ҧ,null,ϱ,"DEBUG",TextAlignment.CENTER,ҟ));Ҟ+=ҭ+ҥ;
ҩ.Add(new MySprite(SpriteType.TEXT,"Status",Ҟ+ҧ,null,ϯ,"DEBUG",TextAlignment.CENTER,ҟ));Ҟ+=ҭ;if(ʨ.Ś>0){ҝ="Target Locked";
Ҥ=Ϫ;ү=ϩ;}else if(ʨ.Ŝ){ҝ="Seeking";Ҥ=ϴ;ү=Ϭ;}else{ҝ="No Target";Ҥ=Ϯ;ү=ϭ;}ҩ.Add(new MySprite(SpriteType.TEXTURE,
"SquareSimple",Ҟ+Ҧ,Ҩ,ү));ҩ.Add(new MySprite(SpriteType.TEXT,ҝ,Ҟ+ҧ,null,Ҥ,"DEBUG",TextAlignment.CENTER,ҟ));Ҟ+=ҭ+ҥ;ҩ.Add(new MySprite(
SpriteType.TEXT,"Current Target",Ҟ+ҧ,null,ϯ,"DEBUG",TextAlignment.CENTER,ҟ));Ҟ+=ҭ;if(ʨ.Ś>0){ҝ=ҹ(ʨ.Ś);Ҥ=Ϩ;ү=ϧ;}else{ҝ="-";Ҥ=Ϯ;ү=ϭ;}
ҩ.Add(new MySprite(SpriteType.TEXTURE,"SquareSimple",Ҟ+Ҧ,Ҩ,ү));ҩ.Add(new MySprite(SpriteType.TEXT,ҝ,Ҟ+ҧ,null,Ҥ,"DEBUG",
TextAlignment.CENTER,ҟ));Ҟ+=ҭ+ҥ;ҩ.Add(new MySprite(SpriteType.TEXT,"Range",Ҟ+Ң,null,ϯ,"DEBUG",TextAlignment.CENTER,ҟ));ҩ.Add(new
MySprite(SpriteType.TEXT,"Hit Point",Ҟ+Ҡ+Ң,null,ϯ,"DEBUG",TextAlignment.CENTER,ҟ));Ҟ+=ҭ;ҝ=$"{Math.Round(ʨ.Ř*0.001,1):n1}km";Ҥ=Ϧ;
ү=ϥ;ҩ.Add(new MySprite(SpriteType.TEXTURE,"SquareSimple",Ҟ+ҡ,ң,ү));ҩ.Add(new MySprite(SpriteType.TEXT,ҝ,Ҟ+Ң,null,Ҥ,
"DEBUG",TextAlignment.CENTER,ҟ));ҝ=ʨ.Œ();Ҥ=Ϧ;ү=ϥ;ҩ.Add(new MySprite(SpriteType.TEXTURE,"SquareSimple",Ҟ+Ҡ+ҡ,ң,ү));ҩ.Add(new
MySprite(SpriteType.TEXT,ҝ,Ҟ+Ҡ+Ң,null,Ҥ,"DEBUG",TextAlignment.CENTER,ҟ));Ҭ.ContentType=ContentType.SCRIPT;Ҭ.Script="";
MySpriteDrawFrame Ҵ=Ҭ.DrawFrame();Ҵ.AddRange(ҩ);Ҵ.Dispose();}}}void ō(){ǟ.Clear();ɣ=(ɣ+1)%8;ǟ.AppendLine(
$"====[ Diamond Dome System ]==={ϣ[ɣ]}");ǟ.AppendLine($"<<Version {Ј}>>\n");ǟ.AppendLine($"PDCs : {ʌ.Count(Ƌ=>{return!Ƌ.IsDamaged;})}");ǟ.AppendLine(
$"Designators : {designators.Count}");ǟ.AppendLine($"Raycast Cameras : {ʉ.Count}");ǟ.AppendLine($"Guided Missiles : {ʜ.Count}");ǟ.AppendLine(
$"Guided Torpedos : {ʣ.Count}");if(ɦ){ǟ.AppendLine($"Tracked Targets : {targetManager.ћ()}");}else{ǟ.AppendLine("\n---< DD Disabled >---");}ǟ.
AppendLine("\n---- Runtime Performance ---\n");ɭ.Ǧ(ǟ);if(debugMode){ǟ.AppendLine("\n>>>>>>> Debug Mode <<<<<<<");ǟ.AppendLine(
debug.ToString());ǟ.AppendLine("\n---- Debug Performance ---\n");ɭ.Ǡ(ǟ);}Echo(ǟ.ToString());}long Һ(){ı.NextBytes(ʘ);Buffer.
BlockCopy(ʘ,0,ʗ,0,8);return ʗ[0];}string ҹ(long Ġ){return$"T{Ġ%100000:00000}";}string Ҹ(Vector3D ҷ){return Convert.ToBase64String
(BitConverter.GetBytes((float)ҷ.X))+Convert.ToBase64String(BitConverter.GetBytes((float)ҷ.Y))+Convert.ToBase64String(
BitConverter.GetBytes((float)ҷ.Z));}bool Ҷ(IMyTerminalBlock ɵ){return(ɵ!=null&&ɵ.IsWorking);}bool ҵ(ref MyDetectedEntityInfo Ŵ){if(Ŵ
.Type==MyDetectedEntityType.LargeGrid||Ŵ.Type==MyDetectedEntityType.SmallGrid){return ҳ(ref Ŵ);}return false;}bool ҳ(ref
MyDetectedEntityInfo Ŵ){return!(Ŵ.Relationship==MyRelationsBetweenPlayerAndBlock.Owner||Ŵ.Relationship==MyRelationsBetweenPlayerAndBlock.
FactionShare);}Į Ҳ(IMyUserControllableGun ȴ){if(ȴ.BlockDefinition.SubtypeId.Contains("Gatling")){return ʎ.ώ;}else if(ȴ.
BlockDefinition.SubtypeId.Contains("Missile")||ȴ.BlockDefinition.SubtypeId.Contains("Rocket")){return ʎ.Њ;}return ʎ.ώ;}bool
FuncDesignatorHasTarget(Designator ʷ){return ʷ.Turret.HasTarget;}bool FuncDesignatorIsWorking(Designator ʷ){return ʷ.Turret.IsWorking;}bool Ѯ(U
ʲ){return!ʲ.IsDamaged;}bool п(IMyTerminalBlock ɵ,string о){return(ɵ.CustomName.IndexOf(о,StringComparison.
OrdinalIgnoreCase)>-1);}bool п(IMyBlockGroup Ū,string о){return(Ū.Name.IndexOf(о,StringComparison.OrdinalIgnoreCase)>-1);}bool н(string[]
р,string м){foreach(string л in р){if(л.Trim().Equals(м,StringComparison.OrdinalIgnoreCase)){return true;}}return false;}
void GetBlocksFromGroups<Т>(out List<Т>Ơ,string й,Func<Т,bool>и=null)where Т:class{Ơ=null;List<IMyBlockGroup>ʮ=new List<
IMyBlockGroup>();GridTerminalSystem.GetBlockGroups(ʮ,(Ƌ)=>{return Ƌ.Name.IndexOf(й,StringComparison.OrdinalIgnoreCase)>-1;});foreach(
IMyBlockGroup Ū in ʮ){List<Т>ɸ=new List<Т>();Ū.GetBlocksOfType(ɸ,и);if(Ơ==null){Ơ=ɸ;}else{Ơ.AddList(ɸ);}}}public enum я{ю=1}public
enum э{ь=0,ы=1,ъ=2}public enum щ{ш=1,ģ=2}static class ч{const string ц="AGMSAVE";const string х="[NOTREADY]";public static
bool ф(IMyProgrammableBlock у){if(у!=null&&у.CustomName.IndexOf(х,StringComparison.OrdinalIgnoreCase)>-1){Vector3I[]Ъ={-
Base6Directions.GetIntVector(у.Orientation.Left),Base6Directions.GetIntVector(у.Orientation.Up),-Base6Directions.GetIntVector(у.
Orientation.Forward)};MyIni ʳ=new MyIni();if(ʳ.TryParse(у.CustomData)&&ʳ.ContainsSection(ц)){char[]Ы={','};if(!т("DetachBlock",у,ʳ,
Ы,ref Ъ,true))return false;if(!т("DampenerBlock",у,ʳ,Ы,ref Ъ,true))return false;if(!т("ForwardBlock",у,ʳ,Ы,ref Ъ,false))
return false;if(!т("RemoteControl",у,ʳ,Ы,ref Ъ,false))return false;if(!т("Gyroscopes",у,ʳ,Ы,ref Ъ,false))return false;if(!т(
"Thrusters",у,ʳ,Ы,ref Ъ,false))return false;if(!т("PowerBlocks",у,ʳ,Ы,ref Ъ,true))return false;if(!т("RaycastCameras",у,ʳ,Ы,ref Ъ,
true))return false;}у.CustomName=у.CustomName.Replace(х,"").Trim();}return true;}static bool т(string Š,IMyTerminalBlock Х,
MyIni ʳ,char[]Ы,ref Vector3I[]Ъ,bool Щ){string[]Ш=ʳ.Get(ц,Š).ToString().Split(Ы,StringSplitOptions.RemoveEmptyEntries);return
((Ш.Length>0||Щ)&&Ч(Ш,Х,ref Ъ));}static bool Ч(string[]Ц,IMyTerminalBlock Х,ref Vector3I[]Ъ){foreach(string ơ in Ц){if(ơ
!=null&&ơ.Length==12){Vector3I Ơ=new Vector3I();Ơ.X=BitConverter.ToInt16(Convert.FromBase64String(ơ.Substring(0,4)),0);Ơ.Y
=BitConverter.ToInt16(Convert.FromBase64String(ơ.Substring(4,4)),0);Ơ.Z=BitConverter.ToInt16(Convert.FromBase64String(ơ.
Substring(8,4)),0);Ơ=(Ơ.X*Ъ[0])+(Ơ.Y*Ъ[1])+(Ơ.Z*Ъ[2]);Ơ+=Х.Position;if(!Х.CubeGrid.CubeExists(Ơ)){return false;}}else{return
false;}}return true;}}class RoundRobin<Т>{private List<Т>С;private Func<Т,bool>Р;private int П;private int ƿ;private bool Ф;
public RoundRobin(List<Т>б,Func<Т,bool>з=null){С=б;Р=з;П=ƿ=0;Ф=false;if(С==null)С=new List<Т>();}public void ǩ(){П=ƿ=0;}public
void Begin(){П=ƿ;Ф=(С.Count>0);}public Т GetNext(){if(П>=С.Count)П=0;if(ƿ>=С.Count){ƿ=0;Ф=(С.Count>0);}Т Ơ=default(Т);while(
Ф){Т г=С[ƿ++];if(ƿ>=С.Count)ƿ=0;if(ƿ==П)Ф=false;if(Р==null||Р(г)){Ơ=г;break;}}return Ơ;}public void в(List<Т>б){С=б;if(С
==null)С=new List<Т>();if(П>=С.Count)П=0;if(ƿ>=С.Count)ƿ=0;Ф=false;}}class ж:IComparer<ő>{public int Compare(ő ł,ő Ł){if(ł
==null)return(Ł==null?0:1);else if(Ł==null)return-1;else return(ł.ŏ<Ł.ŏ?-1:(ł.ŏ>Ł.ŏ?1:(ł.Ō<Ł.Ō?-1:(ł.Ō>Ł.Ō?1:0))));}}class
а{Dictionary<long,ņ>Я;SortedSet<ņ>Ю;HashSet<long>Э;public а(){Я=new Dictionary<long,ņ>();Ю=new SortedSet<ņ>(new ѓ());Э=
new HashSet<long>();}public bool UpdateTarget(ref MyDetectedEntityInfo Ŵ,int Ƿ){ő ѐ;return UpdateTarget(ref Ŵ,Ƿ,out ѐ);}
public bool UpdateTarget(ref MyDetectedEntityInfo Ŵ,int Ƿ,out ő ž){if(Э.Contains(Ŵ.EntityId)){ž=null;return false;}if(Я.
ContainsKey(Ŵ.EntityId)){ņ Ŋ=Я[Ŵ.EntityId];ž=Ŋ.m;int ѣ=Math.Max(Ƿ-ž.ŏ,1);double Ѣ=1.0/ѣ;ž.ħ=ž.ę;ž.Ħ=ž.ŏ;if(Ŵ.HitPosition!=null){ž.Ő
=Ŵ.HitPosition.Value;ž.Ŏ=Ŵ.Position;ž.Ľ=Ƿ;ž.ĥ=Ŵ.Orientation;ž.Ĥ=Ƿ;}else{ž.Ő=Ŵ.Position;}ž.ģ=(Ŵ.Type==MyDetectedEntityType
.LargeGrid);ž.ę=Ŵ.Velocity;ž.ŏ=Ƿ;Vector3D Ƃ=(ž.ę-ž.ħ)*Ѣ*ϔ;if(Ƃ.LengthSquared()>1){ž.Ĩ=(ž.Ĩ*0.25)+(Ƃ*0.75);}else{ž.Ĩ=
Vector3D.Zero;}Ŋ.є=Ƿ;return false;}else{ž=new ő(Ŵ.EntityId);ž.Ő=Ŵ.Position;ž.ę=ž.ħ=Ŵ.Velocity;ž.ŏ=ž.Ħ=Ƿ;ņ Ŋ=new ņ();Ŋ.Ō=ž.Ō;Ŋ.m=
ž;Ŋ.є=Ƿ;Я.Add(Ŵ.EntityId,Ŋ);Ю.Add(Ŋ);return true;}}public bool UpdateTarget(Ǭ ѥ,int Ƿ,bool Ѥ=true){if(Э.Contains(ѥ.Ō)){
return false;}if(Я.ContainsKey(ѥ.Ō)){ņ Ŋ=Я[ѥ.Ō];ő ž=Ŋ.m;int ѣ=Math.Max(Ƿ-ž.ŏ,1);double Ѣ=1.0/ѣ;ž.ħ=ž.ę;ž.Ħ=ž.ŏ;ž.Ő=ѥ.Ő;ž.ę=ѥ.ę
;ž.ŏ=Ƿ;Vector3D Ƃ=(ž.ę-ž.ħ)*Ѣ*ϔ;if(Ƃ.LengthSquared()>1){ž.Ĩ=(ž.Ĩ*0.25)+(Ƃ*0.75);}else{ž.Ĩ=Vector3D.Zero;}if(Ѥ){Ŋ.є=Ƿ;}
return false;}else{ő ž=new ő(ѥ.Ō);ž.Ő=ѥ.Ő;ž.ę=ž.ħ=ѥ.ę;ž.ŏ=ž.Ħ=Ƿ;ņ Ŋ=new ņ();Ŋ.Ō=ž.Ō;Ŋ.m=ž;if(Ѥ){Ŋ.є=Ƿ;}Я.Add(ѥ.Ō,Ŋ);Ю.Add(Ŋ);
return true;}}public void ѭ(long Ġ,int Ƿ){if(Я.ContainsKey(Ġ)){ņ Ŋ=Я[Ġ];Ŋ.m.ļ=Ƿ;Ю.Remove(Ŋ);Ŋ.ļ=Ƿ;Ю.Add(Ŋ);}}public bool Ѭ(
long Ġ){return Я.ContainsKey(Ġ);}public bool ѫ(long Ġ,int Ѫ){if(Я.ContainsKey(Ġ)){ņ Ŋ=Я[Ġ];return(Ŋ.є>=Ѫ);}else{return false
;}}public int ћ(){return Я.Count;}public ő ѩ(long Ġ){ņ Ŋ;if(Я.TryGetValue(Ġ,out Ŋ))return Ŋ.m;else return null;}public
List<ő>Ѩ(){List<ő>ŋ=new List<ő>(Я.Count);foreach(ņ Ŋ in Ю){ŋ.Add(Ŋ.m);}return ŋ;}public ő ѧ(){if(Ю.Count==0)return null;else
return Ю.Min.m;}public ő Ѧ(){double ѡ=double.MinValue;ő ʴ=null;foreach(ņ Ŋ in Ю){if(Ŋ.m.Ģ>ѡ){ѡ=Ŋ.m.Ģ;ʴ=Ŋ.m;}}return ʴ;}public
void љ(long Ġ){if(Я.ContainsKey(Ġ)){Ю.Remove(Я[Ġ]);Я.Remove(Ġ);}}public void ј(){Я.Clear();Ю.Clear();}public void ї(long Ġ){
Э.Add(Ġ);}public void і(){Э.Clear();}class ņ{public long Ō;public int ļ;public int є;public ő m;}class ѓ:IComparer<ņ>{
public int Compare(ņ ł,ņ Ł){if(ł==null)return(Ł==null?0:1);else if(Ł==null)return-1;else return(ł.ļ<Ł.ļ?-1:(ł.ļ>Ł.ļ?1:(ł.Ō<Ł.Ō
?-1:(ł.Ō>Ł.Ō?1:0))));}}}class ђ{Dictionary<long,ņ>ё;SortedSet<ņ>ѕ;public ђ(){ё=new Dictionary<long,ņ>();ѕ=new SortedSet<ņ
>(new Ń());}public bool ў(ref MyDetectedEntityInfo Ŵ,int Ƿ){if(ё.ContainsKey(Ŵ.EntityId)){ņ Ŋ=ё[Ŵ.EntityId];Ŋ.ń.Ő=Ŵ.
Position;Ŋ.ń.ę=Ŵ.Velocity;Ŋ.ń.ģ=(Ŵ.Type==MyDetectedEntityType.LargeGrid);Ŋ.ń.Ǫ=Ŵ.BoundingBox.Extents.LengthSquared();Ŋ.ń.Ħ=Ƿ;ѕ.
Remove(Ŋ);Ŋ.Ļ=Ƿ;ѕ.Add(Ŋ);return false;}else{ǰ Ѡ=new ǰ(Ŵ.EntityId);Ѡ.Ő=Ŵ.Position;Ѡ.ę=Ŵ.Velocity;Ѡ.Ħ=Ƿ;ņ Ŋ=new ņ();Ŋ.Ō=Ѡ.Ō;Ŋ.ń=
Ѡ;Ŋ.Ļ=Ƿ;ё.Add(Ŵ.EntityId,Ŋ);ѕ.Add(Ŋ);return true;}}public bool ў(ǰ џ,int Ƿ){if(ё.ContainsKey(џ.Ō)){ņ Ŋ=ё[џ.Ō];Ŋ.ń.Ő=џ.Ő;Ŋ
.ń.ę=џ.ę;Ŋ.ń.Ħ=Ƿ;ѕ.Remove(Ŋ);Ŋ.Ļ=Ƿ;ѕ.Add(Ŋ);return false;}else{џ.Ħ=Ƿ;ņ Ŋ=new ņ();Ŋ.Ō=џ.Ō;Ŋ.ń=џ;Ŋ.Ļ=Ƿ;ё.Add(џ.Ō,Ŋ);ѕ.Add(Ŋ
);return true;}}public void ѝ(long Ġ,int Ƿ){if(ё.ContainsKey(Ġ)){ņ Ŋ=ё[Ġ];ѕ.Remove(Ŋ);Ŋ.Ļ=Ƿ;ѕ.Add(Ŋ);}}public bool ќ(long
Ġ){return ё.ContainsKey(Ġ);}public int ћ(){return ё.Count;}public ǰ њ(long Ġ){ņ Ŋ;if(ё.TryGetValue(Ġ,out Ŋ))return Ŋ.ń;
else return null;}public List<ǰ>å(){List<ǰ>ŋ=new List<ǰ>(ё.Count);foreach(ņ Ŋ in ѕ){ŋ.Add(Ŋ.ń);}return ŋ;}public ǰ ŉ(){if(ѕ.
Count==0)return null;else return ѕ.Min.ń;}public void ň(long Ġ){if(ё.ContainsKey(Ġ)){ѕ.Remove(ё[Ġ]);ё.Remove(Ġ);}}public void
Ň(){ё.Clear();ѕ.Clear();}class ņ{public long Ō;public int Ļ;public ǰ ń;}class Ń:IComparer<ņ>{public int Compare(ņ ł,ņ Ł){
if(ł==null)return(Ł==null?0:1);else if(Ł==null)return-1;else return(ł.Ļ<Ł.Ļ?-1:(ł.Ļ>Ł.Ļ?1:(ł.Ō<Ł.Ō?-1:(ł.Ō>Ł.Ō?1:0))));}}}
class ŀ:ő{public string Ŀ;public IMyTerminalBlock ľ;public IMyLargeTurretBase Ņ;public IMyTextSurface ō;public
IMyTerminalBlock Ŕ;public bool Ŝ=false;public long Ś=-1;public Vector3D?ī;public э ř=э.ь;public double Ř;public ŀ(string ŗ,
IMyTerminalBlock Ŗ,IMyTextSurface ś,IMyTerminalBlock ŕ):base(-1){Ŀ=ŗ;ľ=Ŗ;Ņ=Ŗ as IMyLargeTurretBase;ō=ś;Ŕ=ŕ;}public Vector3D œ(){if(ľ==
null){return Vector3D.Zero;}if(Ņ!=null){Vector3D Á;Vector3D.CreateFromAzimuthAndElevation(Ņ.Azimuth,Ņ.Elevation,out Á);
return Vector3D.TransformNormal(Á,Ņ.WorldMatrix);}else{return ľ.WorldMatrix.Forward;}}public string Œ(){switch(ř){case э.ь:
return"Center";case э.ы:return"Offset";case э.ъ:return"Random";}return"-";}}class ő{public long Ō;public Vector3D Ő;public int
ŏ;public Vector3D Ŏ;public int Ľ;public int ļ;public Vector3D ę;public Vector3D Ĩ;public Vector3D ħ;public int Ħ;public
MatrixD?ĥ;public int Ĥ;public bool ģ;public double Ģ;public double ĩ;public double ġ;public double ğ;public double Ğ;public
double ĝ;public int Ĝ;public int ě;public List<ī>Ě;public ő(long Ġ){Ō=Ġ;}}struct ī{public Vector3D Ĳ;public int Ļ;public ī(ref
Vector3D Ĺ,int ĸ){Ĳ=Ĺ;Ļ=ĸ;}}class Designator{public IMyLargeTurretBase Turret;public float ĵ;public ITerminalProperty<float>Ĵ;
public int NextResetClock=0;public int ĳ=0;Random ı=new Random();public Designator(IMyLargeTurretBase İ){Turret=İ;ĵ=İ.
GetMaximum<float>("Range");Ĵ=İ.GetProperty("Range").As<float>();}public void į(){Ĵ.SetValue(Turret,ĵ-0.01f);Ĵ.SetValue(Turret,ĵ);}
}class Į{public double ĭ=400;public double Ĩ=0;public double Ī=400;public double Ĭ=850;public double ŝ=0;public double Ƈ=
0;public bool ƅ=false;public bool Ƅ=false;public Į(double ƃ,double Ƃ,double Ɓ,double ƀ,double Ɔ,double ſ,bool Ž,bool ż){ĭ
=ƃ;Ĩ=Ƃ;Ī=Ɓ;Ĭ=ƀ;ŝ=Ɔ;Ƈ=ſ;ƅ=Ž;Ƅ=ż;}public Vector3D Ż(ref Vector3D ź,ref Vector3D Ź,ref Vector3D Ÿ,ref Vector3D ŷ,ő ž){
Vector3D Ŷ=(ƅ?Ź:Ź-ŷ);Vector3D ƈ=ź-Ÿ;double Ɨ=(Ĩ==0?0:(Ī-ĭ)/Ĩ);double ƕ=(0.5*Ĩ*Ɨ*Ɨ)+(ĭ*Ɨ)-(Ī*Ɨ);double ƌ=(Ī*Ī)-Ŷ.LengthSquared();
double Ƌ=2*((ƕ*Ī)-Ŷ.Dot(ƈ));double Ɗ=(ƕ*ƕ)-ƈ.LengthSquared();double Ɣ=ƍ(ƌ,Ƌ,Ɗ);if(double.IsNaN(Ɣ)||Ɣ<0){return new Vector3D(
double.NaN);}Vector3D Ɠ;if(ž.Ĩ.LengthSquared()>0.1){Ɠ=ź+(Ŷ*Ɣ)+(0.5*ž.Ĩ*Ɣ*Ɣ);}else{Ɠ=ź+(Ŷ*Ɣ);}if(ƅ&&Ī>0){int Ɖ=(int)Math.
Ceiling(Ɣ*60);Vector3D ƒ;Vector3D Ƒ;Vector3D Ɛ;Vector3D Ə;ƒ=Vector3D.Normalize(Ɠ-Ÿ);Ƒ=(ƒ*Ĩ)/60;Ɛ=Ÿ;Ə=ŷ+(ƒ*ĭ);for(int Q=0;Q<Ɖ;Q
++){Ə+=Ƒ;double Ǝ=Ə.Length();if(Ǝ>Ī){Ə=Ə/Ǝ*Ī;}Ɛ+=(Ə/60);if((Q+1)%60==0){if(Vector3D.Distance(Ÿ,Ɛ)>Ĭ){return Ɠ;}}}return Ɠ+
Ɠ-Ɛ;}else{return Ɠ;}}public double ƍ(double ƌ,double Ƌ,double Ɗ){if(ƌ==0){return-(Ɗ/Ƌ);}double Ɖ=(Ƌ*Ƌ)-(4*ƌ*Ɗ);if(Ɖ<0){
return Double.NaN;}Ɖ=Math.Sqrt(Ɖ);double ŵ=(-Ƌ+Ɖ)/(2*ƌ);double ũ=(-Ƌ-Ɖ)/(2*ƌ);return(ŵ>0?(ũ>0?(ŵ<ũ?ŵ:ũ):ŵ):ũ);}}class Ş{float
Ũ;double ŧ;bool Ŧ;List<IMyCameraBlock>ť;public List<IMyCameraBlock>Î{get{return ť;}set{foreach(IMyCameraBlock ª in value)
{ª.Enabled=true;ª.EnableRaycast=true;}ť=value;Ţ();}}List<Ï>Ť;public Ş(List<IMyCameraBlock>ţ){if(ţ.Count>0){Ũ=ţ[0].
RaycastConeLimit;if(Ũ==0f||Ũ==180f)ŧ=double.NaN;else ŧ=Math.Tan(MathHelper.ToRadians(90-Ũ));Ŧ=double.IsNaN(ŧ)||double.IsInfinity(ŧ);if(Ŧ
)ŧ=1;}else{Ũ=45;ŧ=1;Ŧ=false;}Î=ţ;MyMath.InitializeFastSin();}private void Ţ(){if(Ũ<=0||Ũ>=180){Ť=new List<Ï>();return;}
Dictionary<string,Ï>š=new Dictionary<string,Ï>();foreach(IMyCameraBlock ª in ť){string Š=ª.CubeGrid.EntityId.ToString()+"-"+((int)
ª.Orientation.Forward).ToString();Ï ş;if(š.ContainsKey(Š)){ş=š[Š];}else{ş=new Ï();ş.Î=new List<IMyCameraBlock>();ş.Ì=ŧ;ş.
Ë=Ŧ;š[Š]=ş;}ş.Î.Add(ª);}Ť=š.Values.ToList();foreach(Ï ş in Ť){ş.Ò=ş.Î[0].CubeGrid;int F=int.MaxValue,E=int.MinValue,D=int
.MaxValue,C=int.MinValue,B=int.MaxValue,I=int.MinValue;foreach(IMyCameraBlock ª in ş.Î){F=Math.Min(F,ª.Position.X);E=Math
.Max(E,ª.Position.X);D=Math.Min(D,ª.Position.Y);C=Math.Max(C,ª.Position.Y);B=Math.Min(B,ª.Position.Z);I=Math.Max(I,ª.
Position.Z);}Base6Directions.Direction ų=ş.Ò.WorldMatrix.GetClosestDirection(ş.Î[0].WorldMatrix.Up);Base6Directions.Direction Ų=
ş.Ò.WorldMatrix.GetClosestDirection(ş.Î[0].WorldMatrix.Left);Base6Directions.Direction ű=ş.Ò.WorldMatrix.
GetClosestDirection(ş.Î[0].WorldMatrix.Forward);ş.Æ=Ï.N(ų);ş.Å=Ï.N(Ų);ş.Ä=Ï.N(ű);ş.Ê=Ï.H(ų,F,E,D,C,B,I);ş.É=Ï.H(Base6Directions.
GetOppositeDirection(ų),F,E,D,C,B,I);ş.È=Ï.H(Ų,F,E,D,C,B,I);ş.Ç=Ï.H(Base6Directions.GetOppositeDirection(Ų),F,E,D,C,B,I);}}public bool µ(ref
Vector3D Ę,out MyDetectedEntityInfo Ŵ,double Ű=0){IMyCameraBlock ª=ŭ(ref Ę);if(ª!=null){if(Ű==0){Ŵ=µ(ª,ref Ę);}else{Vector3D ů=Ę
-ª.WorldMatrix.Translation;Vector3D Ů=Ę+((Ű/Math.Max(ů.Length(),0.000000000000001))*ů);Ŵ=µ(ª,ref Ů);}return true;}else{Ŵ=
default(MyDetectedEntityInfo);return false;}}IMyCameraBlock ŭ(ref Vector3D Ę){foreach(Ï Ŭ in Ť){if(Ŭ.l(ref Ę)){return ū(Ŭ,ref Ę
);}}return null;}IMyCameraBlock ū(Ï Ū,ref Vector3D Ę){bool Â=true;for(int Q=0;Q<Ū.Î.Count;Q++){if(Ū.Í>=Ū.Î.Count){Ū.Í=0;}
IMyCameraBlock ª=Ū.Î[Ū.Í++];if(ª.IsWorking){if(À(ª,ref Ę)){return ª;}else if(Â){Â=false;if(!Ū.l(ref Ę)){break;}}}}return null;}bool À(
IMyCameraBlock ª,ref Vector3D Z){Vector3D j=(Ŧ?Vector3D.Zero:ª.WorldMatrix.Forward);Vector3D h=ª.WorldMatrix.Left;Vector3D g=ª.
WorldMatrix.Up;Vector3D Á=Z-ª.WorldMatrix.Translation;if(ŧ>=0){return(ª.AvailableScanRange*ª.AvailableScanRange>=Á.LengthSquared())
&&Á.Dot(j+h)>=0&&Á.Dot(j-h)>=0&&Á.Dot(j+g)>=0&&Á.Dot(j-g)>=0;}else{return(ª.AvailableScanRange*ª.AvailableScanRange>=Á.
LengthSquared())&&(Á.Dot(j+h)>=0||Á.Dot(j-h)>=0||Á.Dot(j+g)>=0||Á.Dot(j-g)>=0);}}void º(IMyCameraBlock ª,ref Vector3D Z,out double w,
out double v,out double s){Vector3D r=Z-ª.WorldMatrix.Translation;r=Vector3D.TransformNormal(r,MatrixD.Transpose(ª.
WorldMatrix));Vector3D q=Vector3D.Normalize(new Vector3D(r.X,0,r.Z));w=r.Normalize();s=MathHelper.ToDegrees(Math.Acos(MathHelper.
Clamp(q.Dot(Vector3D.Forward),-1,1))*Math.Sign(r.X));v=MathHelper.ToDegrees(Math.Acos(MathHelper.Clamp(q.Dot(r),-1,1))*Math.
Sign(r.Y));}MyDetectedEntityInfo µ(IMyCameraBlock ª,ref Vector3D Z){double Ó,Ñ,Ð;º(ª,ref Z,out Ó,out Ñ,out Ð);return ª.
Raycast(Ó,(float)Ñ,(float)Ð);}public class Ï{public List<IMyCameraBlock>Î;public int Í;public double Ì;public bool Ë;public
IMyCubeGrid Ò;public Vector3I Ê;public Vector3I É;public Vector3I È;public Vector3I Ç;public Func<IMyCubeGrid,Vector3D>Æ;public
Func<IMyCubeGrid,Vector3D>Å;public Func<IMyCubeGrid,Vector3D>Ä;public static Vector3D Ã(IMyCubeGrid J){return J.WorldMatrix.
Up;}public static Vector3D o(IMyCubeGrid J){return J.WorldMatrix.Down;}public static Vector3D A(IMyCubeGrid J){return J.
WorldMatrix.Left;}public static Vector3D M(IMyCubeGrid J){return J.WorldMatrix.Right;}public static Vector3D L(IMyCubeGrid J){
return J.WorldMatrix.Forward;}public static Vector3D K(IMyCubeGrid J){return J.WorldMatrix.Backward;}public static Func<
IMyCubeGrid,Vector3D>N(Base6Directions.Direction G){switch(G){case Base6Directions.Direction.Up:return Ã;case Base6Directions.
Direction.Down:return o;case Base6Directions.Direction.Left:return A;case Base6Directions.Direction.Right:return M;case
Base6Directions.Direction.Forward:return L;case Base6Directions.Direction.Backward:return K;default:return L;}}public static Vector3I H
(Base6Directions.Direction G,int F,int E,int D,int C,int B,int I){switch(G){case Base6Directions.Direction.Up:return new
Vector3I((F+E)/2,C,(B+I)/2);case Base6Directions.Direction.Down:return new Vector3I((F+E)/2,D,(B+I)/2);case Base6Directions.
Direction.Left:return new Vector3I(F,(D+C)/2,(B+I)/2);case Base6Directions.Direction.Right:return new Vector3I(E,(D+C)/2,(B+I)/2)
;case Base6Directions.Direction.Forward:return new Vector3I((F+E)/2,(D+C)/2,B);case Base6Directions.Direction.Backward:
return new Vector3I((F+E)/2,(D+C)/2,I);default:return new Vector3I((F+E)/2,(D+C)/2,B);}}Vector3D P(ref Vector3D Z,ref Vector3I
n){return Z-Ò.GridIntegerToWorld(n);}public bool l(ref Vector3D Z){Vector3D j=(Ë?Vector3D.Zero:Ä(Ò));Vector3D h=Ì*Å(Ò);
Vector3D g=Ì*Æ(Ò);if(Ì>=0){return(P(ref Z,ref Ç).Dot(j+h)>=0&&P(ref Z,ref È).Dot(j-h)>=0&&P(ref Z,ref É).Dot(j+g)>=0&&P(ref Z,
ref Ê).Dot(j-g)>=0);}else{return(P(ref Z,ref Ç).Dot(j+h)>=0||P(ref Z,ref È).Dot(j-h)>=0||P(ref Z,ref É).Dot(j+g)>=0||P(ref
Z,ref Ê).Dot(j-g)>=0);}}}}class f{public long e;public ő m;public int d;public int Y;public bool X;public bool W;public
IMyProgrammableBlock V;}class U{public GeneralSettings settings;public MyIni R;public string O;public IMyMotorStator Ô;public double
AngleOffsetX;public double LowerLimitX;public double UpperLimitX;public bool HaveLimitX;public double ActualAzimuth;public ǫ Ă;
public Ɇ[]ā;public Į Ā;public double ÿ;public float Ć;public IMyShipController þ;public ITerminalProperty<bool>
WeaponShootProperty;public ITerminalAction WeaponShootAction;public Ƴ ú;public double ù;public ő ø;public bool IsDamaged;public
IMyShipConnector õ;public IMyShipConnector ý;public int Ĉ;public int č;public int ė;public Ƽ ĕ;public double Ĕ;public double ē;long Ē;
Vector3D đ;double Đ=Math.Tan(MathHelperD.ToRadians(Ϝ));long ď;int Ė;Vector3D Ď;Vector3D Č;double ċ;double Ċ;double ĉ;public U(
string á,IMyMotorStator à,IMyMotorStator ñ,IMyTerminalBlock ô,IMyShipController Þ,List<IMyUserControllableGun>Õ,Į Ü,
GeneralSettings Û,Ƴ Ú=null):this(á,à,new List<IMyMotorStator>(new IMyMotorStator[]{ñ}),new List<IMyTerminalBlock>(new IMyTerminalBlock[
]{ô}),Þ,new List<List<IMyUserControllableGun>>(){Õ},Ü,Û,Ú){}public U(string á,IMyMotorStator à,List<IMyMotorStator>ß,List
<IMyTerminalBlock>â,IMyShipController Þ,List<List<IMyUserControllableGun>>Õ,Į Ü,GeneralSettings Û,Ƴ Ú=null){settings=Û;O=
á;þ=Þ;Ā=Ü;Ć=MathHelper.RPMToRadiansPerSecond*(settings.RotorUseLimitSnap?settings.ͻ:settings.ΐ);ú=Ú;R=new MyIni();if(R.
TryParse(à.CustomData)){if(R.ContainsSection(І)){double Ù=R.Get(І,"WeaponInitialSpeed").ToDouble(0);double Ø=R.Get(І,
"WeaponAcceleration").ToDouble(0);double Ö=R.Get(І,"WeaponMaxSpeed").ToDouble(0);double Ý=R.Get(І,"WeaponMaxRange").ToDouble(0);double ä=R.
Get(І,"WeaponSpawnOffset").ToDouble(0);double ì=R.Get(І,"WeaponReloadTime").ToDouble(0);bool ó=R.Get(І,
"WeaponIsCappedSpeed").ToBoolean(false);bool ò=R.Get(І,"WeaponUseSalvo").ToBoolean(false);ÿ=R.Get(І,"TurretPrioritySize").ToDouble(0);if(Ý>0
&&(Ù>0||Ø>0)){Ù=MathHelper.Clamp(Ù,0,1000000000);Ø=MathHelper.Clamp(Ø,0,1000000000);Ö=MathHelper.Clamp(Ö,0,1000000000);if(
Ö==0)Ö=1000000000;Ý=MathHelper.Clamp(Ý,0,1000000000);Ā=new Į(Ù,Ø,Ö,Ý,ä,ì,ó,ò);}}}else{ÿ=0;}if(Õ.Count>0&&Õ[0].Count>0){
WeaponShootProperty=Õ[0][0].GetProperty("Shoot").As<bool>();WeaponShootAction=Õ[0][0].GetActionWithName("ShootOnce");}Ô=à;HaveLimitX=
GetOrSetRotorLimitConfig(Ô,out LowerLimitX,out UpperLimitX);if(!settings.RotorUseLimitSnap){Ă=new ǫ(settings.Ά,settings.Έ,Ć);ȷ(Ô,LowerLimitX,
UpperLimitX);}ā=new Ɇ[ß.Count];for(int Q=0;Q<ß.Count;Q++){Ɇ elevationRotor=new Ɇ();ā[Q]=elevationRotor;elevationRotor.Rotor=ß[Q];
elevationRotor.ɀ=â[Q];double lowerLimitY,upperLimitY;elevationRotor.HaveLimitY=GetOrSetRotorLimitConfig(elevationRotor.Rotor,out
lowerLimitY,out upperLimitY);elevationRotor.LowerLimitY=lowerLimitY;elevationRotor.UpperLimitY=upperLimitY;Ƞ(elevationRotor);if(!
settings.RotorUseLimitSnap){elevationRotor.ȼ=new ǫ(settings.Ά,settings.Έ,Ć);ȷ(elevationRotor.Rotor,lowerLimitY,upperLimitY);}
elevationRotor.Ȼ=Õ[Q];if(Ā.Ƅ){elevationRotor.Ʃ=(int)Math.Ceiling((Ā.Ƈ*ϔ)/Math.Max(elevationRotor.Ȼ.Count,1));}if(elevationRotor.Ȼ!=
null&&elevationRotor.Ȼ.Count>0){elevationRotor.Ⱦ=elevationRotor.Ȼ[0].CubeGrid;if(settings.Φ){elevationRotor.Ƚ=new Vector3I[4
];Vector3I î=new Vector3I();Vector3I í=new Vector3I();foreach(IMyUserControllableGun ê in elevationRotor.Ȼ){î=Vector3I.
Min(î,ê.Position);í=Vector3I.Max(í,ê.Position);}Vector3I j=Base6Directions.GetIntVector(elevationRotor.Ȼ[0].Orientation.
Forward);if(j.X!=0){elevationRotor.Ƚ[0]=new Vector3I(0,î.Y,î.Z);elevationRotor.Ƚ[1]=new Vector3I(0,î.Y,í.Z);elevationRotor.Ƚ[2]
=new Vector3I(0,í.Y,î.Z);elevationRotor.Ƚ[3]=new Vector3I(0,í.Y,í.Z);}else if(j.Y!=0){elevationRotor.Ƚ[0]=new Vector3I(î.
X,0,î.Z);elevationRotor.Ƚ[1]=new Vector3I(î.X,0,í.Z);elevationRotor.Ƚ[2]=new Vector3I(í.X,0,î.Z);elevationRotor.Ƚ[3]=new
Vector3I(í.X,0,í.Z);}else{elevationRotor.Ƚ[0]=new Vector3I(î.X,î.Y,0);elevationRotor.Ƚ[1]=new Vector3I(î.X,í.Y,0);elevationRotor
.Ƚ[2]=new Vector3I(í.X,î.Y,0);elevationRotor.Ƚ[3]=new Vector3I(í.X,í.Y,0);}}else{Vector3I ë=new Vector3I();foreach(
IMyUserControllableGun ê in elevationRotor.Ȼ){ë+=ê.Position;}ë=new Vector3I((int)((float)ë.X/elevationRotor.Ȼ.Count),(int)((float)ë.Y/
elevationRotor.Ȼ.Count),(int)((float)ë.Z/elevationRotor.Ȼ.Count));elevationRotor.Ƚ=new Vector3I[]{ë};}}}if(ā.Length>0){ç(Ô,ā[0],ref
AngleOffsetX);}}public void é(U è){ø=è.ø;Ē=è.Ē;đ=è.đ;ď=è.ď;Ė=è.Ė;Ď=è.Ď;Č=è.Č;ċ=è.ċ;Ċ=è.Ċ;ĉ=è.ĉ;}public void ç(IMyMotorStator à,Ɇ æ,
ref double Ɩ){IMyMotorStator ñ=æ.Rotor;double ȝ=Math.Cos(ñ.Angle);double Ȝ=Math.Sin(ñ.Angle);Vector3D ț=(ñ.WorldMatrix.
Backward*ȝ)+(ñ.WorldMatrix.Left*Ȝ);Vector3D Ț=(ñ.WorldMatrix.Left*ȝ)+(ñ.WorldMatrix.Forward*Ȝ);double Ȥ=æ.Ʉ+Ȱ(æ.ɀ.WorldMatrix.
Forward,ț,Ț);if(Ȥ>=MathHelperD.TwoPi)Ȥ-=MathHelperD.TwoPi;ȝ=Math.Cos(Ȥ);Ȝ=Math.Sin(Ȥ);Vector3D ȣ=(æ.Rotor.WorldMatrix.Backward*
ȝ)+(æ.Rotor.WorldMatrix.Left*Ȝ);ȝ=Math.Cos(à.Angle);Ȝ=Math.Sin(à.Angle);Vector3D Ȣ=(à.WorldMatrix.Backward*ȝ)+(à.
WorldMatrix.Left*Ȝ);Vector3D ȡ=(à.WorldMatrix.Left*ȝ)+(à.WorldMatrix.Forward*Ȝ);Ɩ=-Ȱ(ȣ,Ȣ,ȡ);Ɩ=(Math.Round(Ɩ/MathHelper.PiOver2)%4)*
MathHelper.PiOver2;}public void Ƞ(Ɇ ñ){IMyMotorStator ȟ=ñ.Rotor;double ȝ=Math.Cos(ȟ.Angle);double Ȝ=Math.Sin(ȟ.Angle);Vector3D ț=(
ȟ.WorldMatrix.Backward*ȝ)+(ȟ.WorldMatrix.Left*Ȝ);Vector3D Ț=(ȟ.WorldMatrix.Left*ȝ)+(ȟ.WorldMatrix.Forward*Ȝ);ñ.Ʉ=Ȱ(ñ.ɀ.
WorldMatrix.Forward,ț,Ț);double ș=ȟ.LowerLimitRad;double Ș=ȟ.UpperLimitRad;double ȗ;if(ȟ.LowerLimitDeg==float.MinValue||ȟ.
UpperLimitDeg==float.MaxValue){ȗ=ȟ.Angle+ñ.Ʉ;}else{ȗ=((Ș+ș)*0.5)+ñ.Ʉ;}ȸ(ref ȗ);ȝ=Math.Cos(ȗ);Ȝ=Math.Sin(ȗ);Vector3D Ȟ=(ȟ.WorldMatrix.
Backward*ȝ)+(ȟ.WorldMatrix.Left*Ȝ);Vector3D ȥ=ȟ.WorldMatrix.Up.Cross(Ô.WorldMatrix.Up);ñ.Ɂ=(ȥ.Dot(Ȟ)<0);double ȩ=Ȱ(ȟ.WorldMatrix
.Backward,ñ.Ɂ?-ȥ:ȥ,Ô.WorldMatrix.Up);if(ñ.Ɂ)ȩ=MathHelper.TwoPi-ȩ;ñ.Ʉ=-ȩ-ñ.Ʉ;ñ.Ʉ=(Math.Round(ñ.Ʉ/MathHelper.PiOver2)%4)*
MathHelper.PiOver2;}public double Ȱ(Vector3D ȯ,Vector3D Ȯ,Vector3D ȭ){double Ȭ=Math.Round(Ȯ.Dot(ȯ));if(Ȭ==0){if(ȭ.Dot(ȯ)>0)return
MathHelperD.PiOver2;else return MathHelperD.PiOver2+MathHelperD.Pi;}else{if(Ȭ>0)return 0;else return MathHelperD.Pi;}}public void ȫ
(){Ô.TargetVelocityRad=0f;for(int Q=0;Q<ā.Length;Q++){ā[Q].Rotor.TargetVelocityRad=0f;}}public bool Ȫ(){return(Ô.
IsWorking&&Ô.IsAttached);}public bool Ȩ(Ɇ ñ){return(ñ.Rotor.IsWorking&&ñ.Rotor.IsAttached&&ñ.ɀ.IsFunctional);}public bool Ȩ(){
foreach(Ɇ ñ in ā){if(ñ.Rotor.IsWorking&&ñ.Rotor.IsAttached&&ñ.ɀ.IsFunctional){return true;}}return false;}public Ɇ ȧ(){foreach(
Ɇ ñ in ā){if(ñ.Rotor.IsWorking&&ñ.Rotor.IsAttached&&ñ.ɀ.IsFunctional){return ñ;}}return ā[0];}private bool Ȧ(ő ž,int ĸ,
out Vector3D r,out double ȏ){Vector3D Ȗ=ā[0].ɀ.WorldMatrix.Translation;Vector3D Ȅ;if(ž.Ě!=null){Ȅ=ȍ(ž,ĸ);}else{Ȅ=ž.Ő;}
Vector3D Ę=(ž.ŏ==ĸ?Ȅ:Ȅ+((ĸ-ž.ŏ)*ϕ*ž.ę));Vector3D ŷ=(þ==null?Vector3D.Zero:þ.GetShipVelocities().LinearVelocity);if(Ā.ŝ!=0){Ȗ+=ā[
0].ɀ.WorldMatrix.Forward*Ā.ŝ;}Ę=Ā.Ż(ref Ę,ref ž.ę,ref Ȗ,ref ŷ,ž);if(double.IsNaN(Ę.Sum)){r=Vector3D.Zero;ȏ=0;return false
;}else{r=Ę-Ȗ;ȏ=r.Length();r=(ȏ==0?Vector3D.Zero:r/ȏ);return true;}}private Vector3D ȍ(ő ž,int ĸ){if(ž.Ě?.Count==0||ĸ>ž.Ĥ+
Ϛ||ž.ĥ==null){return ž.Ő;}bool Ȍ=false;if(ď!=ž.Ō){ď=ž.Ō;Ė=0;Ď=Vector3D.TransformNormal(ž.Ő-ž.Ŏ,MatrixD.Transpose(ž.ĥ.
Value));Č=ž.Ě[0].Ĳ;Ȍ=true;}else if(ĉ>1){Ė++;if(Ė>=ž.Ě.Count){Ė=0;}Ď=Č;Č=ž.Ě[Ė].Ĳ;Ȍ=true;}if(Ȍ){ċ=ĸ;double ȋ=(Ď-Č).Length();if
(ȋ<1){Ċ=ϕ;}else{Ċ=ϕ/ȋ*(Đ*(ž.Ŏ-Ô.WorldMatrix.Translation).Length());}ĉ=0;}ĉ+=(ĸ-ċ)*Ċ;ċ=ĸ;return ž.Ŏ+Vector3D.
TransformNormal(Vector3D.Lerp(Ď,Č,ĉ),ž.ĥ.Value);}private bool CheckAndSetAllRotors(double aimAzimuth,double aimElevation,int
currentClock,bool testOnly=false){aimAzimuth+=AngleOffsetX;if(aimAzimuth>=MathHelperD.TwoPi)aimAzimuth-=MathHelperD.TwoPi;double yaw
;if(HaveLimitX){if(!GetClampedCorrectionValue(out yaw,aimAzimuth,ActualAzimuth,LowerLimitX,UpperLimitX)){return false;}}
else{yaw=aimAzimuth-ActualAzimuth;if(yaw>Math.PI)yaw-=MathHelperD.TwoPi;else if(yaw<-Math.PI)yaw+=MathHelperD.TwoPi;}if(!
testOnly){if(Ă==null){Ô.TargetVelocityRad=Math.Min(Ć,Math.Max(-Ć,(float)(yaw*settings.ͽ)));ɘ(Ô,yaw);}else{Ô.TargetVelocityRad=(
float)Ă.Ǻ(ActualAzimuth,aimAzimuth,currentClock);}}for(int Q=0;Q<ā.Length;Q++){Ɇ ElevationRotor=ā[Q];if(!Ȩ(ElevationRotor))
continue;double ȅ;ȅ=ElevationRotor.ȿ;double ȉ=aimElevation;if(ElevationRotor.Ɂ){ȅ=ElevationRotor.Ʉ-ȅ;if(ȅ<-MathHelperD.TwoPi)ȅ+=
MathHelperD.TwoPi;ȉ=ElevationRotor.Ʉ-ȉ;if(ȉ<-MathHelperD.TwoPi)ȉ+=MathHelperD.TwoPi;}else{ȅ+=ElevationRotor.Ʉ;if(ȅ>=MathHelperD.
TwoPi)ȅ-=MathHelperD.TwoPi;ȉ+=ElevationRotor.Ʉ;if(ȉ>=MathHelperD.TwoPi)ȉ-=MathHelperD.TwoPi;}double v;if(ElevationRotor.
HaveLimitY){if(!GetClampedCorrectionValue(out v,ȉ,ȅ,ElevationRotor.LowerLimitY,ElevationRotor.UpperLimitY)){return false;}}else{v=
ȉ-ȅ;if(v>Math.PI)v-=MathHelperD.TwoPi;else if(v<-Math.PI)v+=MathHelperD.TwoPi;}if(!testOnly){if(ElevationRotor.ȼ==null){
ElevationRotor.Rotor.TargetVelocityRad=Math.Min(Ć,Math.Max(-Ć,(float)(v*settings.ͽ)));ɘ(ElevationRotor.Rotor,v);}else{ElevationRotor.
Rotor.TargetVelocityRad=(float)ElevationRotor.ȼ.Ǻ(ȅ,ȉ,currentClock);}}else{break;}}return true;}public bool Ȓ(){long ȕ=
DateTime.Now.Ticks;if(õ==null||ý==null){return false;}if((õ.GetInventory()?.IsItemAt(0)??false)&&(!ý.GetInventory()?.IsItemAt(0)
??false)){return true;}return false;}public bool Ȕ(int ĸ){if(õ==null||ý==null){return true;}if(IsDamaged){ĕ=Ƽ.ƻ;return
true;}else if(!Ȫ()||!Ȩ()){ĕ=Ƽ.ƻ;IsDamaged=true;return true;}if(ĕ==Ƽ.ƻ){ReleaseWeapons(true);ĕ=Ƽ.ƺ;}Ɇ æ=ȧ();double Ȉ;switch(ĕ
){case Ƽ.ƺ:ɍ(ā,æ,Ô);Ȉ=Ĕ;if(Math.Abs(Ȉ-æ.ȿ)>0.0018){CheckAndSetAllRotors(ActualAzimuth,Ȉ,ĸ,false);}else{ĕ=Ƽ.ƹ;}break;case
Ƽ.ƹ:ɍ(ā,æ,Ô);Ȉ=ē;if(Math.Abs(Ȉ-æ.ȿ)>0.0018){CheckAndSetAllRotors(ActualAzimuth,Ȉ,ĸ,false);}else{ĕ=Ƽ.Ƹ;}break;case Ƽ.Ƹ:if(
ý.Status==MyShipConnectorStatus.Connected){ĕ=Ƽ.Ʒ;}else if(ý.Status==MyShipConnectorStatus.Connectable){if(ĸ>=Ĉ+30){ý.
Connect();Ĉ=ĸ;}}break;case Ƽ.Ʒ:if(õ.GetInventory()?.IsItemAt(0)??false){ý.GetInventory()?.TransferItemFrom(õ.GetInventory(),0,0
,true);}ý.Disconnect();õ.Disconnect();ĕ=Ƽ.ƻ;return true;}return false;}public bool IsTargetable(ő ž,int ĸ){if(IsDamaged){
return false;}else if(!Ȫ()||!Ȩ()){IsDamaged=true;return false;}if(ĕ!=Ƽ.ƻ){return false;}Vector3D r;double ȏ;bool ȑ=Ȧ(ž,ĸ,out r
,out ȏ);if(ȑ){Ɇ æ=ȧ();if(HaveLimitX||æ.HaveLimitY){double Ȋ,Ȉ;ɍ(ā,æ,Ô);ɏ(r,Ô,out Ȋ,out Ȉ);if(!CheckAndSetAllRotors(Ȋ,Ȉ,ĸ,
true)){return false;}}if(ú!=null&&ú.Ʋ(æ.ɀ.WorldMatrix.Translation,r)){return false;}if(ȏ<=Ā.Ĭ){return true;}}return false;}
public bool Ȑ(ő ž,int ĸ){if(IsDamaged){ReleaseWeapons(true);ȫ();return false;}else if(!Ȫ()||!Ȩ()){ReleaseWeapons(true);ȫ();
IsDamaged=true;return false;}if(ĕ!=Ƽ.ƻ){return false;}Vector3D r;double ȏ;bool ȑ=Ȧ(ž,ĸ,out r,out ȏ);if(ȑ){Ɇ æ=ȧ();double Ȋ,Ȉ;ɍ(ā,
æ,Ô);ɏ(r,Ô,out Ȋ,out Ȉ);if(CheckAndSetAllRotors(Ȋ,Ȉ,ĸ,false)){if(ȏ<=Ā.Ĭ){bool ɓ=false;foreach(Ɇ ñ in ā){if(ú!=null&&ñ.Ⱦ!=
null&&ñ.Ƚ!=null){bool ɒ=false;for(int Q=0;Q<ñ.Ƚ.Length;Q++){if(ú.Ʋ(ɉ(ñ.Ⱦ,ref ñ.Ƚ[Q]),r)){ɒ=true;break;}}if(ɒ){ReleaseWeapons
(ñ);continue;}}double ɑ=ñ.ɀ.WorldMatrix.Forward.Dot(r);bool ɔ=(ɑ>=settings.Ό);if(!ɔ&&ɑ>=Ϟ&&Ē==ž.Ō){double ɐ=ñ.ɀ.
WorldMatrix.Forward.Dot(đ);double Ɏ=r.Dot(đ);ɔ=(ɐ>=settings.Ό)||(ɑ>=Ɏ&&ɐ>=Ɏ);}if(ɔ){FireWeapons(ñ,ĸ,Ā.Ƅ);ɓ=true;}else{
ReleaseWeapons(ñ);}}if(ɓ){ž.ĝ+=ù;}Ē=ž.Ō;đ=r;return true;}}}ReleaseWeapons();ȫ();return false;}public void ɍ(Ɇ[]ß,Ɇ æ,IMyMotorStator Ɍ)
{ActualAzimuth=Ɍ.Angle;ȸ(ref ActualAzimuth);foreach(Ɇ ñ in ß){if(ñ==æ||Ȩ(ñ)){double ɋ=ñ.ɀ.WorldMatrix.Forward.Dot(Ɍ.
WorldMatrix.Up);ñ.ȿ=MathHelperD.PiOver2-Math.Acos(MathHelper.Clamp(ɋ,-1,1));}}}public void ɏ(Vector3D Ƥ,IMyMotorStator Ɍ,out double
ɞ,out double ɝ){double ɋ=Ƥ.Dot(Ɍ.WorldMatrix.Up);ɝ=MathHelperD.PiOver2-Math.Acos(MathHelper.Clamp(ɋ,-1,1));double ȝ=Math.
Cos(ɝ);Vector3D ɜ=(ȝ==0?Vector3D.Zero:(Ƥ-(Ɍ.WorldMatrix.Up*ɋ))/ȝ);ɞ=Math.Acos(MathHelper.Clamp(Ɍ.WorldMatrix.Backward.Dot(ɜ
),-1,1));if(Ɍ.WorldMatrix.Right.Dot(ɜ)>0)ɞ=MathHelperD.TwoPi-ɞ;}public bool GetClampedCorrectionValue(out double ɚ,double
ɖ,double ə,double ș,double Ș){Ș-=ș;ɖ-=ș;ə-=ș;ȸ(ref Ș);ȸ(ref ɖ);ȸ(ref ə);if(ɖ>=0&&ɖ<=Ș){if(ə>Ș){ə=(ə-Ș<=MathHelperD.TwoPi-
ə?Ș:0);}ɚ=ɖ-ə;return true;}else{ɚ=0;return false;}}public void ɘ(IMyMotorStator ȟ,double ɗ){float ɖ=ȟ.Angle+(float)ɗ;if(ɖ
<-MathHelper.TwoPi||ɖ>MathHelper.TwoPi){ȟ.SetValueFloat("LowerLimit",float.MinValue);ȟ.SetValueFloat("UpperLimit",float.
MaxValue);}else if(ɗ<0){ȟ.UpperLimitRad=ȟ.Angle;ȟ.LowerLimitRad=ɖ;}else if(ɗ>0){ȟ.LowerLimitRad=ȟ.Angle;ȟ.UpperLimitRad=ɖ;}}
public bool GetOrSetRotorLimitConfig(IMyMotorStator rotor,out double lowerLimit,out double upperLimit){double lowerLimitDeg=
double.MinValue;double upperLimitDeg=double.MaxValue;if(settings.RotorUseLimitSnap){MyIni ȱ=new MyIni();ȱ.TryParse(rotor.
CustomData);lowerLimitDeg=ȱ.Get(І,"LowerLimit").ToDouble(lowerLimitDeg);upperLimitDeg=ȱ.Get(І,"UpperLimit").ToDouble(upperLimitDeg
);if(lowerLimitDeg==double.MinValue||upperLimitDeg==double.MaxValue){lowerLimitDeg=MathHelper.Clamp(Math.Round(rotor.
LowerLimitDeg,3),-361,361);upperLimitDeg=MathHelper.Clamp(Math.Round(rotor.UpperLimitDeg,3),-361,361);ȱ.Set(І,"LowerLimit",
lowerLimitDeg);ȱ.Set(І,"UpperLimit",upperLimitDeg);rotor.CustomData=ȱ.ToString();}}else{lowerLimitDeg=MathHelper.Clamp(Math.Round(
rotor.LowerLimitDeg,3),-361,361);upperLimitDeg=MathHelper.Clamp(Math.Round(rotor.UpperLimitDeg,3),-361,361);}if(lowerLimitDeg
<-360)lowerLimitDeg=double.MinValue;if(upperLimitDeg>360)upperLimitDeg=double.MaxValue;if(upperLimitDeg<lowerLimitDeg||
upperLimitDeg-lowerLimitDeg>=360){lowerLimitDeg=double.MinValue;upperLimitDeg=double.MaxValue;}if(lowerLimitDeg>double.MinValue&&
upperLimitDeg<double.MaxValue){lowerLimit=MathHelperD.ToRadians(lowerLimitDeg);upperLimit=MathHelperD.ToRadians(upperLimitDeg);return
true;}else{lowerLimit=double.MinValue;upperLimit=double.MaxValue;return false;}}public void ȸ(ref double ǲ){if(ǲ<0){if(ǲ<=-
MathHelperD.TwoPi)ǲ+=MathHelperD.FourPi;else ǲ+=MathHelperD.TwoPi;}else if(ǲ>=MathHelperD.TwoPi){if(ǲ>=MathHelperD.FourPi)ǲ-=
MathHelperD.FourPi;else ǲ-=MathHelperD.TwoPi;}}public void ȷ(IMyMotorStator ȟ,double ș,double Ș){if(ș==double.MinValue)ȟ.
SetValueFloat("LowerLimit",float.MinValue);else ȟ.LowerLimitRad=(float)ș;if(Ș==double.MaxValue)ȟ.SetValueFloat("UpperLimit",float.
MaxValue);else ȟ.UpperLimitRad=(float)Ș;}public void FireWeapons(Ɇ ñ,int Ƿ,bool ȵ){if(ȵ){if(ñ.Ȼ.Count>0&&ñ.ƽ<=Ƿ){if(ñ.ȃ>=ñ.Ȼ.
Count){ñ.ȃ=0;}IMyUserControllableGun weapon=ñ.Ȼ[ñ.ȃ];WeaponShootAction.Apply(weapon);if(settings.WCAPI!=null){settings.WCAPI.
ToggleWeaponFire(weapon,true,true);ñ.WCSalvoCleanup=true;}ñ.ƽ=Ƿ+ñ.Ʃ;ñ.ȃ++;}}else{if(!ñ.Ⱥ){foreach(IMyUserControllableGun weapon in ñ.Ȼ){
WeaponShootProperty.SetValue(weapon,true);if(settings.WCAPI!=null)settings.WCAPI.ToggleWeaponFire(weapon,true,true);}ñ.Ⱥ=true;}}}public
void ReleaseWeapons(bool ȳ=false){foreach(Ɇ ñ in ā){ReleaseWeapons(ñ,ȳ);}}public void ReleaseWeapons(Ɇ ñ,bool ȳ=false){if(ñ.
Ⱥ||ñ.WCSalvoCleanup||ȳ){foreach(IMyUserControllableGun weapon in ñ.Ȼ){WeaponShootProperty.SetValue(weapon,false);if(
settings.WCAPI!=null)settings.WCAPI.ToggleWeaponFire(weapon,false,true);}ñ.Ⱥ=false;ñ.WCSalvoCleanup=false;}}public Vector3D ɉ(
IMyCubeGrid J,ref Vector3I ɇ){MatrixD ƣ=J.WorldMatrix;return(ƣ.Translation+(ƣ.Right*ɇ.X)+(ƣ.Up*ɇ.Y)+(ƣ.Backward*ɇ.Z));}public class
Ɇ{public IMyMotorStator Rotor;public double Ʉ;public double LowerLimitY;public double UpperLimitY;public bool HaveLimitY;
public bool Ɂ;public IMyTerminalBlock ɀ;public double ȿ;public IMyCubeGrid Ⱦ;public Vector3I[]Ƚ;public ǫ ȼ;public List<
IMyUserControllableGun>Ȼ;public bool Ⱥ;public bool WCSalvoCleanup;public int ȃ;public int ƽ;public int Ʃ;}public enum Ƽ{ƻ,ƺ,ƹ,Ƹ,Ʒ}}class ƶ{
public IMyCubeGrid Ò;public Vector3I Ƶ;public ƶ(IMyCubeGrid J,Vector3I ƥ){Ò=J;Ƶ=ƥ;}}interface Ƴ{bool Ʋ(Vector3 ƥ,Vector3 Ƥ);}
class ƴ:Ƴ{public Vector3I[]ƾ={Vector3I.Left,Vector3I.Right,Vector3I.Up,Vector3I.Down,Vector3I.Forward,Vector3I.Backward};
public MyDynamicAABBTree ǃ;public IMyCubeGrid Ò;public ƴ(){}public IEnumerator<int>Ǉ(ƶ ƨ,List<ƶ>Ƭ,float ư,int ǆ){if(ǆ<=0)ǆ=
1000000000;int ǅ=0;Ò=ƨ.Ò;ǃ=new MyDynamicAABBTree();Vector3 ǈ=new Vector3(0.5f*Ò.GridSize);if(ư!=0f){ǈ+=new Vector3(ư);}Stack<
Vector3I>Ǆ=new Stack<Vector3I>();HashSet<Vector3I>ǂ=new HashSet<Vector3I>();BoundingBox ǁ;Ǆ.Push(ƨ.Ƶ);ǂ.Add(ƨ.Ƶ);ǁ=new
BoundingBox((ƨ.Ƶ*Ò.GridSize)-ǈ,(ƨ.Ƶ*Ò.GridSize)+ǈ);ǃ.AddProxy(ref ǁ,ǁ,0);Vector3I ǀ;while(Ǆ.Count>0){Vector3I ƿ=Ǆ.Pop();for(int Q=0
;Q<6;Q++){ǀ=ƿ+ƾ[Q];if(!ǂ.Contains(ǀ)){ǂ.Add(ǀ);if(Ò.CubeExists(ǀ)){Ǆ.Push(ǀ);ǁ=new BoundingBox((ǀ*Ò.GridSize)-ǈ,(ǀ*Ò.
GridSize)+ǈ);ǃ.AddProxy(ref ǁ,ǁ,0);}}}ǅ++;if(ǅ%ǆ==0){yield return ǅ;}}Dictionary<IMyCubeGrid,ƶ>ƭ=new Dictionary<IMyCubeGrid,ƶ>()
;foreach(ƶ ƪ in Ƭ){if(!ƭ.ContainsKey(ƪ.Ò)){ƭ.Add(ƪ.Ò,ƪ);}}MatrixD ƣ=Ò.WorldMatrix;MatrixD.Transpose(ref ƣ,out ƣ);foreach(
ƶ ƪ in ƭ.Values){if(ƪ.Ò!=Ò){Vector3 Ʊ=Vector3D.TransformNormal((ƪ.Ò.WorldAABB.Min-Ò.WorldMatrix.Translation),ref ƣ);
Vector3 Ƙ=Vector3D.TransformNormal((ƪ.Ò.WorldAABB.Max-Ò.WorldMatrix.Translation),ref ƣ);ǁ=new BoundingBox(Ʊ-ǈ,Ƙ+ǈ);ǃ.AddProxy(
ref ǁ,ǁ,0);}}}public bool Ʋ(Vector3 ƥ,Vector3 Ƥ){MatrixD ƣ=Ò.WorldMatrix;MatrixD.Transpose(ref ƣ,out ƣ);Line ơ=new Line(
Vector3D.TransformNormal(ƥ-Ò.WorldMatrix.Translation,ref ƣ),Vector3D.TransformNormal(Ƥ,ref ƣ)*1000);return Ƣ(ref ơ);}public bool
Ƣ(ref Line ơ){List<MyLineSegmentOverlapResult<BoundingBox>>Ơ=new List<MyLineSegmentOverlapResult<BoundingBox>>(0);ǃ.
OverlapAllLineSegment(ref ơ,Ơ);foreach(MyLineSegmentOverlapResult<BoundingBox>Ʀ in Ơ){if(Ʀ.Element.Extents.LengthSquared()<(ơ.From-Ʀ.Element.
Center).LengthSquared()){return true;}}return false;}}class Ɵ:Ƴ{private int ƞ=40;public IMyCubeGrid Ò;public BoundingBox Ɲ;
double Ɯ;public List<IMyCubeGrid>ƛ;public float ƚ;public bool ƙ;public Ɵ(ƶ ƨ,List<ƶ>Ƭ,float ư,IMyProgrammableBlock Ʈ){Ò=ƨ.Ò;Ɲ=
new BoundingBox(Ò.Min,Ò.Max);Ɯ=1.0/Ò.GridSize;if(ư!=0){ƙ=true;ƚ=Ò.GridSize*0.5f+ư;}else{ƙ=false;ƚ=0f;}Dictionary<
IMyCubeGrid,ƶ>ƭ=new Dictionary<IMyCubeGrid,ƶ>();foreach(ƶ ƪ in Ƭ){if(!ƭ.ContainsKey(ƪ.Ò)){ƭ.Add(ƪ.Ò,ƪ);}}ƛ=new List<IMyCubeGrid>(ƭ.
Count);MatrixD ƣ=Ò.WorldMatrix;MatrixD.Transpose(ref ƣ,out ƣ);foreach(ƶ ƪ in ƭ.Values){if(ƪ.Ò!=Ò){ƛ.Add(ƪ.Ò);}}}public bool Ʋ
(Vector3 ƥ,Vector3 Ƥ){float Ư;if(Ò.WorldAABB.Contains(ƥ)==ContainmentType.Disjoint){double?Ơ=Ò.WorldAABB.Intersects(new
Ray(ƥ,Ƥ));if(Ơ==null){return false;}Ư=(float)Ơ.Value;}else{double?Ơ=Ò.WorldAABB.Intersects(new Ray(ƥ+(Ƥ*5000),-Ƥ));if(Ơ==
null){return false;}Ư=5000f-(float)Ơ.Value;}MatrixD ƣ=Ò.WorldMatrix;MatrixD.Transpose(ref ƣ,out ƣ);Line ơ=new Line(Vector3D.
TransformNormal(ƥ-Ò.WorldMatrix.Translation,ref ƣ)*Ɯ,Vector3D.TransformNormal(ƥ+(Ƥ*Ư)-Ò.WorldMatrix.Translation,ref ƣ)*Ɯ);if(Ƣ(ref ơ)){
return true;}if(ƛ.Count>0){RayD ƫ=new RayD(ƥ,Ƥ);foreach(IMyCubeGrid ƪ in ƛ){if(ƪ.WorldAABB.Intersects(ƫ)!=null){if(ƪ.WorldAABB
.Extents.LengthSquared()<(ƫ.Position-ƪ.WorldAABB.Center).LengthSquared()){return true;}}}}return false;}public bool Ƣ(ref
Line ơ){int Ƨ=Math.Min((int)Math.Ceiling(ơ.Length),ƞ);float ǉ=1.0f/Ƨ*ơ.Length;Vector3I ƥ=new Vector3I((int)Math.Round(ơ.From
.X),(int)Math.Round(ơ.From.Y),(int)Math.Round(ơ.From.Z));for(int Q=1;Q<=Ƨ;Q++){Vector3 ǯ=ơ.From+(ơ.Direction*ǉ*Q);
Vector3I Ǯ=new Vector3I((int)Math.Round(ǯ.X),(int)Math.Round(ǯ.Y),(int)Math.Round(ǯ.Z));if(Ò.CubeExists(Ǯ)){if(Ǯ!=ƥ){if(ƙ){
double ǭ=Math.Min(Math.Abs(ǯ.X-Ǯ.X),Math.Min(Math.Abs(ǯ.Y-Ǯ.Y),Math.Abs(ǯ.Z-Ǯ.Z)));if(ǭ<=ƚ){return true;}}else{return true;}}}
}return false;}}class Ǭ{public long Ō;public Vector3D Ő;public Vector3D ę;}class ǰ{public long Ō;public Vector3D Ő;public
Vector3D ę;public bool ģ;public double Ǫ;public int Ħ;public ǰ(long Ġ){Ō=Ġ;}}class ǫ{const int Ǳ=3;double ǹ;double Ȃ;double Ȁ;
double ǿ;double Ǿ;int ǽ;public ǫ(double Ǽ,double ǻ,double ȁ){ǹ=Ǽ;Ȃ=ǻ;Ȁ=ȁ;}public double Ǻ(double ƿ,double Ǹ,int Ƿ){int Ƕ=Math.
Max(Ƿ-ǽ,1);double ǵ=Ǹ-Ǿ;if(Ƕ<Ǳ){ǵ*=(double)Ǳ/Ƕ;Ƕ=Ǳ;}ǳ(ref ǵ);if(ǿ*ǵ<0){ǿ=(Ȃ*ǵ);}else{ǿ=((1-Ȃ)*ǿ)+(Ȃ*ǵ);}double Ǵ=Ǹ-ƿ+ǿ;ǳ(
ref Ǵ);Ǿ=Ǹ;ǽ=Math.Max(Ƿ,ǽ);return MathHelper.Clamp(Ǵ*ǹ/Ƕ,-Ȁ,Ȁ);}public void ǳ(ref double ǲ){if(ǲ<-Math.PI){ǲ+=MathHelperD.
TwoPi;if(ǲ<-Math.PI)ǲ+=MathHelperD.TwoPi;}else if(ǲ>Math.PI){ǲ-=MathHelperD.TwoPi;if(ǲ>Math.PI)ǲ-=MathHelperD.TwoPi;}}public
void ǩ(){ǽ=0;ǿ=Ǿ=0;}}class Ǩ{public int Ǌ;public double Ǚ;public double ǘ;public double Ǘ;public double ǖ;public double Ǖ;
public IMyGridProgramRuntimeInfo ǔ{get;private set;}public Queue<double>Ǔ=new Queue<double>();public Queue<double>ǚ=new Queue<
double>();public Dictionary<string,ǝ>ǒ=new Dictionary<string,ǝ>();private double ǐ;private double Ǐ;public Ǩ(
IMyGridProgramRuntimeInfo ǎ,int Ǎ,double ǌ){ǔ=ǎ;Ǌ=Ǎ;Ǚ=ǌ;ǐ=6;Ǐ=100.0/(ǔ.MaxInstructionCount==0?50000:ǔ.MaxInstructionCount);}public void ǋ(){ǘ=0;Ǔ
.Clear();Ǘ=0;ǖ=0;ǚ.Clear();Ǖ=0;}public void Ǒ(){double ǎ=ǔ.LastRunTimeMs;ǘ+=(ǎ-ǘ)*Ǚ;Ǔ.Enqueue(ǎ);if(Ǔ.Count>Ǌ)Ǔ.Dequeue()
;Ǘ=Ǔ.Max();}public void ǡ(){double ǧ=ǔ.CurrentInstructionCount;ǖ+=(ǧ-ǖ)*Ǚ;ǚ.Enqueue(ǧ);if(ǚ.Count>Ǌ)ǚ.Dequeue();Ǖ=ǚ.Max()
;}public void Ǧ(StringBuilder ǟ){ǟ.AppendLine($"Avg Runtime = {ǘ:0.0000}ms   ({ǘ*ǐ:0.00}%)");ǟ.AppendLine(
$"Peak Runtime = {Ǘ:0.0000}ms\n");ǟ.AppendLine($"Avg Complexity = {ǖ:0.00}   ({ǖ*Ǐ:0.00}%)");ǟ.AppendLine($"Peak Complexity = {Ǖ:0.00}");}public void ǥ(
string Ǣ){ǝ Ǥ;if(ǒ.ContainsKey(Ǣ)){Ǥ=ǒ[Ǣ];}else{Ǥ=new ǝ();ǒ[Ǣ]=Ǥ;}Ǥ.Ǜ=DateTime.Now.Ticks;}public void ǣ(string Ǣ){ǝ Ǥ;if(ǒ.
TryGetValue(Ǣ,out Ǥ)){long ƿ=DateTime.Now.Ticks;double ǎ=(ƿ-Ǥ.Ǜ)*0.0001;Ǥ.ǜ++;Ǥ.с+=ǎ;Ǥ.Ǜ=ƿ;}}public void Ǡ(StringBuilder ǟ){foreach
(KeyValuePair<string,ǝ>Ǟ in ǒ){double ǎ=(Ǟ.Value.ǜ==0?0:Ǟ.Value.с/Ǟ.Value.ǜ);ǟ.AppendLine($"{Ǟ.Key} = {ǎ:0.0000}ms");}}
public class ǝ{public long ǜ;public double с;public long Ǜ;}}class WcPbApi{private Action<ICollection<MyDefinitionId>>
_getCoreWeapons;private Action<ICollection<MyDefinitionId>>_getCoreStaticLaunchers;private Action<ICollection<MyDefinitionId>>
_getCoreTurrets;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>_getBlockWeaponMap;private Func<long,
MyTuple<bool,int,int>>_getProjectilesLockedOn;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<Sandbox.ModAPI.
Ingame.MyDetectedEntityInfo,float>>_getSortedThreats;private Func<long,int,Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>
_getAiFocus;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>_setAiFocus;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>_getWeaponTarget;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int>_setWeaponTarget;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,int>_fireWeaponOnce;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>_toggleWeaponFire;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,
bool,bool,bool>_isWeaponReadyToFire;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>_getMaxWeaponRange;private
Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>_getTurretTargetTypes;private Action<Sandbox.ModAPI
.Ingame.IMyTerminalBlock,ICollection<string>,int>_setTurretTargetTypes;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>_setBlockTrackingRange;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>_isTargetAligned;private
Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>_canShootTarget;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,long,int,Vector3D?>_getPredictedTargetPos;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>_getHeatLevel;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>_currentPowerConsumption;private Func<MyDefinitionId,float>
_getMaxPower;private Func<long,bool>_hasGridAi;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool>_hasCoreWeapon;private Func<
long,float>_getOptimalDps;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>_getActiveAmmo;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>_setActiveAmmo;private Action<Action<Vector3,float>>_registerProjectileAdded;
private Action<Action<Vector3,float>>_unRegisterProjectileAdded;private Func<long,float>_getConstructEffectiveDps;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>_getPlayerController;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix
>_getWeaponAzimuthMatrix;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>_getWeaponElevationMatrix;public
bool Activate(Sandbox.ModAPI.Ingame.IMyTerminalBlock pbBlock){var dict=pbBlock.GetProperty("WcPbAPI")?.As<Dictionary<string,
Delegate>>().GetValue(pbBlock);return ApiAssign(dict);}public bool ApiAssign(IReadOnlyDictionary<string,Delegate>delegates){if(
delegates==null)return false;AssignMethod(delegates,"GetCoreWeapons",ref _getCoreWeapons);AssignMethod(delegates,
"GetCoreStaticLaunchers",ref _getCoreStaticLaunchers);AssignMethod(delegates,"GetCoreTurrets",ref _getCoreTurrets);AssignMethod(delegates,
"GetBlockWeaponMap",ref _getBlockWeaponMap);AssignMethod(delegates,"GetProjectilesLockedOn",ref _getProjectilesLockedOn);AssignMethod(
delegates,"GetSortedThreats",ref _getSortedThreats);AssignMethod(delegates,"GetAiFocus",ref _getAiFocus);AssignMethod(delegates,
"SetAiFocus",ref _setAiFocus);AssignMethod(delegates,"GetWeaponTarget",ref _getWeaponTarget);AssignMethod(delegates,
"SetWeaponTarget",ref _setWeaponTarget);AssignMethod(delegates,"FireWeaponOnce",ref _fireWeaponOnce);AssignMethod(delegates,
"ToggleWeaponFire",ref _toggleWeaponFire);AssignMethod(delegates,"IsWeaponReadyToFire",ref _isWeaponReadyToFire);AssignMethod(delegates,
"GetMaxWeaponRange",ref _getMaxWeaponRange);AssignMethod(delegates,"GetTurretTargetTypes",ref _getTurretTargetTypes);AssignMethod(delegates
,"SetTurretTargetTypes",ref _setTurretTargetTypes);AssignMethod(delegates,"SetBlockTrackingRange",ref
_setBlockTrackingRange);AssignMethod(delegates,"IsTargetAligned",ref _isTargetAligned);AssignMethod(delegates,"CanShootTarget",ref
_canShootTarget);AssignMethod(delegates,"GetPredictedTargetPosition",ref _getPredictedTargetPos);AssignMethod(delegates,"GetHeatLevel",
ref _getHeatLevel);AssignMethod(delegates,"GetCurrentPower",ref _currentPowerConsumption);AssignMethod(delegates,
"GetMaxPower",ref _getMaxPower);AssignMethod(delegates,"HasGridAi",ref _hasGridAi);AssignMethod(delegates,"HasCoreWeapon",ref
_hasCoreWeapon);AssignMethod(delegates,"GetOptimalDps",ref _getOptimalDps);AssignMethod(delegates,"GetActiveAmmo",ref _getActiveAmmo);
AssignMethod(delegates,"SetActiveAmmo",ref _setActiveAmmo);AssignMethod(delegates,"RegisterProjectileAdded",ref
_registerProjectileAdded);AssignMethod(delegates,"UnRegisterProjectileAdded",ref _unRegisterProjectileAdded);AssignMethod(delegates,
"GetConstructEffectiveDps",ref _getConstructEffectiveDps);AssignMethod(delegates,"GetPlayerController",ref _getPlayerController);AssignMethod(
delegates,"GetWeaponAzimuthMatrix",ref _getWeaponAzimuthMatrix);AssignMethod(delegates,"GetWeaponElevationMatrix",ref
_getWeaponElevationMatrix);return true;}private void AssignMethod<T>(IReadOnlyDictionary<string,Delegate>delegates,string name,ref T field)where
T:class{if(delegates==null){field=null;return;}Delegate del;if(!delegates.TryGetValue(name,out del))throw new Exception(
$"{GetType().Name} :: Couldn't find {name} delegate of type {typeof(T)}");field=del as T;if(field==null)throw new Exception(
$"{GetType().Name} :: Delegate {name} is not type {typeof(T)}, instead it's: {del.GetType()}");}public void GetAllCoreWeapons(ICollection<MyDefinitionId>collection)=>_getCoreWeapons?.Invoke(collection);public void
GetAllCoreStaticLaunchers(ICollection<MyDefinitionId>collection)=>_getCoreStaticLaunchers?.Invoke(collection);public void GetAllCoreTurrets(
ICollection<MyDefinitionId>collection)=>_getCoreTurrets?.Invoke(collection);public bool GetBlockWeaponMap(Sandbox.ModAPI.Ingame.
IMyTerminalBlock weaponBlock,IDictionary<string,int>collection)=>_getBlockWeaponMap?.Invoke(weaponBlock,collection)??false;public
MyTuple<bool,int,int>GetProjectilesLockedOn(long victim)=>_getProjectilesLockedOn?.Invoke(victim)??new MyTuple<bool,int,int>();
public void GetSortedThreats(Sandbox.ModAPI.Ingame.IMyTerminalBlock pBlock,IDictionary<Sandbox.ModAPI.Ingame.
MyDetectedEntityInfo,float>collection)=>_getSortedThreats?.Invoke(pBlock,collection);public MyDetectedEntityInfo?GetAiFocus(long shooter,int
priority=0)=>_getAiFocus?.Invoke(shooter,priority);public bool SetAiFocus(Sandbox.ModAPI.Ingame.IMyTerminalBlock pBlock,long
target,int priority=0)=>_setAiFocus?.Invoke(pBlock,target,priority)??false;public MyDetectedEntityInfo?GetWeaponTarget(Sandbox
.ModAPI.Ingame.IMyTerminalBlock weapon,int weaponId=0)=>_getWeaponTarget?.Invoke(weapon,weaponId);public void
SetWeaponTarget(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,long target,int weaponId=0)=>_setWeaponTarget?.Invoke(weapon,target,
weaponId);public void FireWeaponOnce(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,bool allWeapons=true,int weaponId=0)=>
_fireWeaponOnce?.Invoke(weapon,allWeapons,weaponId);public void ToggleWeaponFire(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,bool on,
bool allWeapons,int weaponId=0)=>_toggleWeaponFire?.Invoke(weapon,on,allWeapons,weaponId);public bool IsWeaponReadyToFire(
Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,int weaponId=0,bool anyWeaponReady=true,bool shootReady=false)=>
_isWeaponReadyToFire?.Invoke(weapon,weaponId,anyWeaponReady,shootReady)??false;public float GetMaxWeaponRange(Sandbox.ModAPI.Ingame.
IMyTerminalBlock weapon,int weaponId)=>_getMaxWeaponRange?.Invoke(weapon,weaponId)??0f;public bool GetTurretTargetTypes(Sandbox.ModAPI.
Ingame.IMyTerminalBlock weapon,IList<string>collection,int weaponId=0)=>_getTurretTargetTypes?.Invoke(weapon,collection,
weaponId)??false;public void SetTurretTargetTypes(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,IList<string>collection,int
weaponId=0)=>_setTurretTargetTypes?.Invoke(weapon,collection,weaponId);public void SetBlockTrackingRange(Sandbox.ModAPI.Ingame.
IMyTerminalBlock weapon,float range)=>_setBlockTrackingRange?.Invoke(weapon,range);public bool IsTargetAligned(Sandbox.ModAPI.Ingame.
IMyTerminalBlock weapon,long targetEnt,int weaponId)=>_isTargetAligned?.Invoke(weapon,targetEnt,weaponId)??false;public bool
CanShootTarget(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,long targetEnt,int weaponId)=>_canShootTarget?.Invoke(weapon,targetEnt,
weaponId)??false;public Vector3D?GetPredictedTargetPosition(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,long targetEnt,int
weaponId)=>_getPredictedTargetPos?.Invoke(weapon,targetEnt,weaponId)??null;public float GetHeatLevel(Sandbox.ModAPI.Ingame.
IMyTerminalBlock weapon)=>_getHeatLevel?.Invoke(weapon)??0f;public float GetCurrentPower(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon)
=>_currentPowerConsumption?.Invoke(weapon)??0f;public float GetMaxPower(MyDefinitionId weaponDef)=>_getMaxPower?.Invoke(
weaponDef)??0f;public bool HasGridAi(long entity)=>_hasGridAi?.Invoke(entity)??false;public bool HasCoreWeapon(Sandbox.ModAPI.
Ingame.IMyTerminalBlock weapon)=>_hasCoreWeapon?.Invoke(weapon)??false;public float GetOptimalDps(long entity)=>_getOptimalDps
?.Invoke(entity)??0f;public string GetActiveAmmo(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,int weaponId)=>
_getActiveAmmo?.Invoke(weapon,weaponId)??null;public void SetActiveAmmo(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,int weaponId,
string ammoType)=>_setActiveAmmo?.Invoke(weapon,weaponId,ammoType);public void RegisterProjectileAddedCallback(Action<Vector3,
float>action)=>_registerProjectileAdded?.Invoke(action);public void UnRegisterProjectileAddedCallback(Action<Vector3,float>
action)=>_unRegisterProjectileAdded?.Invoke(action);public float GetConstructEffectiveDps(long entity)=>
_getConstructEffectiveDps?.Invoke(entity)??0f;public long GetPlayerController(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon)=>
_getPlayerController?.Invoke(weapon)??-1;public Matrix GetWeaponAzimuthMatrix(Sandbox.ModAPI.Ingame.IMyTerminalBlock weapon,int weaponId)=>
_getWeaponAzimuthMatrix?.Invoke(weapon,weaponId)??Matrix.Zero;public Matrix GetWeaponElevationMatrix(Sandbox.ModAPI.Ingame.IMyTerminalBlock
weapon,int weaponId)=>_getWeaponElevationMatrix?.Invoke(weapon,weaponId)??Matrix.Zero;}