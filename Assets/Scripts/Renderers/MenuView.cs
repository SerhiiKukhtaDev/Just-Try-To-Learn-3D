using System;
using Lean.Gui;
using Renderers.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Renderers
{
    public class MenuView : MonoBehaviour, IView<MenuView>
    {
        [SerializeField] private LeanButton playButton;
        
        [SerializeField] private Image firstButtonCap;
        [SerializeField] private Image secondButtonCap;
        [SerializeField] private SkyBoxView skyBoxView;
        
        public event Action<MenuView> RenderRequested;
        public event Action PlayButtonClicked;

        private void Start()
        {
            RenderRequested?.Invoke(this); 
        }

        private void OnEnable()
        {
            playButton.OnClick.AddListener(() => PlayButtonClicked?.Invoke());
            RenderRequested?.Invoke(this); 
        }

        private void OnDisable()
        {
            playButton.OnClick.RemoveListener(() => PlayButtonClicked?.Invoke());
        }

        public void Render(ColorScheme colorScheme)
        {
            var buttonSetting = colorScheme.ButtonSettings;

            firstButtonCap.color = buttonSetting.ButtonColor;
            secondButtonCap.color = buttonSetting.ButtonColor;
            
            skyBoxView.Render(colorScheme.BoxSettings);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }

    public interface IContainItemsView<TType, TItems> : IView<TType>
    {
        void ShowWithItems(TItems itemsToShow);
    }

    public interface IView<TType>
    {
        event Action<TType> RenderRequested;

        void Hide();
        
        public void Show();
    } 
    
    public interface IRenderSettings {}
}
