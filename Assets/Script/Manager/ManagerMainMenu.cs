using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMainMenu : MonoBehaviour
{
    public void GetScene(int number)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(number);
    }

    public void ExitApplication() => Application.Quit();
}
