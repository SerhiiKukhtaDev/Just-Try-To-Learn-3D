using ScriptableObjects.Answers.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public interface IFourAnswersView : IView
    {
        
    }

    public interface IView
    {
        void Render(IContainQuestionData data);
    }
    
    public class FourAnswersView : MonoBehaviour, IFourAnswersView
    {
        [SerializeField] private Text question;
        [SerializeField] private Text[] answers = new Text[4];

        public void Render(IContainQuestionData data)
        {
            question.text = data.QuestionTitle;

            for (var i = 0; i < answers.Length; i++)
            {
                answers[i].text = data.Answers[i];
            }
        }
    }
}
