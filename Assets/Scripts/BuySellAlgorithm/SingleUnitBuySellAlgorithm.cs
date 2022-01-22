namespace DefaultNamespace
{
    public class SingleUnitBuySellAlgorithm : BuySellAlgorithm
    {
        public WalletState Buy(float price, WalletState walletState)
        {
            if (walletState.Money >= price)
            {
                return new WalletState(walletState.Stocks + 1, walletState.Money - price, (walletState.BoughtPrice + price) / 2);
            }

            return walletState;
        }

        public WalletState Sell(float price, WalletState walletState)
        {
            if (walletState.Stocks > 0)
            {
                var newStocks = walletState.Stocks - 1;
                var newMoney = walletState.Money + price;
                var newBoughtPrice = newStocks == 0F ? 0F : walletState.BoughtPrice;
                
                return new WalletState(newStocks, newMoney, newBoughtPrice);
            }
            
            return walletState;
        }
    }
}