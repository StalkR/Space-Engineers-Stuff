/*
 * Production Unclogger v1.4 (StarCpt)
 * 
 * empties assemblers and refineries to designated cargos.
 */

//case sensitive
const string outputCargoGroup = "Output Cargos";

//60 ticks = 1 second
const double runInterval = 120;

//halts script execution if over this runtime to cool down
const double runtimeLimit = 0.05;

//do not touch anything under here//

readonly List<IMyTerminalBlock> cargos = new List<IMyTerminalBlock>();
readonly List<IMyAssembler> assemblers = new List<IMyAssembler>();
readonly List<IMyRefinery> refineries = new List<IMyRefinery>();

readonly DateTime bootTime;
//60 ticks = 1 second
int globalTimer = 0;
int managedAssemblerNum = 0;
int managedRefineryNum = 0;

const string programName = "Production Uncloggr";
const string versionInfo = "1.4";

public Program()
{
    bootTime = DateTime.UtcNow;

    Runtime.UpdateFrequency = UpdateFrequency.Update1 | UpdateFrequency.Update100;

    pbLCD = Me.GetSurface(0);
    pbLCD.ContentType = ContentType.TEXT_AND_IMAGE;
    pbLCD.Font = "DEBUG";
    pbLCD.FontSize = 1f;
    pbLCD.FontColor = Color.White;
    pbLCD.BackgroundColor = Color.Black;

    UpdateBlocks();
}

void UpdateBlocks()
{
    cargos.Clear();
    assemblers.Clear();
    refineries.Clear();

    try
    {
        GridTerminalSystem.GetBlockGroupWithName(outputCargoGroup).GetBlocksOfType(cargos, c => c.HasInventory && c.IsSameConstructAs(Me));
    }
    catch
    {
        throw new Exception($"No cargo blocks in \"{outputCargoGroup}\" group detected!");
    }

    GridTerminalSystem.GetBlocksOfType(assemblers, b => b.IsSameConstructAs(Me));
    GridTerminalSystem.GetBlocksOfType(refineries, b => b.IsSameConstructAs(Me));
}

public void Main(string argument, UpdateType updateSource)
{
    RuntimeInfo();

    globalTimer++;
    if (globalTimer % 600 == 0)
    {
        UpdateBlocks();
    }

    if (globalTimer % runInterval == 0 && averageRuntimeMs.Average() < runtimeLimit)
    {
        if (cargos.Count > 0)
        {
            //makes sure the script doesn't try to move items to a nonexistant container
            cargos.RemoveAll(c => c.Closed);

            if (assemblers.Count > 0)
            {
                IMyAssembler assembler = assemblers[managedAssemblerNum];
                if (assembler.Closed)
                {
                    assemblers.Remove(assembler);
                }
                else
                {
                    InvUtils.EmptyProdBlock(assembler.GetInventory(1), cargos);
                    managedAssemblerNum++;
                }

                if (managedAssemblerNum >= assemblers.Count)
                {
                    managedAssemblerNum = 0;
                }
            }
            else if (assemblers.Count <= 0)
            {
                optionalInfo.AppendLine("0 Assemblers Detected!");
            }

            if (refineries.Count > 0)
            {
                IMyRefinery refinery = refineries[managedRefineryNum];
                if (refinery.Closed)
                {
                    refineries.Remove(refinery);
                }
                else
                {
                    InvUtils.EmptyProdBlock(refinery.GetInventory(1), cargos);
                    managedRefineryNum++;
                }

                if (managedRefineryNum >= refineries.Count)
                {
                    managedRefineryNum = 0;
                }
            }
            else if (refineries.Count <= 0)
            {
                optionalInfo.AppendLine("0 Refineries Detected!");
            }
        }

        PbOutput();
    }
}

public static class InvUtils
{
    //Program program = new Program();
    public static void EmptyProdBlock(IMyInventory prodInv, List<IMyTerminalBlock> cargoList)
    {
        if ((float)prodInv.CurrentVolume / (float)prodInv.MaxVolume > 0.25)
        {
            var items = new List<MyInventoryItem>();
            prodInv.GetItems(items);
            foreach (var item in items)
            {
                foreach (var cargo in cargoList)
                {
                    var cargoInv = cargo.GetInventory();
                    if (prodInv.TransferItemTo(cargoInv, item, item.Amount))
                    {
                        break;
                    }
                }
            }
        }
    }
}

public void HandleArgs(string argument)
{
    string[] arg = argument.Split(' ');

}

private readonly StringBuilder pbOut = new StringBuilder();
private readonly StringBuilder optionalInfo = new StringBuilder();
readonly IMyTextSurface pbLCD;

private void PbOutput()
{
    pbOut.AppendLine($"{programName} v{versionInfo} | Avg: {averageRuntimeMs.Average():f4}");
    TimeSpan uptime = DateTime.UtcNow - bootTime;
    pbOut.AppendLine($"Uptime: {uptime:hh\\:mm\\:ss\\.ff}\n");

    if (assemblers.Count + refineries.Count == 0)
    {
        pbOut.AppendLine("No assemblers or refineries detected!");
    }

    pbOut.Append(optionalInfo);

    pbOut.AppendLine("\n-- Detected Blocks --");
    pbOut.AppendLine($"{cargos.Count} Cargo Container{(cargos.Count != 1 ? "s" : "")} in \"{outputCargoGroup}\" group");
    pbOut.AppendLine($"{assemblers.Count} Assembler{(assemblers.Count != 1 ? "s" : "")} / Checking #{managedAssemblerNum + 1}");
    pbOut.AppendLine($"{refineries.Count} Refiner{(refineries.Count != 1 ? "ies" : "y")} / Checking #{managedRefineryNum + 1}");

    pbOut.AppendLine("\n-- Runtime Information --");
    pbOut.AppendLine($"Last Runtime: {Runtime.LastRunTimeMs:f4}");
    pbOut.AppendLine($"Average Runtime: {averageRuntimeMs.Average():f4}");
    pbOut.AppendLine($"Max Runtime: {maxRuntimeMs:f4}");

    pbOut.AppendLine("\nWritten by StarCpt");

    Echo(pbOut.ToString());
    pbLCD.WriteText(pbOut);

    pbOut.Clear();
    optionalInfo.Clear();
}

private readonly List<double> averageRuntimeMs = new List<double>();
private double maxRuntimeMs = 0;
private ushort rtCounter = 0;
private const ushort resetInterval = 600;

private void RuntimeInfo()
{
    if (averageRuntimeMs.Count >= resetInterval)
    {
        averageRuntimeMs.RemoveAt(0);
        averageRuntimeMs.Add(Runtime.LastRunTimeMs);
    }
    else averageRuntimeMs.Add(Runtime.LastRunTimeMs);

    if (Runtime.LastRunTimeMs > maxRuntimeMs)
    {
        maxRuntimeMs = Runtime.LastRunTimeMs;
    }

    if (rtCounter >= resetInterval)
    {
        maxRuntimeMs = 0;
        rtCounter = 0;
    }

    rtCounter++;
}
