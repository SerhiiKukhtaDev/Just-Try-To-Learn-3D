namespace Questions
{
    public class TestResult
    {
        public int AllAnswers { get; }
        public int RightAnswers { get; }

        public TestResult(int allAnswers, int rightAnswers)
        {
            AllAnswers = allAnswers;
            RightAnswers = rightAnswers;
        }
    }
}