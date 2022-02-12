using UnityEngine;

namespace ScriptableObjects.Answers.Base
{
    public interface IContainQuestionData
    {
        string[] Answers { get; }
        string RightAnswer { get; }
        string QuestionTitle { get; }
    }

    [CreateAssetMenu(fileName = "New Question", menuName = "Question/FourAnswers/New Question")]
    public class Question : ScriptableObject, IContainQuestionData
    {
        [SerializeField] private string question;
        [SerializeField] private string[] answers = new string[4];
        [SerializeField] private string rightAnswer;
        [SerializeField] private Difficulty difficulty = Difficulty.Ez;
        [Range(10, 60)] [SerializeField] private int timeToAnswer = 30;

        public string QuestionTitle => question.Trim();

        public string RightAnswer => rightAnswer.Trim();

        public string[] Answers => answers;

        public Difficulty Difficulty => difficulty;

        public int TimeToAnswer => timeToAnswer;
    }

    public enum Difficulty
    {
        Ez,
        Norm,
        Demon,
        Armagedon
    }
}
