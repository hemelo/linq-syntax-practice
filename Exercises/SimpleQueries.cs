using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Practice.Exercises
{
    class One
    {
		public One()
		{
			var generos = new List<Genero>
			{
			new Genero { Id = 1, Nome = "Rock" },
			new Genero { Id = 2, Nome = "Reggae" },
			};

			var musicas = new List<Musica>
			{
				new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1 },
				new Musica { Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2 },
				new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 6 }
			};

			this.SimpleQuery(generos);
			this.SimpleQueryWithJoin(generos, musicas);
		}

		private void SimpleQuery(List<Genero> generos)
		{
			var query = from g in generos where g.Nome.Contains("Rock") select g;

			foreach (var genero in query)
			{
				Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
			}
		}

		private void SimpleQueryWithJoin(List<Genero> generos, List<Musica> musicas)
		{
			var query = from m in musicas 
			join g in generos on m.GeneroId equals g.Id
			select new
			{
				MusicaId = m.Id,
				Musica = m.Nome,
				Genero = g.Nome
			};

			foreach (var generic in query)
			{
				Console.WriteLine("{0}\t{1}\t{2}", generic.MusicaId, generic.Musica.PadRight(20), generic.Genero);
			}
		}
    }

	internal class Genero
    {
		public int Id { get; set; }
		public string Nome { get; set; }
    }

    internal class Musica
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public int GeneroId { get; set; }
    }
}
