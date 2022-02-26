using Renderers.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Renderers
{
    public class SkyBoxView : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void Render(SkyBoxSettings settings)
        {
            image.material.SetColor("_Color1", settings.Color1);
            image.material.SetColor("_Color2", settings.Color2);
        }
    }
}
