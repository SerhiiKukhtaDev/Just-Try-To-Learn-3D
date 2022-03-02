using System;
using System.Collections.Generic;
using System.Linq;
using Factories;
using Models;
using UnityEngine;
using Utils;
using Views.Base;
using Zenject;

namespace Questions
{
    public class QuestionCreator : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private QuestionSwapper swapper;
        [SerializeField] private int maxRenderedQuestionsCount = 5;
        
        public int CurrentWatchableQuestion => _currentWatchableQuestion;
        
        public int AllQuestionsCount { get; private set; }
        
        public event Action<View> QuestionCreated;
        public event Action<View> CurrentViewChanged;
        public event Action<View> ViewDestroyed;

        private IQuestionsService _questionsService;
        private IQuestionFactory _questionFactory;
        
        private List<Question> _questions;
        private List<View> _createdQuestions;
        private int _prevLastQuestionIndex;
        private int _currentWatchableQuestion;
        private float _lenght;


        private void Start()
        {
            AllQuestionsCount = _questions.Count;
            
            _lenght = GetComponentInParent<Canvas>().GetCanvasHeightWithScaleFactor();
            
            _createdQuestions = new List<View>();

            if(_questions.Count == 1) CreateQuestionAndRemoveFromList();
            
            if(_questions.Count > 1) for (int i = 0; i < 2; i++) CreateQuestionAndRemoveFromList();

            CurrentViewChanged?.Invoke(_createdQuestions[0]);
            
            UpdatePrevLastQuestionIndex();
        }

        private void OnEnable()
        {
            swapper.DownSwiped += TryCreateQuestion;
            swapper.DownSwiped += IncrementCurrentWatchableQuestion;

            swapper.UpSwiped += DecrementCurrentWatchableQuestion;
        }

        private void OnDisable()
        {
            swapper.DownSwiped -= TryCreateQuestion;
            swapper.DownSwiped -= IncrementCurrentWatchableQuestion;
            
            swapper.UpSwiped -= DecrementCurrentWatchableQuestion;
        }

        private void TryCreateQuestion()
        {
            if (_currentWatchableQuestion == _prevLastQuestionIndex && _questions.Count > 0)
            {
                CreateQuestionAndRemoveFromList(UpdatePrevLastQuestionIndex, TryDestroyFirstQuestion);
            }
        }

        private void TryDestroyFirstQuestion()
        {
            if (_createdQuestions.Count > maxRenderedQuestionsCount)
            {
                var elem = _createdQuestions.First();
                _createdQuestions.Remove(elem);
                
                UpdateIndexes();

                ViewDestroyed?.Invoke(elem);

                Destroy(elem.gameObject);
            }
        }

        private void UpdateIndexes()
        {
            _currentWatchableQuestion--;
            _prevLastQuestionIndex--;
        }

        private void IncrementCurrentWatchableQuestion()
        {
            _currentWatchableQuestion++;
            CurrentViewChanged?.Invoke(_createdQuestions[_currentWatchableQuestion]);
        }

        private void DecrementCurrentWatchableQuestion()
        {
            _currentWatchableQuestion--;
            CurrentViewChanged?.Invoke(_createdQuestions[_currentWatchableQuestion]);
        }

        private void UpdatePrevLastQuestionIndex()
        {
            _prevLastQuestionIndex = _createdQuestions.Count - 2;
        }

        private void CreateQuestionAndRemoveFromList(params Action[] onEnd)
        {
            var question = _questions.GetRandomElement();
            var view = _questionFactory.CreateQuestionView(question, parent);

            if (_createdQuestions.Count > 0)
                SetPositionByPreviousWith(view.transform, _createdQuestions.Last().transform.position, _lenght);
            
            _questions.Remove(question);
            _createdQuestions.Add(view);
            
            if(_questions.Count == 0)
                view.SetLast();
            
            foreach (var action in onEnd)
            {
                action?.Invoke();
            }
            
            QuestionCreated?.Invoke(view);
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
