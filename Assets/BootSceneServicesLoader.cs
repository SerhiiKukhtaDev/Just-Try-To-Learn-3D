using Database.Base;
using Database.Interfaces;
using Database.Readers;
using Database.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class BootSceneServicesLoader : MonoBehaviour
{
    private ISubjectsService _subjectsService;

    [Inject]
    private void Construct(ISubjectsService subjectsService)
    {
        _subjectsService = subjectsService;
    }

    public async void LoadDatabaseData()
    {
        DatabaseConnection connection = new DatabaseConnection();
        var database = connection.Connect();

        ISubjectsCollectionReader reader = new SubjectsCollectionReader(database.SubjectsCollection);

        var subjects = await reader.ReadWithValidation();

        _subjectsService.SetSubjects(subjects);
        SceneManager.LoadScene("Scenes/MenuScene");
    }
}
