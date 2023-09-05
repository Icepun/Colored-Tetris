using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PausedUI;
    public GameObject[] toggleObjects;
    private bool isPaused = false;

    public void TogglePause()
    {
        if (!isPaused)
        {
            PausedUI.SetActive(true);
            Time.timeScale = 0; // Oyun zamanını duraklat
            ToggleObjectsActive(false);
            isPaused = true;
        }
        else
        {
            PausedUI.SetActive(false);
            Time.timeScale = 1; // Oyun zamanını devam ettir
            ToggleObjectsActive(true);
            isPaused = false;
        }
    }

    private void ToggleObjectsActive(bool setActive)
    {
        foreach (GameObject obj in toggleObjects)
        {
            obj.SetActive(setActive);
        }
    }
}
