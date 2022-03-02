using DG.Tweening;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using Views.Base;

namespace Views
{
    public class DifficultyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private DifficultyColor difficultyColor;
        
        private ColorByDifficulty _color;

        public void Render(string type)
        {
            text.text = type.ToUpper();

            _color = difficultyColor.GetColorByDifficulty(type);
            
            text.color = _color.Color;
        }
    }
}
