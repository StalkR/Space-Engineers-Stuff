// Simple trade store with buttons.
// Call the programmable block with the trade to execute, if enough input items.
// Format: <quantity input> <input item> <quantity output> <output item>
//
// Example: we want button 1 to exchange 100 space credits for 1 uranium ore.
// Configure the button to run the programmable block with arguments:
// 100 MyObjectBuilder_PhysicalObject/SpaceCredit 1 MyObjectBuilder_Ore/Uranium
//
// Other examples:
// 300 MyObjectBuilder_PhysicalObject/SpaceCredit 1000 MyObjectBuilder_Ore/Ice
// 100 MyObjectBuilder_PhysicalObject/SpaceCredit 1 MyObjectBuilder_Ore/Uranium
// 100 MyObjectBuilder_PhysicalObject/SpaceCredit 1 MyObjectBuilder_Ore/Platinum
// 100 MyObjectBuilder_PhysicalObject/SpaceCredit 1 MyObjectBuilder_Ore/Gold

public Program()
{
  Runtime.UpdateFrequency = UpdateFrequency.None;
}

Dictionary<string, long> inputTotals = new Dictionary<string, long>();
Dictionary<string, long> storageTotals = new Dictionary<string, long>();

StringBuilder status = new StringBuilder("", 256);

public void Main(string argument, UpdateType updateSource)
{
  var args = argument.Split(' ');
  if (args.Length != 4) {
    Echo("invalid args, need 4:" + argument);
    return;
  }
  var fromN = Convert.ToInt64(args[0]);
  var from = args[1];
  var toN = Convert.ToInt64(args[2]);
  var to = args[3];

  var input = GridTerminalSystem.GetBlockWithName("Store Input");
  if (input == null) {
    Echo("missing: Store Input");
    return;
  }
  var output = GridTerminalSystem.GetBlockWithName("Store Output");
  if (output == null) {
    Echo("missing: Store Output");
    return;
  }
  var storage = GridTerminalSystem.GetBlockWithName("Store Storage");
  if (storage == null) {
    Echo("missing: Store Storage");
    return;
  }

  inputTotals.Clear();
  totals(input.GetInventory(), inputTotals);
  storageTotals.Clear();
  totals(storage.GetInventory(), storageTotals);
  
  status.Clear();
  trade(fromN, from, toN, to, input, output, storage);
  showLCD(storageTotals, status);
}

public void trade(long fromN, string from, long toN, string to, IMyTerminalBlock input, IMyTerminalBlock output, IMyTerminalBlock storage)
{
  if (!inputTotals.ContainsKey(from)) {
    status.Append("- did not insert " + friendly(from) + "\n");
    return;
  }
  if (!storageTotals.ContainsKey(to)) {
    status.Append("- store out of " + friendly(to) + "\n");
    return;
  }
  var x = inputTotals[from] / fromN;
  var y = storageTotals[to] / toN;
  if (x == 0) {
    status.Append(" - not enough " + friendly(from) + "\n");
    return;
  }
  if (y == 0) {
    status.Append(" - store low on " + friendly(to) + "\n");
    return;
  }
  var f = Math.Min(x, y);
  if (!move(input.GetInventory(), storage.GetInventory(), f * fromN, from))
  {
    status.Append("- error: could not take " + (f * fromN) + " " + friendly(from) + "\n");
    return;
  }
  status.Append("- took " + (f * fromN) + " " + friendly(from) + "\n");
  if (!move(storage.GetInventory(), output.GetInventory(), f * toN, to))
  {
    status.Append("- error: could not sell " + (f * toN) + " " + friendly(to) + "\n");
    return;
  }
  status.Append("- sold " + (f * toN) + " " + friendly(to) + "\n");
}

List<MyInventoryItem> items = new List<MyInventoryItem>();

public Dictionary<string, long> totals(IMyInventory inventory, Dictionary<string, long> r)
{
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

StringBuilder text = new StringBuilder("", 512);

// add this below your own text in the 'Store Storage LCD'
string DELIMITER = new string('-', 20) + "\n\n";

public void showLCD(Dictionary<string, long> totals, StringBuilder status)
{
  var lcd = (IMyTextSurface)GridTerminalSystem.GetBlockWithName("Store LCD");
  if (lcd == null) {
    Echo("missing: Store LCD");
    return;
  }

  // cut after the delimiter
  text.Clear();
  lcd.ReadText(text);
  var p = IndexOf(text, DELIMITER);
  if (p == -1) return;
  p += DELIMITER.Length;
  text.Remove(p, text.Length - p);
  lcd.WriteText(text);

  lcd.WriteText("In store:\n", /*append=*/true);
  foreach (var e in totals)
  {
    lcd.WriteText("- " + e.Value + "x " + friendly(e.Key) + "\n", /*append=*/true);
  }
  lcd.WriteText("Status:\n" + status, /*append=*/true);
}

public bool move(IMyInventory src, IMyInventory dst, long n, string name)
{
  items.Clear();
  src.GetItems(items, e => itemName(e) == name);
  if (items.Count() == 0) return false;
  return src.TransferItemTo(dst, items[0], (int)n);
}

public int IndexOf(StringBuilder sb, string value, int startIndex = 0)
{
  int index;
  int length = value.Length;
  int maxSearchLength = (sb.Length - length) + 1;
  for (int i = startIndex; i < maxSearchLength; i++) {
    if (sb[i] == value[0]) {
      index = 1;
      while ((index < length) && (sb[i + index] == value[index])) index++;
      if (index == length) return i;
    }
  }
  return -1;
}

public string friendly(string item)
{
  var p = item.IndexOf("/");
  return p == -1 ? item : item.Substring(p+1);
}
