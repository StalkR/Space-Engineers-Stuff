// Simple dispenser script.
// Configure connector to throw out, but not collect all.
// Configure button to run programmable block.

public Program()
{
  Runtime.UpdateFrequency = UpdateFrequency.None;
}

public void Main(string argument, UpdateType updateSource)
{
  var cargo = GridTerminalSystem.GetBlockWithName("Small Cargo Container").GetInventory(0);
  var connector = GridTerminalSystem.GetBlockWithName("Connector").GetInventory(0);
  cargo.TransferItemTo(connector, 0, null, true, 1);
}
