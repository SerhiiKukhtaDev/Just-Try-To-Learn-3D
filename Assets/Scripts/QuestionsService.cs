using System.Collections.Generic;
using Models;

public class QuestionsService : IQuestionsService
{
    private List<Question> _questions;
    private string _path;
    
    public List<Question> Questions
    {
        get => new List<Question>(_questions);
        private set => _questions = value;
    }

    public void SetQuestionsToLoad(List<Question> questions, string path)
    {
        _path = path;
        Questions = questions;
    }

    public void Clear()
    {
        _path = string.Empty;
        Questions.Clear();
    }

    public string GetPath()
    {
        return _path;
    }
}
