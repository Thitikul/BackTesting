using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GF.BackTesting;

namespace GF.BackTesting.Client {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(args[0]);
            Console.ReadKey();

            // arrange
            var p = new CsvPriceReader("STOCK.csv.txt");
            var c = new CandleStickReader(timeframe: 15, priceReader: p);

            c.NewCandleStick += C_NewCandleStick;
            c.Start();

            Console.ReadKey();
        }

        private static void C_NewCandleStick(object sender, NewCandleStickEventArgs e) {
            Console.WriteLine(e.CandleStick);
        }
    }
}