namespace DefaultNamespace
{
    public interface BuySellAlgorithm
    {
        public WalletState Buy(float price, WalletState walletState);
        public WalletState Sell(float price, WalletState walletState);
    }

    public struct WalletState
    {
        private int stocks;
        private float money;
        private float boughtPrice;

        public float BoughtPrice => boughtPrice;

        public int Stocks => stocks;

        public float Money => money;

        public WalletState(int stocks, float money, float boughtPrice)
        {
            this.stocks = stocks;
            this.money = money;
            this.boughtPrice = boughtPrice;
        }
    }
}