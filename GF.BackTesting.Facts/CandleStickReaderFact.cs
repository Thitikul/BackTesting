using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GF.BackTesting.Facts {
    public class CandleStickReaderFact {
        [Fact]
        public void NoSeedPrice() {
            // A
            var p = new InMemoryPriceReader();
            var c = new CandleStickReader(timeframe: 15, PriceReader : p);
            int count = 0;

            // A
            c.NewCandleStick += (sender, e) => {
                count++;
            };
            c.Start();

            // A
            Assert.Equal(0, count);
        }

        [Fact]
        public void SinglePrice_NoCancleStick() {
            // Arrange
            var p = new InMemoryPriceReader();
            var c = new CandleStickReader(timeframe: 15, PriceReader: p);
            int count = 0;

            p.AddSeedPrice(12m);
            c.NewCandleStick += (sender, e) => {
                count++;
            };

            // A
            c.Start();

            // A
            Assert.Equal(1, count);
        }
    }
}
