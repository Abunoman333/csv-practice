using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace CsvPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "data.csv";
            // Calling methods
            //Add(filename);
            DeleteLastRow(filename);
            Read(filename);
            //Edit(filename);
        }

        // Define Edit method
        public static void Edit(string fileName)
        {
            string productName = "New Product Name";
            var lines = File.ReadAllLines(fileName).ToList();

            var header = lines[0];
            var data = lines.Skip(1).ToList();
            var newData = new List<string>();
            for (int i = 0; i < data.Count; i++)
            {
                var columns = data[i].Split(',');
                if (columns[1].Replace("\"", "") == "SPX-77")
                {
                    columns[1] = ("New Product Name");
                    columns[3] = ("999");
                    data[i] = string.Join(",", columns);

                    Console.WriteLine($"{i + 2} row edit completed.");


                }
            }

            {
                File.WriteAllLines(fileName, new[] { header }.Concat(data));
            }
        }

        // Define Delete method
        public static void DeleteLastRow(string fileName)
        {

            // 1. Read all Lines
            var lines = File.ReadAllLines(fileName).ToList();

            // 2. Separate header and data rows
            var header = lines[0];
            var data = lines.Skip(1).ToList();

            // 3. Confirm that there are rows in the "data" variables.
            if (data.Count > 0)
            {
                // 4. delete row from "data" variable.
                data.RemoveAt(data.Count - 1);
            }
            // 5. Update
            File.WriteAllLines(fileName, new[] { header }.Concat(data));
            //Console.WriteLine($"{i + 2} row delete.");
        }
        // Define Read method
        public static void Read(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var idx = 0;

            string headerNo = string.Empty;
            string headerName = string.Empty;
            string headerAmounts = string.Empty;
            string headerPrice = string.Empty;
            string headerDelivery = string.Empty;
            string headerIsOrdered = string.Empty;
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (idx == 0) // Header
                {
                    headerNo = parts[0];
                    headerName = parts[1];
                    headerAmounts = parts[2];
                    headerPrice = parts[3];
                    headerDelivery = parts[4];
                    headerIsOrdered = parts[5];
                }
                else // Values
                {
                    string productName = parts[1];
                    int amount = int.Parse(parts[2]);
                    int price = int.Parse(parts[3]);
                    DateTime dt = DateTime.ParseExact(parts[4], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    bool isordered = bool.Parse(parts[5]);
                    Console.WriteLine($"{headerName}: {productName}");
                    Console.WriteLine("amount" + amount);
                    Console.WriteLine("price" + price);
                    Console.WriteLine("dt" + dt);
                    Console.WriteLine("Ordered" + isordered);
                }
                idx++;
            }
        }

        // Define Add method
        public static void Add(string filename)
        {
            // define new line
            string[] newLine = {
                5.ToString(), // define & convert int to string
                "XYZ-999",
                333.ToString(), // define & convert int to string
                777.ToString(), // define & convert int to string
                new DateTime(2026, 4, 13).ToString("yyyy-MM-dd"),   // define & convert DateTime to string
                false.ToString(),   // define & convert bool to string
            };
            string argNewLine = string.Join(",", newLine);

            File.AppendAllText(filename, argNewLine + "\n");

            Console.WriteLine("Data added!\n");
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var parts = line.Split(',');

                var productName = parts[1];
                var amount = parts[2];
                var price = parts[3];
                var dt = parts[4];
                var isordered = parts[5];
                Console.WriteLine($"name: {productName}");
                Console.WriteLine("amount: " + amount);
                Console.WriteLine("price: " + price);
                Console.WriteLine("dt: " + dt);
                Console.WriteLine("Ordered: " + isordered);
            }
        }
    }
}
