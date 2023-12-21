// Simple automatic trade store.
// It watches the container every 100 ticks and as soon as
// there's enough for a given trade, executes it: moving item
// from input to storage, then from storage to output.

public Program()
{
  Runtime.UpdateFrequency = UpdateFrequency.Update100;
}

List<Trade> trades = new List<Trade>{
  // MyObjectBuilder_Ore/
  // MyObjectBuilder_Ingot/
  // MyObjectBuilder_Component/
  {new Trade(2, "MyObjectBuilder_Ore/Gold", 1, "MyObjectBuilder_Ore/Platinum")},
  {new Trade(2, "MyObjectBuilder_Ore/Platinum", 1, "MyObjectBuilder_Ore/Uranium")},
};

Dictionary<string, long> inputTotals = new Dictionary<string, long>();
Dictionary<string, long> storageTotals = new Dictionary<string, long>();

public void Main(string argument, UpdateType updateSource)
{
  var input = GridTerminalSystem.GetBlockWithName("Store Input");
  var output = GridTerminalSystem.GetBlockWithName("Store Output");
  var storage = GridTerminalSystem.GetBlockWithName("Store Storage");

  inputTotals.Clear();
  totals(input.GetInventory(), inputTotals);
  storageTotals.Clear();
  totals(storage.GetInventory(), storageTotals);

  showLCD(storageTotals, (IMyTextSurface)GridTerminalSystem.GetBlockWithName("Store Storage LCD"));

  foreach (var trade in trades)
  {
    if (!inputTotals.ContainsKey(trade.From) || !storageTotals.ContainsKey(trade.To)) continue;
    var x = inputTotals[trade.From] / trade.FromN;
    var y = storageTotals[trade.To] / trade.ToN;
    var f = Math.Min(x, y);
    if (f == 0) continue;
    if (!move(input.GetInventory(), storage.GetInventory(), f * trade.FromN, trade.From))
    {
      Echo("ERROR: import " + (f * trade.FromN) + " " + trade.From);
      continue;
    }
    Echo("OK: imported " + (f * trade.FromN) + " " + trade.From);
    if (!move(storage.GetInventory(), output.GetInventory(), f * trade.ToN, trade.To))
    {
      Echo("ERROR: export " + (f * trade.ToN) + " " + trade.To);
      continue;
    }
    Echo("OK: exported " + (f * trade.ToN) + " " + trade.To);
    Echo("trade successful!");
  }
}

List<MyInventoryItem> items = new List<MyInventoryItem>();

public Dictionary<string, long> totals(IMyInventory inventory, Dictionary<string, long> r) {
  items.Clear();
  inventory.GetItems(items);
  foreach (var e in items)
  {
    r[itemName(e)] = (r.ContainsKey(itemName(e)) ? r[itemName(e)] : 0) + (int)float.Parse(e.Amount.ToString());
  }
  return r;
}

public string itemName(MyInventoryItem item)
{
  return item.Type.TypeId + "/" + item.Type.SubtypeId;
}

List<string> storageList = new List<string>();

public void showLCD(Dictionary<string, long> totals, IMyTextSurface lcd) {
  storageList.Clear();
  foreach (var e in totals)
  {
    storageList.Add("- " + e.Value + "x " + e.Key);
  }
  lcd.ContentType = ContentType.TEXT_AND_IMAGE;
  lcd.FontSize = 0.5f;
  lcd.Alignment = VRage.Game.GUI.TextPanel.TextAlignment.LEFT;
  lcd.WriteText("Available for trade:\n" + string.Join("\n", storageList));
}

public bool move(IMyInventory src, IMyInventory dst, long n, string name)
{
  items.Clear();
  src.GetItems(items, e => itemName(e) == name);
  if (items.Count() == 0) return false;
  return src.TransferItemTo(dst, items[0], (int)n);
}

}

public class Trade {
  public Trade(long fromN, string from, long toN, string to) {
    From = from;
    FromN = fromN;
    To = to;
    ToN = toN;
  }
  public string From;
  public long FromN;
  public string To;
  public long ToN;
// } Deliberately remove the closing brace of the last extension class, because Space Engineers will add it back in

