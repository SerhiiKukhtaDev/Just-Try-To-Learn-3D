using System;
using UnityEngine;
using UnityEngine.UI;

namespace Texts
{
    public class LoadingTextAnimation : MonoBehaviour
    {
        [SerializeField] private float changeTime;
        
        [SerializeField] private Text target;
        
        [SerializeField] private string secondFrameText;
        [SerializeField] private string thirdFrameText;

        private string _firstFrameText;
        private string _currentText;
        private float _elapsedTime;

        private void Start()
        {
            _currentText = _firstFrameText =  target.text;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > changeTime && _currentText == target.text)
            {
                _elapsedTime = 0;
                target.text = _currentText = secondFrameText;
            } 
            
            if (_elapsedTime > changeTime && _currentText == secondFrameText)
            {
                _elapsedTime = 0;
                target.text = _currentText = thirdFrameText;
            }
            
            if (_elapsedTime > changeTime && _currentText == thirdFrameText)
            {
                _elapsedTime = 0;
                target.text = _currentText = _firstFrameText;
            }
        }

        private void OnDisable()
        {
            _elapsedTime = 0;
        }
    }
}
