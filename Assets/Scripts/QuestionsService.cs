using System.Collections.Generic;
using Models;

public class QuestionsService : IQuestionsService
{
    private List<Question> _questions;

    public List<Question> Questions
    {
        get => new List<Question>(_questions);
        private set => _questions = value;
    }

    public void SetQuestionsToLoad(List<Question> questions)
    {
        Questions = questions;
    }

    public void Clear()
    {
        Questions.Clear();
    }
}
