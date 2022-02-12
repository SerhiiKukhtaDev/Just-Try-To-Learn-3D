using System.Collections.Generic;
using System.Linq;
using ScriptableObjects.Answers.Base;
using UnityEngine;
using Views;

namespace Factories
{
    public class AnswerFactory : MonoBehaviour, IAnswerFactory
    {
        [SerializeField] Transform parent;
        private List<View> _views;

        public void LoadViews(string path)
        {
            _views = Resources.LoadAll<View>(path).ToList();
        }
        
        public T1 CreateWithRenderData<T1, T>(T data) where T : IContainQuestionData where T1 : IView
        {
            var elem = _views.First(view => view.GetComponent<T1>() != null);
            var rendered = Instantiate(elem, parent).GetComponent<T1>();

            rendered.Render(data);
            return rendered;
        }
    }

    interface IAnswerFactory
    {
        T1 CreateWithRenderData<T1, T>(T data) where T : IContainQuestionData where T1 : IView;
    }
}
