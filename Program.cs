using babolnai_bence_dolgozat_250217;

List<Student> tanulok = new();
string PATH = "../../../src";
StreamReader sr = new StreamReader(new FileStream(PATH+ "/course.txt", FileMode.Open));
while (!sr.EndOfStream)
{
    Student tanulo = new(sr.ReadLine()!);
    tanulok.Add(tanulo);
}
sr.Close();

//1.:
Console.WriteLine($"1. feladat: Ennyi hallgató adatát tartalmazza a fájl: {tanulok.Count()}");

//2.: 
Console.WriteLine($"2. feladat: A hallgató átlaga backendből: " +
    $"{tanulok
    .Average(p => p.backend)}%");

//3.:
Console.WriteLine($"3. feladat: Az osztályelső: " +
    $"{tanulok
    .MaxBy(p => p.Eredmenyek.Sum())}");

//4.:
Console.WriteLine($"4. feladat: Férfiak aránya: " +
    $"{Convert.ToDouble(tanulok.Count(p => p.Nem == 0)) / Convert.ToDouble(tanulok.Count()) * 100:0}%");

//5.:
Console.WriteLine($"5. feladat: Legjobb nő a webfejlesztésnél: " +
    $"{tanulok
    .Where(p => p.Nem == 1)
    .MaxBy(p => p.frontend + p.backend)}");

//6.:
Console.WriteLine($"6. feladat: Teljes finanszírozók: \n\t" +
    $"{string.Join("\n\t",
    tanulok
    .Where(p => p.Befizetes == 2600)
    .Select(p => p.ToString()).ToArray())}");
//7.: 
Console.Write($"\n7. feladat: Kérem adja meg egy hallgató nevét: ");
string inputNev = Console.ReadLine()!;
if (tanulok.Where(p => p.Nev == inputNev).Any())
{
    List<string> _ = new();
    if (tanulok.Where(p=>p.Nev == inputNev).Where(p => p.halozat < 51).Any()) _.Add("hálózat");
    if (tanulok.Where(p => p.Nev == inputNev).Where(p => p.frontend < 51).Any()) _.Add("frontend");
    if (tanulok.Where(p => p.Nev == inputNev).Where(p => p.backend < 51).Any()) _.Add("backend");
    if (tanulok.Where(p => p.Nev == inputNev).Where(p => p.mobil < 51).Any()) _.Add("mobil");
    Console.WriteLine($"\tEbből kell javítóvizsgát tenni: " +
        $"{(_.Count > 0 ? string.Join(",", _) : "semmiből")}");
}
else
{
    Console.WriteLine("\tNincs ilyen tanuló");
}

//8.:
Console.WriteLine($"8. feladat: Azok tanulók száma," +
    $"akik egyből 100%-ot teljesítettek és nem kell javítóvizsgára menniük: " +
    $"{tanulok.Count(p => p.Eredmenyek.Any(p => p == 100)
    && p.Eredmenyek.All(p => p > 51))} db");

//9.:
Console.WriteLine($"9. feladat. modulonként ennyi vizsgát kell teni: " +
    $"\n\t Frontend: {tanulok.Count(p=>p.frontend < 51)} db" +
    $"\n\t Backend: {tanulok.Count(p=>p.backend < 51)} db" +
    $"\n\t Hálózat: {tanulok.Count(p=>p.halozat < 51)} db" +
    $"\n\t Mobil: {tanulok.Count(p=>p.mobil < 51)} db");

//10.:
StreamWriter sw = new(new FileStream(PATH+"/abc.txt", FileMode.OpenOrCreate, FileAccess.Write));
sw.Write(string.Join("\n",tanulok.OrderBy(p => p.Nev.Split(" ")[1]).Select(p => p.Kiiratas())));
sw.Close();