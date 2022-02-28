using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using Views.Base;
using Views.Questions;

namespace Factories
{
    public class QuestionFactory : IQuestionFactory
    {
        private List<View> _views;
        
        public void LoadViews(string path)
        {
            _views = Resources.LoadAll<View>(path).ToList();
        }

        public View CreateQuestionView(Question question, Transform parent)
        {
            foreach (var questionAnswer in question.Answers)
            {
                if (questionAnswer.AnswerText.Length > 12)
                {
                    return CreateLong(question, parent);
                }

                if (questionAnswer.AnswerText.Length > 50)
                {
                    return CreateOverflowed(question, parent);
                }
            }

            return CreateSingle(question, parent);
        }

        private View CreateSingle(Question question, Transform parent)
        {
            return CreateByType<SingleAnswerTextQuestionView>(question, parent);
        }

        private View CreateLong(Question question, Transform parent)
        {
            return CreateByType<LongAnswerTextQuestionView>(question, parent);
        }

        private View CreateOverflowed(Question question, Transform parent)
        {
            return CreateByType<OverflowedAnswerTextQuestionView>(question, parent);
        }

        private View CreateByType<TType>(Question question, Transform parent) where TType : View
        {
            var view = _views.FirstOrDefault(v => v.GetType() == typeof(TType)) 
                as TType;
            
            var created = Object.Instantiate(view, parent);
            created.Render(question);

            return created;
        }
    }
}
