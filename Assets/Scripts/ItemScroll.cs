using DG.Tweening;
using UnityEngine;

public class ItemScroll : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;

    public void MoveUp(float lenght, float time, Ease moveEase)
    {
        DoMoveY(rectTransform, rectTransform.position.y - lenght, time, moveEase);
    }

    public void MoveDown(float lenght, float time, Ease moveEase)
    {
        DoMoveY(rectTransform, rectTransform.position.y + lenght, time, moveEase);
    }

    private void DoMoveY(Transform target, float delta, float time,
        Ease ease)
    {
        target.DOMoveY(delta, time).SetEase(ease).SetAutoKill();
    }
}
