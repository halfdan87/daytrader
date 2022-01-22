using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Inject] private TextMeshProUGUI moneyLabel;
    [Inject] private TextMeshProUGUI stockLabel;
    [Inject] private TextMeshProUGUI priceLabel;
    [Inject] private TextMeshProUGUI boughtPriceLabel;

    [Inject] private PointerController pointer;

    [Inject] private Settings settings;

    [Inject] private BuySellAlgorithm _buySellAlgorithm;
    
    internal float price;

    private WalletState _walletState;

    private void Start()
    {
        price = settings.initialPrice;
        _walletState = new WalletState(0, settings.initialMoney, 0F);
        pointer.Init(price);
    }

    void Update()
    {
        price += Random.Range(settings.minJump, settings.maxJump+1) * Time.deltaTime * settings.multiplier;

        UpdateLabel(_walletState.Money, moneyLabel, "{0:0.00}");
        UpdateLabel(_walletState.Stocks, stockLabel, "{0:0.00}");
        UpdateLabel(price, priceLabel, "{0:0.00}");
        UpdateLabel(_walletState.BoughtPrice, boughtPriceLabel, "x{0:0.00}");

        SetLineColor();
    }

    private void SetLineColor()
    {
        if (_walletState.Stocks == 0)
        {
            pointer.SetColor(0F);
            return;
        }
        var interest = (price - _walletState.BoughtPrice) / price; 
        pointer.SetColor(interest);
    }

    private void UpdateLabel(float value, TextMeshProUGUI label, string format = "{0}")
    {
        label.SetText(String.Format(format, value));
    }

    public void Buy()
    {
        _walletState = _buySellAlgorithm.Buy(price, _walletState);
    }
    
    public void Sell()
    {
        _walletState = _buySellAlgorithm.Sell(price, _walletState);
    }

    [Serializable]
    public class Settings
    {
        public float initialPrice;
        public float initialMoney;
        public float multiplier = 1f;
        public int maxJump = 1, minJump = -1;
        public float followSpeed = 0.5F;
        
        public Color lossColor;
        public Color zeroColor;
        public Color profitColor;
    }
}
