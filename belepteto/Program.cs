using System;
using System.Collections.Generic;
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

			Console.WriteLine("2.feladat\n");
			Console.WriteLine($"Az első tanuló {lista[0].ido} - kor lépett be a főkapun.\n");
            Console.WriteLine($"Az utolsó tanuló {lista[lista.Count-1].ido} - kor lépett ki a főkapun.");
			
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
