using Zenject;

public class QuestionsServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IQuestionsService>().To<QuestionsService>().FromInstance(new QuestionsService()).AsSingle()
            .Lazy();
    }
}
