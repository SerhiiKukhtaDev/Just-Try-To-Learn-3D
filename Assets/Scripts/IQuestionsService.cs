using System.Collections.Generic;
using Models;

public interface IQuestionsService
{
    List<Question> Questions { get; }
    void SetQuestionsToLoad(List<Question> questions, string path);

    void Clear();

    string GetPath();
}
