using DG.Tweening;
using Questions;
using UnityEngine;
using Views;

public class TestResultPanel : MonoBehaviour
{
    [SerializeField] private ResultTestView resultTextView;
    [SerializeField] private RectTransform panel;
    
    public void ShowResult(TestResult result)
    {
        resultTextView.Render(result);
        panel.DOAnchorPos(Vector2.zero, 0.5f).SetAutoKill();
    }
}
