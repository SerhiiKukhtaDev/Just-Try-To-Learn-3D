using System;
using System.Collections;
using UnityEngine;

namespace Views.Dissolve.Base
{
    public class DissolveView : MonoBehaviour
    {
        [SerializeField] private Texture texture;
        
        protected Material Material;
        private float _elapsedTime;

        private static readonly int DissolutionLevel = Shader.PropertyToID("_Level");

        private static readonly int Texture = Shader.PropertyToID("_NoiseTex");

        private static readonly int EdgeWidth = Shader.PropertyToID("_Edges");

        public virtual void Render(float startDissolution)
        {
            gameObject.SetActive(false);
            
            Material = new Material(Shader.Find("UI/Dissolve"));

            Material.SetFloat(DissolutionLevel, startDissolution);
            Material.SetFloat(EdgeWidth, 0);
            Material.SetTexture(Texture, texture);
        }

        protected IEnumerator ChangeBackground(float time, float startValue, float endValue, Action onEnd = null)
        {
            _elapsedTime = 0;

            while (_elapsedTime <= time)
            {
                float value = Mathf.Lerp(startValue, endValue, _elapsedTime / time);
                Material.SetFloat(DissolutionLevel, value);
                
                _elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            Material.SetFloat(DissolutionLevel, endValue);
            onEnd?.Invoke();
        }

        protected virtual void OnDestroy()
        {
            Destroy(Material);
        }
    }
}
