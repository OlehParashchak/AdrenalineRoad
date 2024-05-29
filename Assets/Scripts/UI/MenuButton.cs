using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public static void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
