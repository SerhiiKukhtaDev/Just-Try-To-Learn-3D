using Factories;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    [SerializeField] private AnswerFactory factory;
    
    public override void InstallBindings()
    {
        factory.LoadViews("Views/");
        Container.Bind<IAnswerFactory>().FromInstance(factory).AsSingle();
    }
}
