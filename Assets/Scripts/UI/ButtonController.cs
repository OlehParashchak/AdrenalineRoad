using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] UIController uiController;

    public void PauseButton()
    {
        Time.timeScale = 0f;
        uiController.PausePanel.SetActive(true);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1f;
        uiController.PausePanel.SetActive(false);
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void SceneStart()
    {
        SceneManager.LoadScene(0);
    }
}
