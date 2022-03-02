using Database.Services;
using Models;
using Renderers;
using Renderers.Classes;
using Renderers.Subjects;
using Renderers.Themes;
using UnityEngine;
using Zenject;

namespace Menu
{
    public class MenuItemViewSwitcher : MonoBehaviour
    {
        [SerializeField] private MenuView menuView;
        [SerializeField] private SubjectsView subjectsView;
        [SerializeField] private ClassesView classesView;
        [SerializeField] private ThemeView themesView;
        
        private ISubjectsService _subjectsService;

        public Subject CurrentSubject { get; private set; }
        public Class CurrentClass { get; private set; }

        private void Start()
        {
            menuView.Show();
        }

        [Inject]
        private void Construct(ISubjectsService subjectsService)
        {
            _subjectsService = subjectsService;
        }
        
        private void OnEnable()
        {
            menuView.PlayButtonClicked += OnPlayButtonClicked;
            
            subjectsView.MoveToNextCategoryRequested += OnSubjectButtonClicked;
            subjectsView.ReturnRequested += ReturnToMainMenu;
            
            classesView.MoveToNextCategoryRequested += OnClassButtonClicked;
            classesView.ReturnRequested += ReturnToSubjects;
            
            themesView.ReturnRequested += ReturnToClasses;
        }

        private void ReturnToClasses()
        {
            themesView.Hide();
            classesView.Show();
        }

        private void ReturnToSubjects()
        {
            classesView.Hide();
            subjectsView.Show();
        }

        private void ReturnToMainMenu()
        {
            subjectsView.Hide();
            menuView.Show();
        }

        private void OnClassButtonClicked(Class obj)
        {
            CurrentClass = obj;
            
            classesView.Hide();
            themesView.ShowWithItems(obj.Items);
        }

        private void OnSubjectButtonClicked(Subject obj)
        {
            CurrentSubject = obj;
            
            subjectsView.Hide();
            classesView.ShowWithItems(obj.Items);
        }

        private void OnPlayButtonClicked()
        {
            menuView.Hide();
            subjectsView.ShowWithItems(_subjectsService.Subjects);
        }
    }
}
