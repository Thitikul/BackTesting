﻿using System.Linq;
using Xunit;

namespace GF.BackTesting.Facts {
    public class InMemoryPriceReaderFact {

        [Fact]
        public void NoSeedPrice() {
            var reader = new InMemoryPriceReader();
            decimal price = 0m;
            int count = 0;

            reader.NewPrice += (sender, e) => {
                price = e.Last;
                count++;
            };

            reader.Start();

            Assert.Equal(0, count);
            Assert.Equal(0m, price);
        }


        [Fact]
        public void SinglePrice() {
            var reader = new InMemoryPriceReader();
            decimal price = 0m;

            reader.AddSeedPrice(last: 15.0m);
            reader.NewPrice += (sender, e) => {
                price = e.Last;
            };

            reader.Start();

            Assert.Equal(15.0m, price);
        }

    }
}