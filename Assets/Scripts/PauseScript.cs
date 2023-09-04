using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PausedUI;
    private bool isPaused = false;

    public void TogglePause()
    {
        if (!isPaused)
        {
            PausedUI.SetActive(true);
            Time.timeScale = 0; // Oyun zamanını duraklat
            isPaused = true;
        }
        else
        {
            PausedUI.SetActive(false);
            Time.timeScale = 1; // Oyun zamanını devam ettir
            isPaused = false;
        }
    }
}
