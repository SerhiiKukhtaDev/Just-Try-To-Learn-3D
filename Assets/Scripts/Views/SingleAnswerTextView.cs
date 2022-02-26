using Lean.Gui;
using ScriptableObjects.Answers.Base;
using UnityEngine;
using UnityEngine.UI;
using Views.Base;

namespace Views
{
    public class SingleAnswerTextView : View
    {
        [SerializeField] private LeanButton template;
        [SerializeField] private Transform parent;
        
        public override void Render(IContainQuestionData data)
        {
            foreach (var dataAnswer in data.Answers)
            {
                var item = Instantiate(template, parent);
                item.GetComponentInChildren<Text>().text = dataAnswer;
            }
        }
    }
}
