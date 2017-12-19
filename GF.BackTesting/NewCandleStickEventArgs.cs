using System;

namespace GF.BackTesting {
    public class NewCandleStickEventArgs : EventArgs {

        public NewCandleStickEventArgs(CandleStickItem candleStickItem) {
            CandleStickItem = candleStickItem;
        }

        public CandleStickItem CandleStickItem { get; }
    }
}