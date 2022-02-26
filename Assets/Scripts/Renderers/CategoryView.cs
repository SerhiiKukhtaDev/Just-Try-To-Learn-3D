using System;
using System.Collections.Generic;
using Lean.Gui;
using Models;
using Renderers.Settings;
using UnityEngine;
using Views.Buttons;

namespace Renderers
{
    public abstract class CategoryView<TButtonView, TItem, TChild> : MonoBehaviour,
        IContainItemsView<CategoryView<TButtonView, TItem, TChild>, List<TItem>> where TItem : Model<TChild>
        where TButtonView : CategoryViewButton<TItem, TChild>
    {
        [SerializeField] protected Transform container;
        [SerializeField] private SkyBoxView skyBoxView;
        [SerializeField] protected TButtonView template;
        [SerializeField] private LeanButton returnButton;

        protected List<TItem> Items;
        private List<TButtonView> _renderedItems;

        public event Action<CategoryView<TButtonView, TItem, TChild>> RenderRequested;
        public event Action<TItem> MoveToNextCategoryRequested;
        public event Action ReturnRequested;

        private void Awake()
        {
            _renderedItems = new List<TButtonView>();
        }

        private void OnEnable()
        {
            RenderRequested?.Invoke(this);
            returnButton.OnClick.AddListener(ReturnBackRequested);
        }

        private void OnDisable()
        {
            foreach (var item in _renderedItems)
            {
                item.ButtonClicked -= OnButtonClicked;
                Destroy(item.gameObject);
            }
            
            _renderedItems.Clear();
        }

        private void ReturnBackRequested()
        {
            ReturnRequested?.Invoke();
        }

        public void Render(ColorScheme colorScheme)
        {
            RenderButtons(colorScheme.ButtonSettings);
            RenderSkyBox(colorScheme.BoxSettings);
        }

        private void RenderButtons(ButtonSetting buttonSetting)
        {
            Items.ForEach(item => RenderButton(item, buttonSetting));
        }

        private void RenderSkyBox(SkyBoxSettings skyBoxSettings)
        {
            skyBoxView.Render(skyBoxSettings);
        }
        
        private void RenderButton(TItem item, ButtonSetting buttonSetting)
        {
            var buttonView = Instantiate(template, container);
            buttonView.Render(item, buttonSetting);
            
            buttonView.ButtonClicked += OnButtonClicked;
            _renderedItems.Add(buttonView);
        }

        private void OnButtonClicked(TItem item)
        {
            MoveToNextCategoryRequested?.Invoke(item);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void ShowWithItems(List<TItem> itemsToShow)
        {
            Items = itemsToShow;
            Show();
        }
    }
}