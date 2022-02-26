using System;
using Models;
using Renderers;
using Renderers.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Buttons
{
    public abstract class CategoryViewButton<TItem, TChild> : MonoBehaviour where TItem : Model<TChild>
    {
        [SerializeField] private Image cap;
        [SerializeField] private Text text;

        public event Action<TItem> ButtonClicked; 

        private TItem _item;

        public void Render(TItem item, ButtonSetting buttonSetting)
        {
            _item = item;
            
            cap.color = buttonSetting.ButtonColor;
            text.text = _item.Name;
        }

        public void OnButtonClick()
        {
            ButtonClicked?.Invoke(_item);
        }
    }
}
