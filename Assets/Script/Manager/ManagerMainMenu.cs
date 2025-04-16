using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMainMenu : MonoBehaviour
{
    public void GetScene(int number) => SceneManager.LoadScene(number);

    public void ExitApplication() => Application.Quit();
}
