using System;
namespace babolnai_bence_dolgozat_250217
{
    internal class Student
    {
        public string Nev { get; set; }
        public int Nem { get; set; }
        public int Befizetes { get; set; }

        public int halozat;
        public int mobil;
        public int frontend;
        public int backend;
        public int[] Eredmenyek { get; set; }

        public Student(string sor)
        {
            string[] darabok = sor.Split(';');
            Nev = darabok[0];
            Nem = darabok[1] == "m" ? 0 : 1;
            Befizetes = int.Parse(darabok[2]);
            halozat = int.Parse(darabok[3]);
            mobil = int.Parse(darabok[4]);
            frontend = int.Parse(darabok[5]);
            backend = int.Parse(darabok[6]);
            Eredmenyek = [halozat,mobil,frontend,backend];
        }

        public override string ToString()
        {
            return $"{Nev} ({(Nem == 0 ? "Férfi" : "Nő")})";
        }

        public string Kiiratas()
        {
            return $"{Nev}: {Eredmenyek.Average()}%";
        }
    }
}
