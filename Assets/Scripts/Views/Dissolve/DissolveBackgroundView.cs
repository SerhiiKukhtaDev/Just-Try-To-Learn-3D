using System.Collections;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
using Views.Base;
using Views.Dissolve.Base;

namespace Views
{
    public class DissolveBackgroundView : DissolveView, IReactOnAnswer
    {
        [SerializeField] private Image mainBackground;
        [SerializeField] private Image icon;
        [SerializeField] private Text text;
        [SerializeField] private StatusPanel statusPanel;

        public override void Render(float startDissolution)
        {
            base.Render(startDissolution);
            
            mainBackground.material = Material;
            icon.material = Material;
            text.material = Material;
        }

        public void React(bool isRightAnswer, float time)
        {
            gameObject.SetActive(true);
            
            var panel = statusPanel.GetPanelByAnswer(isRightAnswer);
            
            mainBackground.color = panel.Background;
            text.color = Color.white;
            text.text = panel.Text;
            icon.sprite = panel.Icon;
            
            StartCoroutine(ChangeBackground(time, 1, 0));
        }
    }
}
