using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public GameManager.Settings gameSettings;
        
    public override void InstallBindings()
    {
        Container.BindInstance(gameSettings);
    }
}