using System;
using System.Linq;
using UnityEngine;
using Views.Base;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class DifficultyColor : ScriptableObject
    {
        [SerializeField] private ColorByDifficulty[] difficulties = new ColorByDifficulty[4];
        
        public ColorByDifficulty GetColorByDifficulty(string difficulty)
        {
            var color = difficulties.FirstOrDefault(d => d.Difficulty == difficulty);

            if (color == null)
                throw new Exception("Can't find color to given difficulty type");
            
            return color;
        }
    }

    [Serializable]
    public class ColorByDifficulty
    {
        [SerializeField] private string difficulty;
        [SerializeField] private Color color;
        [SerializeField] private Color wrongAnswerColor;
        [SerializeField] private Color rightAnswerColor;

        public string Difficulty => difficulty;

        public Color Color => color;

        public Color WrongAnswerColor => wrongAnswerColor;

        public Color RightAnswerColor => rightAnswerColor;
    }
}
