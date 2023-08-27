using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coloredBar : MonoBehaviour
{
    public float startYPos = 0;
    private float fallSpeed = 1000;

    private RectTransform rectTransform;

    public Color[] colors;

    private void Start()
    {
        int randomIndex = Random.Range(0, colors.Length);
        gameObject.GetComponent<Image>().color = colors[randomIndex];
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0f, startYPos);
        //InvokeRepeating("Fall", 0f, 1f); // Her saniye düþme iþlevini çaðýr
    }

    private void Fall()
    {
        float newY = rectTransform.anchoredPosition.y - (fallSpeed * Time.deltaTime);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
    }
}
