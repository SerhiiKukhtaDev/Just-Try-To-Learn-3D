using ScriptableObjects.Answers.Base;

namespace Views.Interfaces.Base
{
    public interface IView
    {
        void Render(IContainQuestionData data);
    }
}
