namespace DefaultNamespace
{
    public class MaxOutBuySellAlgorithm : BuySellAlgorithm
    {
        public WalletState Buy(float price, WalletState walletState)
        {
            if (walletState.Money >= price)
            {
                int maxCount = (int) (walletState.Money / price);
                float newMoney = walletState.Money - (maxCount * price);
                int newStocks = walletState.Stocks + maxCount;
                var newPrice = price;
                if (walletState.Stocks > 0)
                {
                    newPrice = (walletState.BoughtPrice * walletState.Stocks + price * maxCount) / newStocks;
                }
                
                return new WalletState(newStocks, newMoney, newPrice);
            }
            
            return walletState;
        }

        public WalletState Sell(float price, WalletState walletState)
        {
            return new WalletState(0, walletState.Money + (price * walletState.Stocks), 0F);
        }
    }
}