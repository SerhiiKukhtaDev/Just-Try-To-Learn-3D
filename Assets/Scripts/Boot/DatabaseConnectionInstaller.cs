using Database.Services;
using Zenject;

namespace Boot
{
    public class DatabaseConnectionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISubjectsService>().To<SubjectsService>().FromInstance(new SubjectsService())
                .AsSingle().NonLazy();
        }
    }
}
