// nice try but it doesn't work ;)

public Program() {
    Runtime.UpdateFrequency = UpdateFrequency.Update10;
}

public void Main(string argument, UpdateType updateSource) {
    private List<IMyBeacon> myBeacons = new List<IMyBeacon>();
    GridTerminalSystem.GetBlocksOfType(myBeacons, block => block.IsSameConstructAs(Me));
    foreach (var block in myBeacons) {
        block.Radius = 0;
        beacon.Enabled = false;
    }
    Echo("Runtime: " + Math.Round(Runtime.LastRunTimeMs, 4) + "ms");
}
