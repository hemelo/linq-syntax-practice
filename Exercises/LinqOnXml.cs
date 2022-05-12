using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using Linq.Practice.Shared; 

namespace Linq.Practice.Exercises
{
    class Two
    {
        public XElement Root { get; set; }

        public Two(string path)
        {
            Root = XElement.Load(path);

            XMLDecodingAndJoin();
        }

        private void XMLDecodingAndJoin()
        {
            var query = from g in Root?.Element("Generos")?.Elements("Genero")
                join m in Root?.Element("Musicas")?.Elements("Musica")
                    on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                select new
                {
                    MusicaId = m.Element("MusicaId").Value,
                    Musica = m.Element("Nome").Value,
                    Genero = g.Element("Nome").Value
                };

                foreach (var generic in query)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", generic.MusicaId, generic.Musica.PadRight(20), generic.Genero);
                }
        }
    }
}
