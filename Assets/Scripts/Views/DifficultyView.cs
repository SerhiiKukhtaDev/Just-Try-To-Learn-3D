using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class DifficultyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private DifficultyColor difficultyColor;

        public void Render(string type)
        {
            text.text = type.ToUpper();
            text.color = difficultyColor.GetColorByDifficulty(type);
        }
    }
}
