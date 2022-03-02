using Database.Services;
using Menu;
using Models;
using Renderers.Classes;
using Renderers.Subjects;
using Renderers.Themes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;
using Views.Dissolve;
using Zenject;

public class QuestionsSceneLoader : MonoBehaviour
{
    [SerializeField] private MenuItemViewSwitcher viewSwitcher;
    [SerializeField] private SubjectsView subjectView;
    [SerializeField] private ClassesView classView;
    [SerializeField] private ThemeView themeView;
    [SerializeField] private LoadImageView loadImageView;
    
    [SerializeField] private float showTime = 0.5f;
    [SerializeField] private float textHideTime = 0.2f;
    
    private IQuestionsService _questionsService;
    private ISubjectsService _subjectsService;

    [Inject]
    private void Construct(IQuestionsService questionsService)
    {
        _questionsService = questionsService;
    }

    [Inject]
    private void Construct(ISubjectsService subjectsService)
    {
        _subjectsService = subjectsService;
    }
    
    private void OnEnable()
    {
        themeView.MoveToNextCategoryRequested += SetQuestionsByTheme;
        subjectView.LoadByWholeCategoryRequested += LoadByAllSubjects;
        classView.LoadByWholeCategoryRequested += LoadByWholeSubject;
        themeView.LoadByWholeCategoryRequested += LoadByWholeClass;
    }

    private void OnDisable()
    {
        themeView.MoveToNextCategoryRequested -= SetQuestionsByTheme;
        subjectView.LoadByWholeCategoryRequested -= LoadByAllSubjects;
        classView.LoadByWholeCategoryRequested -= LoadByWholeSubject;
        themeView.LoadByWholeCategoryRequested -= LoadByWholeClass;
    }

    private void LoadByWholeClass()
    {
        loadImageView.Show(showTime, () =>
        {
            _questionsService.SetQuestionsToLoad(_subjectsService.GetAllByAllThemes(viewSwitcher.CurrentClass));
            loadImageView.HideText(textHideTime, LoadLevelScene);
        });
    }

    private void LoadByWholeSubject()
    {
        loadImageView.Show(showTime, () =>
        {
            _questionsService.SetQuestionsToLoad(_subjectsService.GetAllByAllClasses(viewSwitcher.CurrentSubject));
            loadImageView.HideText(textHideTime, LoadLevelScene);
        });
    }

    private void LoadByAllSubjects()
    {
        loadImageView.Show(showTime, () =>
        {
            _questionsService.SetQuestionsToLoad(_subjectsService.GetAllByAllSubjects());
            loadImageView.HideText(textHideTime, LoadLevelScene);
        });
    }

    private void SetQuestionsByTheme(Theme theme)
    {
        loadImageView.Show(showTime, () =>
        {
            _questionsService.SetQuestionsToLoad(theme.Items);
            loadImageView.HideText(textHideTime, LoadLevelScene);
        });
    }

    private void LoadLevelScene()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
