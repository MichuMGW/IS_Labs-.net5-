using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IS_Lab1_XML
{
    internal class XMLReadWithDOMApproach
    {
        public static void Read(string filepath)
        {
            var postacPowszechna = new Dictionary<string, HashSet<string>>();
            var krem = new Dictionary<string, int>();
            var tabletki = new Dictionary<string, int>();

            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            string postac;
            string producent;
            string sc;
            int count = 0;
            var drugs = doc.GetElementsByTagName("produktLeczniczy");
            foreach (XmlNode d in drugs)
            {
                postac = d.Attributes.GetNamedItem("postac").Value;
                sc =
                d.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;
                producent = d.Attributes.GetNamedItem("podmiotOdpowiedzialny").Value;
                if (postac == "Krem" && sc == "Mometasoni furoas")
                    count++;

                

                if (!postacPowszechna.ContainsKey(sc))
                {
                    postacPowszechna.Add(sc, new HashSet<string>());
                }
                postacPowszechna[sc].Add(postac);

                // Słownik producentów i ilości postaci leków przez nich produkowanych
                if (postac == "Krem")
                {
                    if (!krem.ContainsKey(producent))
                    {
                        krem.Add(producent, 0);
                    } else
                    {
                        krem[producent]++;
                    }
                }
                if (postac == "Tabletki")
                {
                    if (!tabletki.ContainsKey(producent))
                    {
                        tabletki.Add(producent, 0);
                    }
                    else
                    {
                        tabletki[producent]++;
                    }
                }
            }

            var maxKremProducent = krem.First(x => x.Value == krem.Values.Max());
            var maxTabletkiProducent = tabletki.First(x => x.Value == tabletki.Values.Max());

            Console.WriteLine("Producent, który produkuje najwięcej kremów to {0} z ilością {1}", maxKremProducent.Key, maxKremProducent.Value);
            Console.WriteLine("Producent, który produkuje najwięcej tabletek to {0} z ilością {1}", maxTabletkiProducent.Key, maxTabletkiProducent.Value);

            Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których" +
                "jedyną substancją czynną jest Mometasoni furoas {0}", count);

            count = 0;
            foreach (var item in postacPowszechna)
            {
                if (item.Value.Count > 1)
                    count++;
            }
            
            Console.WriteLine("Liczba preparatów leczniczych o takiej samej nazwie powszechnej wynosi {0}", count);


            
            /*foreach (var item in postacPowszechna)
            {
                if (item.Value.Count > 1)
                {
                    Console.WriteLine("{0} - {1}", item.Key, item.Value.Count);
                }
            }*/
            {
                
            }
        }

        private void createDictionaries()
        {

        }
    }
}
