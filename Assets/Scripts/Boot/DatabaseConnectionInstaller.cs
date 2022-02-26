using Database.Services;
using UnityEngine;
using Zenject;

namespace Boot
{
    public class DatabaseConnectionInstaller : MonoInstaller
    {
        [SerializeField] private SubjectsService subjectsService;
        
        public override void InstallBindings()
        {
            Container.Bind<ISubjectsService>().To<SubjectsService>().FromInstance(new SubjectsService())
                .AsSingle().NonLazy();
        }
    }
}
