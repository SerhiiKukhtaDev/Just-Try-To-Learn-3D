using System.Collections.Generic;
using System.Linq;
using Questions;
using UnityEngine;
using Views.Base;

public class QuestionsMover : MonoBehaviour
{
    [SerializeField] private int maxHistoryCount = 5;
    
    private IQuestionViewCreator _questionCreator;

    private readonly List<View> _views = new List<View>();

    public List<View> Views => _views;

    private View _currentView;

    private void Start()
    {
        _questionCreator = GetComponent<IQuestionViewCreator>();

        if (_questionCreator.TryCreateRange(2, out var views))
        {
            _views.AddRange(views);
        }
        else
        {
            _questionCreator.TryCreateSingle(out View view);
            _views.Add(view);
        }

        _currentView = _views.First();
        _currentView.Enter();
    }

    public bool TryMoveToNextView()
    {
        if (!_currentView.QuestionAnswered) return false;
        
        if (_views.IndexOf(_currentView) == _views.Count - 1)
            return false;

        if (_views.IndexOf(_currentView) == _views.Count - 2)
        {
            if (_questionCreator.TryCreateSingle(out View view))
            {
                _views.Add(view);

                TryDestroyFirst(_views);
            }
        }

        _currentView = _views[_views.IndexOf(_currentView) + 1];
        _currentView.Enter();
        
        if (_views.IndexOf(_currentView) == _views.Count - 1)
            _currentView.SetLast();
        
        return true;
    }

    public bool TryMoveToPrevView()
    {
        if (_views.IndexOf(_currentView) == 0) return false;

        _currentView = _views[_views.IndexOf(_currentView) - 1];
        return true;
    }

    private void TryDestroyFirst(List<View> views)
    {
        if (views.Count > maxHistoryCount)
        {
            var first = views.First();
            views.Remove(first);
            
            _questionCreator.DestroyView(first);
        }
    }
}
