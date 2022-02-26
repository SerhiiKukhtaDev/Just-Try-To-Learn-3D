using System;
using UnityEngine;

namespace Renderers.Settings
{
    [Serializable]
    public class SkyBoxSettings : IRenderSettings
    {
        [SerializeField] private  Color color1;
        [SerializeField] private  Color color2;

        public Color Color1 => color1;

        
        public Color Color2 => color2;
    }
}