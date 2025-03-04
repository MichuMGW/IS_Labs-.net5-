using System.Xml;
using System;
using System.Collections.Generic;

namespace IS_Labs_.net5_
{
    internal class XMLReadWithSAXApproach
    {
        public static void Read(string filepath)
        {
            var postacPowszechna = new Dictionary<string, HashSet<string>>();
            // konfiguracja początkowa dla XmlReadera
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreWhitespace = true;
            // odczyt zawartości dokumentu
            XmlReader reader = XmlReader.Create(filepath, settings);
            // zmienne pomocnicze
            int count = 0;
            string postac = "";
            string sc = "";
            reader.MoveToContent();
            // analiza każdego z węzłów dokumentu
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name
                == "produktLeczniczy")
                {
                    postac = reader.GetAttribute("postac");
                    sc =
                    reader.GetAttribute("nazwaPowszechnieStosowana");
                    if (postac == "Krem" && sc == "Mometasoni furoas")
                        count++;

                    if (!postacPowszechna.ContainsKey(sc))
                    {
                        postacPowszechna.Add(sc, new HashSet<string>());
                    }
                    postacPowszechna[sc].Add(postac);
                }
            }
            Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których" +
    "jedyną substancją czynną jest Mometasoni furoas {0}", count);

            count = 0;
            foreach (var item in postacPowszechna)
            {
                if (item.Value.Count > 1)
                    count++;
            }

            Console.WriteLine("Liczba preparatów leczniczych o takiej samej nazwie powszechnej wynosi {0}", count);
        }
    }
}