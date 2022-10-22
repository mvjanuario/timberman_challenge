using UnityEngine;
using Zenject;

public class TreeManagerInstaller : MonoInstaller
{
    [SerializeField]
    private TreeManager m_treeManager;

    public override void InstallBindings()
    {
        Container.BindInstance(m_treeManager);
    }
}