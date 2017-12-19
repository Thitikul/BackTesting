using System;
using System.Collections.Generic;

namespace GF.BackTesting {
    public class CandleStickReader {
        private int timeframe;
        private PriceReader PriceReader;

        private List<CandleStickItem> candleStickItems;
        
        public event EventHandler<NewCandleStickEventArgs> NewCandleStick;
        
        public CandleStickReader(int timeframe, PriceReader PriceReader) {
            this.timeframe = timeframe;
            this.PriceReader = PriceReader;

            candleStickItems = new List<CandleStickItem>();
        }

        private void PriceReader_NewPrice(object sender, NewPriceEventArgs e) {
            var item = new CandleStickItem {
                Open = e.Last,
                High = e.Last,
                Close = e.Last,
                Low = e.Last,
                Color = CandleStickColor.Green
            };
        }

        public virtual void Start() {
            foreach (var p in candleStickItems) {
                var e = new NewCandleStickEventArgs(p);
                NewCandleStick?.Invoke(this, e);
            }
        }
    }
}