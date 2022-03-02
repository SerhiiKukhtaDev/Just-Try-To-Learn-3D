using Factories;
using Zenject;

namespace MonoInstallers
{
    public class QuestionFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var questionFactory = new QuestionFactory();
            questionFactory.LoadViews(@"Views");
            
            Container.Bind<IQuestionFactory>().To<QuestionFactory>().FromInstance(questionFactory).AsSingle();
        }
    }
}
