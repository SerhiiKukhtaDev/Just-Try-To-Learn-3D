using UnityEngine;

namespace Utils
{
    public static class CanvasUtils
    {
        public static float GetCanvasHeightWithScaleFactor(this Canvas canvas)
        {
            return  canvas.GetComponent<RectTransform>().rect.height * canvas.scaleFactor;
        }
    }
}