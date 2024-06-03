using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belepteto
{
	internal class Program
	{
		class Adat
		{
			public string kod;
			public string ido;
			public string esemeny;

			public Adat(string kod, string ido, string esemeny)
			{
				this.kod = kod;
				this.ido = ido;
				this.esemeny = esemeny;
			}
		}

		static void Main(string[] args)
		{
			List<Adat> lista = Beolvas("bedat.txt");

			Console.WriteLine("2.feladat");
			Console.WriteLine($"Az első tanuló {lista[0].ido}-kor lépett be a főkapun.");
            Console.WriteLine($"Az utolsó tanuló {lista[lista.Count-1].ido}-kor lépett ki a főkapun.");

			List<Adat> kesok = Kesok(lista);

			using (StreamWriter w = new StreamWriter("kesok.txt"))
			{
				foreach (Adat adat in kesok)
				{
					w.WriteLine($"{adat.ido} {adat.kod}");
				}
			}

			int mdb = Menzaszam(lista);
			Console.WriteLine($"4.feladat:\nA menzán aznap {mdb} tanuló ebédelt.");

			int kdb = Kölcsönzők_száma(lista);
			Console.WriteLine($"t. feladat:\nAznap {kdb} tanuló kölcsönzött a könyvtárban.");

			if (kdb <= mdb)
			{
				Console.WriteLine("Nem voltak többen, mint a menzán.");
			}
			else
			{
				Console.WriteLine("Többen voltak, mint a menzán.");
			}

        }

		private static int Kölcsönzők_száma(List<Adat> lista)
		{
			HashSet<string> result = new HashSet<string>();

			foreach (Adat adat in lista)
			{
				if (adat.esemeny == "4")
				{
					result.Add(adat.kod);
				}
			}
			return result.Count;
		}

		private static int Menzaszam(List<Adat> lista)
		{
			int db = 0;

			foreach (Adat adat in lista)
			{
				if (adat.esemeny=="3")
				{
					db++;
				}
			}
			return db;
		}

		private static List<Adat> Kesok(List<Adat> lista)
		{
			List<Adat> result = new List<Adat>();

			DateTime mettol = new DateTime(2009, 3, 20, 7, 50, 0);
			DateTime meddig = new DateTime(2009, 3, 20, 8, 15, 0);

			foreach (Adat a in lista)
			{
				string[] t = a.ido.Split(':'); // "07:19" -> ["07", "19"]
				int ora = int.Parse(t[0]);
				int perc = int.Parse(t[1]);
				DateTime erkezes = new DateTime(2009, 3, 20, ora, perc, 0);
				if (mettol < erkezes && erkezes <= meddig)
				{
					result.Add(a);
				}
			}
			return result;
		}

		private static List<Adat> Beolvas(string v)
		{
			StreamReader f = new StreamReader(v);
			List<Adat> lista = new List<Adat>();

			while (!f.EndOfStream) 
			{
				string sor = f.ReadLine();
				string[] st = sor.Split(' ');
				Adat a = new Adat(st[0], st[1], st[2]);
				lista.Add(a);
			}

			f.Close();
			return lista;
		}
	}
}
