using System;
using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;
using Views.Questions;

public class ShowOverflowedTextModalWindow : MonoBehaviour
{
    [SerializeField] private OverflowedAnswerTextQuestionView view;
    [SerializeField] private LeanWindow modal;
    [SerializeField] private Text modalText;
    
    private void OnEnable()
    {
        view.ShowOverflowedTextRequested += ShowModal;
    }

    private void ShowModal(string obj)
    {
        modal.TurnOn();
        modalText.text = obj;
    }
}
