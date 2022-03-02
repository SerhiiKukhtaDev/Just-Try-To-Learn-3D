using System;
using UnityEngine;
using UnityEngine.UI;
using Views.Dissolve.Base;

namespace Views.Dissolve
{
    public class BackgroundDissolve : DissolveView
    {
        [SerializeField] private float time = 1f;
        [SerializeField] private Image background;
        
        [Range(0, 1)] [SerializeField] private float from;
        [Range(0, 1)] [SerializeField] private float to;

        private void Start()
        {
            base.Render(to);

            background.material = Material;
        }

        public void ShowBackground()
        {
            ShowBackground(null);
        }

        public void ShowBackground(Action onEnd = null)
        {
            gameObject.SetActive(true);
            StartCoroutine(ChangeBackground(time, from, to, onEnd));
        }
    }
}
