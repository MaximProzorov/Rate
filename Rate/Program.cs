using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RateModel;


namespace Rate
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RateContext db = new RateContext())
            { 
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("http://www.cbr.ru/scripts/XML_daily.asp");
                XmlElement xRoot = xDoc.DocumentElement;
                XmlNode xNode = xRoot.SelectSingleNode("//Valute[@ID='R01239']/Value");
                db.RateClasses.Add(new RateClass { Currency = "EUR", Date = DateTime.Now, Rate = Convert.ToDouble(xNode.InnerText) });
                db.SaveChanges();
                Console.WriteLine("Объект успешно сохранен");
                var rates = db.RateClasses;
                Console.WriteLine("Список объектов:");
                foreach (RateClass u in rates)
                {
                    Console.WriteLine("{0}.{2} - {3}, {1}", u.Id, u.Date, u.Currency, u.Rate);
                }
                Console.ReadKey();
            }
        }
    }
}
