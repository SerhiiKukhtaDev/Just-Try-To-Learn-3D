using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelShaderAnimation : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float time;

    [SerializeField] private UnityEvent onComplete;

    private Material _material;
    private float _elapsedTime;
    
    private static readonly int Cutoff = Shader.PropertyToID("_Cutoff");

    private void Start()
    {
        _material = image.material;
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        _elapsedTime = 0;
        
        while (_elapsedTime <= time)
        {
            float value = Mathf.Lerp(0, 1, _elapsedTime / time);
            _material.SetFloat(Cutoff, value);

            _elapsedTime += Time.deltaTime;

            yield return null;
        }
        
        gameObject.SetActive(false);
        _material.SetFloat(Cutoff, 1);
        
        onComplete?.Invoke();
    }
}
