using UnityEngine;

public class ExitConfirmation : MonoBehaviour
{
    public GameObject exitConfirmationUI;
    private bool isGamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                Time.timeScale = 0; // Oyun zamanını duraklat
                exitConfirmationUI.SetActive(true);
                isGamePaused = true;
            }
            else
            {
                Time.timeScale = 1; // Oyun zamanını devam ettir
                exitConfirmationUI.SetActive(false);
                isGamePaused = false;
            }
        }
    }

    public void ConfirmExit()
    {
        Application.Quit();
    }

    public void CancelExit()
    {
        Time.timeScale = 1; // Oyun zamanını devam ettir
        exitConfirmationUI.SetActive(false);
        isGamePaused = false;
    }
}
