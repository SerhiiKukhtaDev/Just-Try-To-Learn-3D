using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class StatusPanel : ScriptableObject
    {
        [SerializeField] private AnswerStatusPanel rightAnswer;
        [SerializeField] private AnswerStatusPanel wrongAnswer;

        public AnswerStatusPanel GetPanelByAnswer(bool isRightAnswer)
        {
            return isRightAnswer ? rightAnswer : wrongAnswer;
        }
    }

    [Serializable]
    public class AnswerStatusPanel
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private List<string> randomTexts;
        [SerializeField] private Color background;

        public Sprite Icon => icon;

        public string Text => randomTexts.GetRandomElement();

        public Color Background => background;
    }
}
