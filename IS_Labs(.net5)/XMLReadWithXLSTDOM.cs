using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml;

namespace IS_Labs_.net5_
{
    internal class XMLReadWithXLSTDOM
    {
        public static void Read(string filepath)
        {
            var postacPowszechna = new Dictionary<string, HashSet<string>>();
            var producenci = new Dictionary<string, Dictionary<string, int>>();

            XPathDocument document = new XPathDocument(filepath);
            XPathNavigator navigator = document.CreateNavigator();
            XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
            manager.AddNamespace("x","http://rejestrymedyczne.ezdrowie.gov.pl/rpl/eksport-danychv1.0"); 
            XPathExpression query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy[@postac = 'Krem' and @nazwaPowszechnieStosowana = 'Mometasoni furoas']"); 
            query.SetContext(manager);
            
            int count = navigator.Select(query).Count;
            
            Console.WriteLine("Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas {0}", count ); 


        }
    }
}
