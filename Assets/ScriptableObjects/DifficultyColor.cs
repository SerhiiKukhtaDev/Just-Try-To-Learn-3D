using System;
using System.Linq;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class DifficultyColor : ScriptableObject
    {
        [SerializeField] private ColorByDifficulty[] difficulties = new ColorByDifficulty[4];

        public Color GetColorByDifficulty(string difficulty)
        {
            var color = difficulties.FirstOrDefault(d => d.Difficulty == difficulty).Color;

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

        public string Difficulty => difficulty;

        public Color Color => color;
    }
}
