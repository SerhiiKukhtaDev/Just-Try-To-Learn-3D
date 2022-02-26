using System.Collections.Generic;
using System.Linq;
using ScriptableObjects.Answers.Base;
using UnityEngine;
using Views;
using Views.Base;

namespace Factories
{
    public class AnswerFactory : MonoBehaviour, IAnswerFactory
    {
        private List<View> _views;

        public void LoadViews(string path)
        {
            _views = Resources.LoadAll<View>(path).ToList();
        }
        
        public View CreateWithRenderData(IContainQuestionData data, Transform parent)
        {
            var elem = _views.First();
            var rendered = Instantiate(elem, parent);
            
            rendered.Render(data);
            
            return rendered;
        }
    }

    interface IAnswerFactory
    {
        View CreateWithRenderData(IContainQuestionData data, Transform parent);
    }
}
