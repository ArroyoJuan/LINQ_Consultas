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
            string xmlRuta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\LINQ_Consultas\Empleados.xml");

            XDocument xmlDoc = XDocument.Load(xmlRuta);

            var empleadosE30 = xmlDoc.Descendants("Empleado").Where(x => (int?)x.Element("Edad") > 30);
            Console.WriteLine("Empleados mayores de 30 años: ");
            foreach (var e in empleadosE30)
            {
                Console.WriteLine("Datos: " + e.Value);
            }
            Console.WriteLine("");
            Console.WriteLine("Empleados cuyo salario es mayor a 50000:");
            var empleadosS50000 = xmlDoc.Descendants("Empleado").Where(x => (int?)x.Element("Salario") > 50000);
            foreach (var e in empleadosS50000)
            {
                Console.WriteLine("Datos: " + e.Value);
            }
            Console.WriteLine("");
            Console.WriteLine("Promedio de salario por departamento:");
            var setDepartamento = Console.ReadLine();
            var empleadosPS = xmlDoc.Descendants("Empleado").Where(x => x.Element("Departamento")?.Value == setDepartamento); //Va a filtrar el departamento
            var suma = 0; //variable
            var count = 0;
            var promedioTotal=0;    
            foreach (var e in empleadosPS) //Recorre los valores
            {
                suma = suma + (int)e.Element("Salario");
                count++;
            }
            promedioTotal = suma / count;
            Console.WriteLine("El salario promedio del departamento TI es: " + promedioTotal);
            Console.WriteLine("");
            Console.WriteLine("Empleado con el salario más alto:");
            var TodosEmpleados = xmlDoc.Descendants("Empleado");
            var salarioComparacion = 0;
            foreach (var e in TodosEmpleados) //Recorre los valores
            {
                if ((int)e.Element("Salario") > salarioComparacion)
                {
                    salarioComparacion = (int)e.Element("Salario");
                }
            }
            Console.WriteLine("El salario mayor es de: " + salarioComparacion);
            Console.WriteLine("");
            Console.WriteLine("Contar cuántos empleados hay por cada departamento:");
            var empleadosTI = xmlDoc.Descendants("Empleado").Where(x => x.Element("Departamento")?.Value == "TI"); //Va a filtrar el departamento
            var countTI = 0;
            foreach (var e in empleadosPS) 
            {
                countTI++;
            }
            Console.WriteLine("En TI existen: " + countTI);
            Console.WriteLine("");
            var empleadosMar = xmlDoc.Descendants("Empleado").Where(x => x.Element("Departamento")?.Value == "Marketing"); //Va a filtrar el departamento
            var countMar = 0;
            foreach (var e in empleadosMar
                )
            {
                countMar++;
            }
            Console.WriteLine("En Marketing existen: " + countMar);
            Console.WriteLine("");
            var empleadosVent = xmlDoc.Descendants("Empleado").Where(x => x.Element("Departamento")?.Value == "Ventas"); //Va a filtrar el departamento
            var countVent = 0;
            foreach (var e in empleadosVent)
            {
                countVent++;
            }
            Console.WriteLine("En Ventas existen: " + countVent);
            Console.ReadLine();
        }
    }
}
