using System.Collections.Generic;
using Models;
using Renderers.Buttons;
using Renderers.Classes;
using Renderers.Settings;
using Renderers.Themes;
using UnityEngine;
using Utils;

namespace Renderers
{
    public class MenuSceneRenderer : MonoBehaviour
    {
        [SerializeField] private List<ColorScheme> colorSchemes;

        [SerializeField] private MenuView menuView;
        [SerializeField] private SubjectsView subjectsView;
        [SerializeField] private ClassesView classesView;
        [SerializeField] private ThemeView themesView;
        
        private void Awake()
        {
            menuView.RenderRequested += OnMenuViewRenderRequested;
            subjectsView.RenderRequested += OnSubjectsRenderRequested;
            classesView.RenderRequested += ClassesViewRenderRequested;
            themesView.RenderRequested += ThemesViewRenderRequested;
        }

        private void ThemesViewRenderRequested(CategoryView<ThemeButton, Theme, Question> obj)
        {
            var theme = colorSchemes.GetRandomElement();
            
            obj.Render(theme);
        }

        private void ClassesViewRenderRequested(CategoryView<ClassButton, Class, Theme> obj)
        {
            var theme = colorSchemes.GetRandomElement();

            obj.Render(theme);
        }

        private void OnSubjectsRenderRequested(CategoryView<SubjectButton, Subject, Class> categoryView)
        {
            var theme = colorSchemes.GetRandomElement();

            categoryView.Render(theme);
        }

        private void OnMenuViewRenderRequested(MenuView view)
        {
            var theme = colorSchemes.GetRandomElement();
            
            view.Render(theme);
        }
        
    }
}
