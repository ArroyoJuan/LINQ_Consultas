using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ_Consultas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mapear la ruta del XML
            string xmlRuta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\LINQApp\Personas.xml");

            //Cargar el XML
            XDocument xmlDoc = XDocument.Load(xmlRuta);

            //usar LINQ para filtrar personas del XML, que sean mayores de edad y que muestre el nombre.
            var sennores = xmlDoc.Descendants("Persona").Where(x => (int?)x.Element("Edad") > 18);

            foreach (var p in sennores)
            {
                Console.WriteLine("Datos: " + p.Value);
            }

            Console.ReadLine();
        }
    }
}
