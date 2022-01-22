using DefaultNamespace;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public PointerController pointerController;

    public BuySellAlgorithmVersion buySellAlgorithm;
    
    public override void InstallBindings()
    {
        Container.Bind<PointerController>().FromInstance(pointerController);
        Container.Bind<GameManager>().FromNewComponentOnNewGameObject().AsSingle();

        if (buySellAlgorithm == BuySellAlgorithmVersion.SingleUnit)
        {
            Container.Bind<BuySellAlgorithm>().To<SingleUnitBuySellAlgorithm>().AsSingle();
        } else if (buySellAlgorithm == BuySellAlgorithmVersion.MaxOut)
        {
            Container.Bind<BuySellAlgorithm>().To<MaxOutBuySellAlgorithm>().AsSingle();
        }

        Container.BindFactory<UnityEngine.Object, float, PriceMarker, PriceMarker.Factory>().FromFactory<PrefabFactory<float, PriceMarker>>();
    }
}

public enum BuySellAlgorithmVersion
{
    SingleUnit, MaxOut
}