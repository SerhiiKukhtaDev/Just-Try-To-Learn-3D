using System.Collections.Generic;
using UnityEngine;

public class Renderer : MonoBehaviour
{
    [SerializeField] private RectTransform template;
    [SerializeField] private Transform parent;
    
    [SerializeField] private int count;

    private const int StartMinAnchorY = 0;
    private const int StartMaxAnchorY = 1;

    private List<Vector2> _nextYAnchors;

    private void Start()
    {
        _nextYAnchors = new List<Vector2>();

        float prevValueMin = StartMinAnchorY;
        float prevValueMax = StartMaxAnchorY;
        
        _nextYAnchors.Add(new Vector2(StartMinAnchorY, StartMaxAnchorY));

        for (float i = 0; i < count - 1; i++)
        {
            _nextYAnchors.Add(new Vector2(--prevValueMin, --prevValueMax));
        }
        
        foreach (var nextYAnchor in _nextYAnchors)
        {
            var ins = Instantiate(template, parent);
            ins.anchorMin = new Vector2(StartMinAnchorY, nextYAnchor.x);
            ins.anchorMax = new Vector2(StartMaxAnchorY, nextYAnchor.y);
        }
    }
}
