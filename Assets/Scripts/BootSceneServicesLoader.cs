using System;
using System.Collections;
using Database.Base;
using Database.Interfaces;
using Database.Readers;
using Database.Services;
using Lean.Gui;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

public class BootSceneServicesLoader : MonoBehaviour
{
    [SerializeField] private LeanWindow wrongConnectionModal;
    [SerializeField] private UnityEvent failConnection;
    
    private ISubjectsService _subjectsService;

    [Inject]
    private void Construct(ISubjectsService subjectsService)
    {
        _subjectsService = subjectsService;
    }

    private void Start()
    {
        StartCoroutine(Load());
    }

    private async void LoadDatabaseData()
    {
        DatabaseConnection connection = new DatabaseConnection();

        try
        {
            var database = connection.Connect();
            
            ISubjectsCollectionReader reader = new SubjectsCollectionReader(database.SubjectsCollection);

            var subjects = await reader.ReadWithValidation();

            _subjectsService.SetSubjects(subjects);
            SceneManager.LoadScene("Scenes/MenuScene");
        }
        catch (Exception e)
        {
            wrongConnectionModal.TurnOn();
            failConnection?.Invoke();
        }
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(1f);
        
        LoadDatabaseData();
    }
}
