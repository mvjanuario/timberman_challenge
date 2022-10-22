using UnityEngine;
using Zenject;

public class GameSceneManagerInstaller : MonoInstaller
{
    [SerializeField]
    private GameSceneManager m_gameSceneManager;

    public override void InstallBindings()
    {
        Container.BindInstance(m_gameSceneManager);
    }
}