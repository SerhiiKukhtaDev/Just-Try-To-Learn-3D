using Questions;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ResultTestView : MonoBehaviour
    {
        [SerializeField] private Text allQuestionsCount;
        [SerializeField] private Text rightAnswersCount;

        public void Render(TestResult result)
        {
            allQuestionsCount.text += result.AllAnswers;
            rightAnswersCount.text += result.RightAnswers.ToString();
        }
    }
}
