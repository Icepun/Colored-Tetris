using UnityEngine;
using UnityEngine.UI;

public class BackgroundImageChange : MonoBehaviour
{
    public Image backgroundImage;
    public Color startColor;
    public Color endColor;
    public float duration = 60.0f; // Zaman geçtikçe tamamlanacak süre

    private float startTime;
    private bool forward = true;

    private void Start()
    {
        startTime = Time.time;
        backgroundImage.color = startColor;
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        float normalizedTime = Mathf.Clamp01(elapsedTime / duration);

        if (forward)
        {
            backgroundImage.color = Color.Lerp(startColor, endColor, normalizedTime);
        }
        else
        {
            backgroundImage.color = Color.Lerp(endColor, startColor, normalizedTime);
        }

        if (normalizedTime >= 1.0f)
        {
            startTime = Time.time;
            forward = !forward;
        }
    }
}