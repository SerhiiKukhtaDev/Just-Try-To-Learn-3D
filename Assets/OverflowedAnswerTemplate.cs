using Lean.Gui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OverflowedAnswerTemplate : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private LeanButton button;

    public TMP_Text Text => text;

    public LeanButton Button => button;
}
