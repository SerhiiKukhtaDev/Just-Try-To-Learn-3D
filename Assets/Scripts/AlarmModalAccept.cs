using System.Collections;
using DG.Tweening;
using Lean.Gui;
using UnityEngine;
using UnityEngine.UI;

public class AlarmModalAccept : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private LeanButton button;
    [SerializeField] private float delay = 2f;
    [SerializeField] private LeanWindow window;

    [SerializeField] private Image image;
    [SerializeField] private Color interactableColor;
    [SerializeField] private Color nonInteractableColor;
    
    
    
    private void Start()
    {
        image.color = nonInteractableColor;
        button.interactable = false;
    }

    private void OnEnable()
    {
        var watched= PlayerPrefs.GetInt("ModalWatched");
        
        if(watched == 1) return;
        
        StartCoroutine(WaitForDelay());
    }

    private IEnumerator WaitForDelay()
    {
        yield return new WaitForSeconds(delay);
        
        window.TurnOn();

        text.DOCounter(5, 1, 5).SetDelay(1f).SetEase(Ease.Linear).OnComplete(() =>
        {
            button.interactable = true;
            text.text = "Ясно!";

            image.DOColor(interactableColor, 0.5f).SetAutoKill();
            PlayerPrefs.SetInt("ModalWatched", 1);
        }).SetAutoKill();
    }
}
