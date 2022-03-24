using System;
using System.Collections.Generic;
using Factories;
using Models;
using ModestTree;
using UnityEngine;
using Utils;
using Views.Base;
using Zenject;

namespace Questions
{
    public interface IQuestionViewCreator
    {
        bool TryCreateRange(int count, out IEnumerable<View> createdViews);
        
        bool TryCreateSingle(out View view);

        void DestroyView(View view);

        event Action<View> ViewCreated;

        int QuestionsCount();
    }

    public class QuestionViewCreator : MonoBehaviour, IQuestionViewCreator
    {
        [SerializeField] private Transform parent;
        [SerializeField] private int maxRenderedQuestionsCount = 5;
        
        public event Action<View> ViewCreated;
        
        public int QuestionsCount() => _questionsCount;

        private IQuestionsService _questionsService;
        private IQuestionFactory _questionFactory;
        
        private List<Question> _questions;
        private int _questionsCount;

        private float _lenght;
        private View _lastCreatedView;

        private void Start()
        {
            _questionsCount = _questions.Count;
            _lenght = GetComponentInParent<Canvas>().GetCanvasHeightWithScaleFactor();
        }

        public bool TryCreateRange(int count, out IEnumerable<View> createdViews)
        {
            if (_questions.Count < count)
            {
                createdViews = null;
                return false;
            }

            List<View> views = new List<View>();

            for (int i = 0; i < count; i++)
            {
                TryCreateSingle(out View view);
                views.Add(view);
            }

            createdViews = views;
            return true;
        }

        public bool TryCreateSingle(out View view)
        {
            if (_questions.Count <= 0)
            {
                view = null;
                return false;
            }
            
            var question = _questions.GetRandomElement();
            var createdView = _questionFactory.CreateQuestionView(question, parent);

            if(_lastCreatedView != null)
                SetPositionByPreviousWith(createdView.transform, _lastCreatedView.transform.position, _lenght);
            
            _lastCreatedView = view = createdView;

            _questions.Remove(question);

            ViewCreated?.Invoke(createdView);
            return true;
        }

        public void DestroyView(View view)
        {
            Destroy(view.gameObject);
        }

        public void Clear()
        {
            _questionsService.Clear();
        }

        [Inject]
        private void Construct(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
            _questions = questionsService.Questions;
        }

        [Inject]
        private void Construct(IQuestionFactory questionFactory)
        {
            _questionFactory = questionFactory;
        }
        
        private void SetPositionByPreviousWith(Transform target, Vector3 previousPosition, float delta)
        {
            target.position = new Vector3(previousPosition.x, previousPosition.y - delta, previousPosition.z);
        }
    }
}
