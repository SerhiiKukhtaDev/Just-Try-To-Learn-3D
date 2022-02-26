using System;
using UnityEngine;

namespace Renderers.Settings
{
    [Serializable]
    public class ButtonSetting : IRenderSettings
    {
        [SerializeField] private Color buttonColor;
        [SerializeField] private Color textColor;

        public Color ButtonColor => buttonColor;

        
        public Color TextColor => textColor;
    }
}