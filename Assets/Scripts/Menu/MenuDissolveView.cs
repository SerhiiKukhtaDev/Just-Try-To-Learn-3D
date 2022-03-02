using UnityEngine;
using Views.Dissolve;

namespace Menu
{
    public class MenuDissolveView : MonoBehaviour
    {
        [SerializeField] private BackgroundDissolve backgroundDissolve;

        private void Start()
        {
            backgroundDissolve.ShowBackground(() => backgroundDissolve.gameObject.SetActive(false));
        }
    }
}
