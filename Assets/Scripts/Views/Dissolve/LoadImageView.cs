using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Views.Dissolve.Base;

namespace Views.Dissolve
{
    public class LoadImageView : DissolveView
    {
        [SerializeField] private Text loadText;
        [SerializeField] private Image loadImage;

        private void Start()
        {
            base.Render(1);

            loadImage.material = Material;
            loadText.material = Material;
        }

        public void Show(float time, Action onComplete)
        {
            gameObject.SetActive(true);
            StartCoroutine(ChangeBackground(time, 1, 0, onComplete));
        }

        public void HideText(float time, TweenCallback onComplete)
        {
            loadText.DOFade(0, time).OnComplete(onComplete).SetAutoKill();
        }
    }
}
