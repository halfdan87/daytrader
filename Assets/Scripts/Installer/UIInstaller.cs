using TMPro;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    public TextMeshProUGUI moneyLabel;
    public TextMeshProUGUI stockLabel;
    public TextMeshProUGUI priceLabel;
    public TextMeshProUGUI boughtPriceLabel;

    public override void InstallBindings()
    {
        Container.Bind<TextMeshProUGUI>().FromInstance(moneyLabel).When(
            context => context.MemberName.Equals("moneyLabel")
            );
        Container.Bind<TextMeshProUGUI>().FromInstance(stockLabel).When(
            context => context.MemberName.Equals("stockLabel")
        );
        Container.Bind<TextMeshProUGUI>().FromInstance(priceLabel).When(
            context => context.MemberName.Equals("priceLabel")
        );        
        Container.Bind<TextMeshProUGUI>().FromInstance(boughtPriceLabel).When(
            context => context.MemberName.Equals("boughtPriceLabel")
        );
        Container.Bind<KeyController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }
}