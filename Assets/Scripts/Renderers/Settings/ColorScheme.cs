using System;
using UnityEngine;

namespace Renderers.Settings
{
    [Serializable]
    public class ColorScheme
    {
        [SerializeField] private SkyBoxSettings boxSettings;
        [SerializeField] private ButtonSetting buttonSettings;
        
        public ButtonSetting ButtonSettings => buttonSettings;

        public SkyBoxSettings BoxSettings => boxSettings;
    }
}
