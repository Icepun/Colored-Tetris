using UnityEngine;

public class ExitConfirmation : MonoBehaviour
{
    public GameObject PausedUI;
    public GameObject[] toggleObjects;
    public GameObject exitConfirmationUI;
    private bool isGamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                PauseGame();
                exitConfirmationUI.SetActive(true);
            }
            else
            {
                ResumeGame();
                exitConfirmationUI.SetActive(false);
                PausedUI.SetActive(false);
            }
        }
    }

    public void ConfirmExit()
    {
        Application.Quit();
    }

    public void CancelExit()
    {
        ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Oyun zamanını duraklat
        isGamePaused = true;
        ToggleObjectsActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Oyun zamanını devam ettir
        isGamePaused = false;
        ToggleObjectsActive(true);
        exitConfirmationUI.SetActive(false);
    }

    public void PauseButtonUIOn()
    {
        PausedUI.SetActive(true);
    }

    public void PauseButtonUIOff()
    {
        PausedUI.SetActive(false);
    }

    private void ToggleObjectsActive(bool setActive)
    {
        foreach (GameObject obj in toggleObjects)
        {
            obj.SetActive(setActive);
        }
    }
}
