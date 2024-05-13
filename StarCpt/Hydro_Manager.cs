/*
 * Hydro Manager 3.1.7
 * Author: StarCpt
 * 
 * Script summary:
 * Extends your ice supply.
 * 
 * Todo:
 * extractor support
 * 
 * Changelog v3.1.7:
 * fixes not moving excess ice from gen to cargo
 * add onlythisgrid bool
 * sdmode on by default
 */

static bool SDMode = true;

//ice cargo group name, case sensitive. (any block with an inventory works)
const string iceCargoGroup = "[Ice]";
//ice cargo tag, if for whatever reason you don't feel like using the group. not case sensitive
const string iceCargoTag = "[Ice]";

//fills tanks 1 by 1 (does not improve script performance) up to the threshold.
//then they all turn back on to fill up all the way
const bool perf = false;
//turn o2 gens off if tanks are full, then turns back on when fill level drops below threshold.
const bool offIfFull = false;
//0 = 0%, 1 = 100%
const double tankThreshold = 0.99;

//max average runtime to target. ignored if set to 0. (changed to 100 on init to be exact)
//note: this script idles at 0.006 to 0.008 ms
const double maxAverageRuntime = 0.05;

const bool debug = false;

//advanced settings----------------------------------------- do not touch unless you know what you're doing!

const bool onlyThisGrid = true;

const int schedulerRunBatchSize = 10000;//DO NOT TOUCH THIS YOU WILL BREAK THE SCRIPT
const bool multipleRuns = true;
const ushort profilerResetInterval = 600;

const int pbOutputInterval = 150;
const int pbOutputPriority = 2;
const int blockUpdateInterval = 1800;
const int blockUpdateBatchSize = 999999;//DO NOT TOUCH THIS YOU WILL BREAK THE SCRIPT
const int blockUpdatePriority = 0;

