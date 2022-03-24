using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class TimeLeftView : MonoBehaviour
    {
        [SerializeField] private Image circle;
        [SerializeField] private Text text;

        private int _time;
        private TweenerCore<float,float,FloatOptions> _circleTween;
        private TweenerCore<int, int, NoOptions> _textTween;
        private TweenCallback _onEnd;

        public void Render(Color color, int time)
        {
            _time = time;
            
            circle.color = color;
            text.text = time.ToString();
        }

        public void StartCount(TweenCallback onEnd)
        {
            _onEnd = onEnd;

            _circleTween = circle.DOFillAmount(0, _time).SetEase(Ease.Linear).SetDelay(1f);
            _textTween =  text.DOCounter(_time, 0, _time).SetEase(Ease.Linear).SetDelay(1f).OnComplete(TimeOut);
        }

        public void EndCount()
        {
            KillTweens();
        }

        private void KillTweens()
        {
            _circleTween.Kill();
            _textTween.Kill();
        }

        private void TimeOut()
        {
            KillTweens();
            text.text = string.Empty;
            _onEnd.Invoke();
        }
    }
}
