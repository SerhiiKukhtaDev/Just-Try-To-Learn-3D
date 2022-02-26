using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class ItemScroll : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    public event Action<Vector3, ItemScroll> MoveEnd;

    public RectTransform RectTransform => rectTransform;

    public void MoveUp(float lenght, float time, Ease moveEase)
    {
        DoMoveY(rectTransform, rectTransform.position.y - lenght, time, moveEase);
    }

    
    public void MoveDown(float lenght, float time, Ease moveEase)
    {
        DoMoveY(rectTransform, rectTransform.position.y + lenght, time, moveEase).OnComplete(() =>
        {
            MoveEnd?.Invoke(transform.position, this);
        });
    }

    private TweenerCore<Vector3, Vector3, VectorOptions> DoMoveY(Transform target, float delta, float time, 
        Ease ease, TweenCallback onEnd = null)
    {
        return target.DOMoveY(delta, time).SetEase(ease).SetAutoKill();
    }
}