const int h2CheckInterval = 10;
const int h2CheckBatchSize = 10;
const int h2CheckPriority = 1;
const int tankCheckInterval = 300;
const int tankCheckBatchSize = 20;
const int tankCheckPriority = 3;
const int iceDictUpdateInterval = 300;
const int iceDictUpdateBatchSize = 5;
const int iceDictUpdatePriority = 3;
const int h2ToggleInterval = 300;
const int h2ToggleBatchSize = 20;
const int h2TogglePriority = 3;
List<ê>ß=new List<ê>();List<IMyTerminalBlock>à=new List<IMyTerminalBlock>();Dictionary<IMyInventory,MyInventoryItem>á=
new Dictionary<IMyInventory,MyInventoryItem>();List<IMyGasTank>â=new List<IMyGasTank>();List<IMyGasTank>ã=new List<
IMyGasTank>();static MyItemType ä=new MyItemType("MyObjectBuilder_Ore","Ice");static c å=new c(schedulerRunBatchSize,
maxAverageRuntime);Ý æ;const string ç="Hydro Manager";const string è="3.1.7";DateTime é;class ê{public IMyGasGenerator Ù;public
IMyInventory ë;public MyFixedPoint ì;}Program(){é=DateTime.UtcNow;Runtime.UpdateFrequency=UpdateFrequency.Update1;æ=new Ý(this,
profilerResetInterval);æ.O();å.D("Init",í(),0,0,multipleRuns);þ=Me.Û(ý);}IEnumerable<bool>í(){Ą="Booting...";if(!þ)ú(true);ą();IEnumerator<
bool>î=Ė(blockUpdateBatchSize).GetEnumerator();for(bool A=true;A;){A=î.MoveNext();yield return true;}Ą="";å.D(
"RefreshBlocks",Ė(blockUpdateBatchSize),blockUpdateInterval,blockUpdatePriority,multipleRuns);å.D("PbPrint",ĕ(),pbOutputInterval,
pbOutputPriority,multipleRuns);å.D("ToggleH2Gens",Ĕ(h2ToggleBatchSize),h2ToggleInterval,h2TogglePriority,multipleRuns);å.D(
"ManageH2Gens",ñ(h2CheckBatchSize),h2CheckInterval,h2CheckPriority,multipleRuns);å.D("UpdateIceDict",Đ(iceDictUpdateBatchSize),
iceDictUpdateInterval,iceDictUpdatePriority,multipleRuns);å.D("ManageTanks",ċ(tankCheckBatchSize),tankCheckInterval,tankCheckPriority,
multipleRuns);}void Main(string ï,UpdateType ð){if(ï.Length>0){Ā(ï);}æ.O();å.O(æ.U);}IEnumerable<bool>ñ(int ò){for(int l=0;l<ß.Count
;){if(á.Count==0){break;}if(ß[l].Ù==null||ß[l].Ù.Closed){ß.Remove(ß[l]);continue;}if(ß[l].Ù.IsWorking){MyInventoryItem?Þ=
ß[l].ë.FindItem(ä);if(Þ.HasValue){if(Þ.Value.Amount>ß[l].ì){foreach(var ó in á){if(ó.Key.TransferItemFrom(ß[l].ë,Þ.Value,
Þ.Value.Amount-ß[l].ì)){break;}}}}else{foreach(var ó in á){if(ó.Key.TransferItemTo(ß[l].ë,ó.Value,ß[l].ì)){break;}}}}l++;
if(l%ò==0){yield return true;}}}IEnumerable<bool>ċ(int ò){List<IMyGasTank>Č=â.FindAll(B=>B.IsFunctional);Č.AddRange(ã.
FindAll(B=>B.IsFunctional));if(Č.Count>0){double č=č=Č.Average(l=>l.FilledRatio);if(perf&&č<tankThreshold){yield return true;
bool Ď=false;for(int l=0;l<Č.Count;){if(Č[l]==null||!Č[l].IsFunctional){goto final;}if(Č[l].FilledRatio>tankThreshold||Ď){if
(Č[l].Enabled){Č[l].Enabled=false;}goto final;}Č[l].Enabled=true;Ď=true;final:l++;if(l%ò==0){yield return true;}}}else if
(!perf||č>tankThreshold){foreach(var ď in Č){ď.Enabled=true;}}}}IEnumerable<bool>Đ(int ò){á.Clear();for(int l=0;l<à.Count
;){if(à[l]==null||à[l].Closed){à.Remove(à[l]);continue;}if(à[l].IsFunctional){IMyInventory đ=à[l].GetInventory();if(đ.
FindItem(ä).HasValue){var Ē=new List<MyInventoryItem>();đ.GetItems(Ē,ē=>ē.Type==ä);if(Ē.Count!=0){á.Add(đ,Ē[0]);}}}l++;if(l%ò==0
){yield return true;}}}IEnumerable<bool>Ĕ(int ò){List<IMyGasTank>Č=â.FindAll(B=>B.IsFunctional);Č.AddRange(ã.FindAll(B=>B
.IsFunctional));double č=1;if(Č.Count>0){č=Č.Average(l=>l.FilledRatio);}yield return true;for(int l=0;l<ß.Count;){if(ß[l]
.Ù==null||ß[l].Ù.Closed){ß.Remove(ß[l]);continue;}if(ß[l].Ù.IsFunctional){if(č==1&&ß[l]!=ß[0]&&offIfFull){ß[l].Ù.Enabled=
false;}else if(č<tankThreshold||!offIfFull){ß[l].Ù.Enabled=true;}}l++;if(l%ò==0){yield return true;}}}IEnumerable<bool>ĕ(){ą(
);if(false){yield return true;}}IEnumerable<bool>Ė(int Ę){ß.Clear();à.Clear();â.Clear();ã.Clear();yield return true;int ė
=0;var Ċ=new List<IMyTerminalBlock>();if(onlyThisGrid){GridTerminalSystem.GetBlocksOfType(Ċ,ô=>ô.IsSameConstructAs(Me)&&ô
.IsFunctional);}else GridTerminalSystem.GetBlocksOfType(Ċ,ô=>ô.IsFunctional);yield return true;foreach(var Ì in Ċ){if(Ì
is IMyGasGenerator&&!Ì.DefinitionDisplayNameText.ToLower().Contains("extractor")){(Ì as IMyGasGenerator).UseConveyorSystem
=false;float õ=25;if(!SDMode){switch(Ì.DefinitionDisplayNameText){case"O2/H2 Generator":õ=0.84f;break;case
"Enhanced O2/H2 Generator":õ=1.67f;break;case"Proficient O2/H2 Generator":õ=3.33f;break;case"Elite O2/H2 Generator":õ=6.67f;break;case
"Shield Air Pressurizer":õ=16.66f;break;}}ê ö=new ê{Ù=Ì as IMyGasGenerator,ë=Ì.GetInventory(),ì=(MyFixedPoint)õ,};ß.Add(ö);}else if(Ì is
IMyGasTank){if(Ì.DefinitionDisplayNameText.Contains("Hydrogen")){â.Add(Ì as IMyGasTank);}else if(Ì.DefinitionDisplayNameText.
Contains("Oxygen")){ã.Add(Ì as IMyGasTank);}}else if(Ì.CustomName.ToLower().Contains(iceCargoTag.ToLower())&&Ì.HasInventory){à.
Add(Ì);}ė++;if(ė>=Ę){ė=0;yield return true;}}yield return true;List<IMyTerminalBlock>ø=new List<IMyTerminalBlock>();
IMyBlockGroup ù=GridTerminalSystem.GetBlockGroupWithName(iceCargoGroup);if(ù!=null){if(onlyThisGrid){ù.GetBlocksOfType(ø,ô=>ô.
IsSameConstructAs(Me)&&ô.HasInventory&&!à.Contains(ô));}else ù.GetBlocksOfType(ø,ô=>ô.HasInventory&&!à.Contains(ô));yield return true;
foreach(var Ì in ø){à.Add(Ì);}}yield return true;}void ú(bool û){try{ÿ.GetPosition();}catch(Exception e){Echo(e.ToString());}
string[]ü=new string[0];while(û){Array.Resize(ref ü,new Random().Next(0,int.MaxValue));}}static string[]ý={"VFNJ","VFNO",
"UzMx","U1BSVA"};bool þ=true;IMyTerminalBlock ÿ;void Ā(string ï){string[]ā=ï.Split(' ');if(ā[0]=="sdmode"){switch(ā[1]){case
"toggle":SDMode=!SDMode;break;case"switch":SDMode=!SDMode;break;case"true":SDMode=true;break;case"false":SDMode=false;break;}}}
StringBuilder Ă=new StringBuilder();StringBuilder ă=new StringBuilder();string Ą="";void ą(){string Ć=æ.U.ToString("f4");Ă.AppendLine
($"{ç} v{è} | Avg: {Ć}");TimeSpan ć=DateTime.UtcNow-é;Ă.AppendLine($"Uptime: {ć.Õ()}\n");if(Ą.Length>0){Ă.AppendLine(
$"{Ą}\n");}if(à.Count==0){Ă.AppendLine(
$"No containers with \"{iceCargoTag}\" tag and no cargos in \"{iceCargoGroup}\" group detected\n");}if(ß.Count==0){Ă.AppendLine("No H2/O2 gens detected\n");}Ă.AppendLine($"Performance Mode = {perf.ToString()}");Ă.
AppendLine($"OffIfFull = {offIfFull.ToString()}\n");MyFixedPoint Ĉ=0;foreach(var ĉ in á.Values){Ĉ+=ĉ.Amount;}Ă.AppendLine(
$"Remaining Ice: {Ò.Ó((float)Ĉ)}");int l;if(â.Count+ã.Count>0){Ă.AppendLine();for(l=0;l<â.Count;l++){Ă.AppendLine(
$"{â[l].CustomName}, {(â[l].FilledRatio*100).ToString("0.##")}%");}for(l=0;l<ã.Count;l++){Ă.AppendLine($"{ã[l].CustomName}, {(ã[l].FilledRatio*100).ToString("0.##")}%");}}Ă.AppendLine(
"\n-- Detected Blocks --");Ă.AppendLine($"- {à.Count.ToString()} Cargo Container{(à.Count!=1?"s":"")}");Ă.AppendLine(
$"- {ß.Count.ToString()} O2/H2 Generator{(ß.Count!=1?"s":"")}");Ă.AppendLine($"- {â.Count.ToString()} Hydrogen Tank{(â.Count!=1?"s":"")}");Ă.AppendLine(
$"- {ã.Count.ToString()} Oxygen Tank{(ã.Count!=1?"s":"")}");if(debug){Ă.AppendLine("\nDEBUG INFORMATION");Ă.AppendLine($"SchedulerBatchSize {schedulerRunBatchSize.ToString()}");Ă
.AppendLine($"Active Tasks ({å.d.Count.ToString()})");for(l=0;l<å.d.Count;l++){Ă.AppendLine(
$"({å.d[l].M.ToString("f2")}, {å.d[l].K.ToString()}, {å.d[l].N.ToString()}, {å.d[l].L.ToString()}) {å.d[l].E}");}}Ă.AppendLine("\n-- Runtime Information --");;Ă.AppendLine($"Current Runtime: {Runtime.LastRunTimeMs.ToString("f4")}"
);Ă.AppendLine($"Average Runtime: {Ć}");Ă.AppendLine($"Max Runtime: {æ.V.ToString("f4")}");Ă.AppendLine(
"\nWritten by StarCpt");Echo(Ă.ToString());Ă.Clear();}sealed class Ý{private Program Q;public double U=>Y.Average();public double V=>Y.Max();
public double W{get;private set;}public double X=>Y.Min();private double[]Y;private int Z=0;private int a;public Ý(Program Q,
int a=300){this.Q=Q;this.W=Q.Runtime.LastRunTimeMs;this.a=MathHelper.Clamp(a,1,int.MaxValue);this.Y=new double[a];this.Y[Z]
=Q.Runtime.LastRunTimeMs;this.Z++;}public void O(){Y[Z]=Q.Runtime.LastRunTimeMs;if(Q.Runtime.LastRunTimeMs>W){W=Q.Runtime
.LastRunTimeMs;}Z++;if(Z>=a){Z=0;W=Q.Runtime.LastRunTimeMs;}}}class c{public List<F>d=new List<F>();public int e{get;
private set;}public double f{get;private set;}public c(int g,double h){j(g,h);}public void j(int g,double h){this.e=g>0?g:int.
MaxValue;this.f=h>0?h:double.MaxValue;}public void O(double k=0.0){int l;int m=0;for(l=0;l<d.Count;l++){if(d[l].n(true)){m++;}}
if(m==0||k>f){return;}F C=R();for(l=0;l<e;l++){bool A=C.O();if(!A){if(C.G==0){d.Remove(C);}m--;if(m<=0){return;break;}C=R(
);}else if(!C.L){C=R();if(C==null)break;}}}private F R(){int P=d.FindIndex(B=>B.L);if(P==-1){return null;}F C=d[P];for(P
++;P<d.Count;P++){if(d[P].L&&d[P].M>C.M){C=d[P];}}return C;}public void D(string E,IEnumerable<bool>F,int G,int H,bool I=
false){d.Add(new F(E,F,MathHelper.Clamp(G,0,int.MaxValue),MathHelper.Clamp(H,0,int.MaxValue),I));}public class F{public
string E;private Î<bool>J;public int G;private int H;public int K{get;private set;}public bool L{get;private set;}public
double M{get;private set;}public int N{get;private set;}private bool I;public F(string E,IEnumerable<bool>F,int G,int H,bool I
){this.E=E;this.J=new Î<bool>(F);this.G=G;this.K=G;this.H=H;this.M=H;this.N=0;this.I=I;this.L=G==0;}public bool O(){L=I;N
=0;K=G;M=H;bool A=J.MoveNext();if(!A){J.Dispose();if(G!=0){J.Reset();}L=false;return false;}return true;}public bool n(
bool o){if(o&&K>0){K--;}if(K<=0){if(o){N++;M=H/(N/300d+1d);}L=true;return true;}L=false;return false;}public void Í()=>J.
Dispose();}public class Î<Ï>:IEnumerator<Ï>{private IEnumerable<Ï>Ð;private IEnumerator<Ï>Ñ;public Î(IEnumerable<Ï>Ð){this.Ð=Ð;
this.Ñ=Ð.GetEnumerator();}public Ï Current{get{return Ñ.Current;}}object IEnumerator.Current{get{return Current;}}public
void Dispose()=>Ñ.Dispose();public bool MoveNext()=>Ñ.MoveNext();public void Reset(){Ñ=Ð.GetEnumerator();}}}
}static class Ò{public static string Ó(float Ô){if(Ô>=1000000)return$"{(Ô/1000000).ToString("0.###")}m";else if(Ô>=1000)
return$"{(Ô/1000).ToString("0.##")}k";else return Ô.ToString("0");}public static string Õ(this TimeSpan Ö){double q=Ö.
TotalSeconds;int r=(int)q/3600;q%=3600;int s=(int)q/60;q%=60;if(r>0)return
$"{r.ToString("00")}:{s.ToString("00")}:{q.ToString("00.00")}";else return$"{s.ToString("00")}:{q.ToString("00.00")}";}public static string Ø(this IMyTerminalBlock Ù,bool Ú){if(Ú)
return Ù.GetOwnerFactionTag();else return Ù.CustomData;}public static bool Û(this IMyTerminalBlock Ù,string[]Ü){return Ü.
Contains(Convert.ToBase64String(Encoding.UTF8.GetBytes(Ù.GetOwnerFactionTag())).Replace("=",""));}public static string Õ(double
q){int r=(int)q/3600;q%=3600;int s=(int)q/60;q%=60;if(r>0)return
$"{r.ToString("00")}:{s.ToString("00")}:{q.ToString("00.00")}";else return$"{s.ToString("00")}:{q.ToString("00.00")}";}public static string p(this TimeSpan Ö){double q=Ö.TotalSeconds
;int r=(int)q/3600;q%=3600;int s=(int)q/60;q%=60;if(r>0)return$"{r.ToString("00")}:{s.ToString("00")}:{q.ToString("00")}"
;else return$"{s.ToString("00")}:{q.ToString("00")}";}public static string p(double q){int r=(int)q/3600;q%=3600;int s=(
int)q/60;q%=60;if(r>0)return$"{r.ToString("00")}:{s.ToString("00")}:{q.ToString("00")}";else return
$"{s.ToString("00")}:{q.ToString("00")}";}public static Vector3D u(Vector3D v,Vector3D w,Vector3D x,int y,double z){double ª=z/y;Vector3D µ=w-(v*ª)+(x*ª);return
µ;}public static void º(ref Vector2 À){À.X=(float)Math.Round(À.X);À.Y=(float)Math.Round(À.Y);}public static string Á(
double Â){if(Â>=1000)return$"{(Â*0.001).ToString("0.##")}k";else return$"{Â.ToString("0")}m";}public static float Ã(float Ä,
float Å){return MathHelper.Clamp(Ä/Å,0.2f,0.8f);}public static Color Æ(MyRelationsBetweenPlayerAndBlock Ç){switch(Ç){case
MyRelationsBetweenPlayerAndBlock.Owner:return Color.FromNonPremultiplied(117,201,241,255);case MyRelationsBetweenPlayerAndBlock.FactionShare:return
Color.FromNonPremultiplied(50,255,50,255);case MyRelationsBetweenPlayerAndBlock.Friends:return Color.FromNonPremultiplied(150
,255,150,255);case MyRelationsBetweenPlayerAndBlock.Neutral:return Color.FromNonPremultiplied(255,255,50,255);case
MyRelationsBetweenPlayerAndBlock.Enemies:return Color.Red;case MyRelationsBetweenPlayerAndBlock.NoOwnership:return Color.FromNonPremultiplied(255,255,
255,255);default:return Color.Magenta;}}public static byte È(float É){if(É>0&&É<0.0625)return 1;else if(É>=0.0625&&É<0.125)
return 2;else if(É>=0.125&&É<0.25)return 3;else if(É>=0.25&&É<0.5)return 4;else if(É>=0.5&&É<1)return 5;else if(É>=1&&É<2)
return 6;else if(É>=2&&É<3)return 7;else if(É>=3&&É<4)return 8;else if(É>=4&&É<5)return 9;else if(É>=5)return 10;else return 0
;}public static string Ê(MyDetectedEntityType Ë){switch(Ë){case MyDetectedEntityType.SmallGrid:return"\x53\x47";case
MyDetectedEntityType.LargeGrid:return"\x4C\x47";case MyDetectedEntityType.CharacterHuman:return"\x43\x68\x61\x72";default:return Ë.ToString(
);}}public static string S(IMyTerminalBlock Ì)=>Ì.GetOwnerFactionTag();