using UnityEngine;
using UnityEngine.SceneManagement;
using Views.Dissolve;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private BackgroundDissolve dissolve;

    public void LoadMenu()
    {
        dissolve.ShowBackground(() =>
        {
            SceneManager.LoadScene("Scenes/MenuScene");
        });
    }
}
