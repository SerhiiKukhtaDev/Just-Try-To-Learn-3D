using Models;
using Renderers.Themes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class QuestionsSceneLoader : MonoBehaviour
{
    [SerializeField] private ThemeView themeView;

    private IQuestionsService _questionsService;

    [Inject]
    private void Construct(IQuestionsService questionsService)
    {
        _questionsService = questionsService;
    }
    
    private void OnEnable()
    {
        themeView.MoveToNextCategoryRequested += SetQuestionsToLoad;
    }

    private void OnDisable()
    {
        themeView.MoveToNextCategoryRequested -= SetQuestionsToLoad;
    }

    private void SetQuestionsToLoad(Theme theme)
    {
        _questionsService.SetQuestionsToLoad(theme.Items);
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
