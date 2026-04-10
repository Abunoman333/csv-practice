namespace CsvPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "data.csv";

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

            //string filename = "data.csv";
            //var lines = File.ReadAllLines(filename);
            //var idx = 0;

            //string headerNo = string.Empty;
            //string headerName = string.Empty;
            //string headerAmounts = string.Empty;
            //string headerPrice = string.Empty;
            //string headerDelivery = string.Empty;
            //string headerIsOrdered = string.Empty;
            //foreach (var line in lines)
            //{
            //    var parts = line.Split(',');
            //    if (idx == 0) // Header
            //    {
            //        headerNo = parts[0];
            //        headerName = parts[1];
            //        headerAmounts = parts[2];
            //        headerPrice = parts[3];
            //        headerDelivery = parts[4];
            //        headerIsOrdered = parts[5];
            //    }
            //    else // Values
            //    {
            //        string productName = parts[1];
            //        int amount = int.Parse(parts[2]);
            //        int price = int.Parse(parts[3]);
            //        DateTime dt = DateTime.ParseExact(parts[4], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            //        bool isordered = bool.Parse(parts[5]);
            //        Console.WriteLine($"{headerName}: {productName}");
            //        Console.WriteLine("amount" + amount);
            //        Console.WriteLine("price" + price);
            //        Console.WriteLine("dt" + dt);
            //        Console.WriteLine("Ordered" + isordered);
            //    }
            //    idx++;
            //}
        }
    }
}
