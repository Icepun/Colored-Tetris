using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class miniBar : MonoBehaviour
{
    public float moveSpeed = 150f;
    public float minX = -300f;
    public float maxX = 300f;

    public Color[] colors;
    private int colorIndex = 0; // Mevcut renk index'i
    private float colorChangeInterval = 2f; // Renk deðiþim aralýðý
    private float colorChangeTimer = 0f; // Renk deðiþim zamanlayýcýsý

    private bool movingRight = true; // baþlangýçta saða mý hareket etsin?

    private RectTransform rectTransform;
    private Image image;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        rectTransform.anchoredPosition = new Vector2(0f, -800f);

        image.color = colors[0];
    }

    private void Update()
    {
        MoveMiniBar();
        ChangeColor();
    }

    private void MoveMiniBar()
    {
        float movement = moveSpeed * Time.deltaTime;

        if (movingRight)
        {
            rectTransform.anchoredPosition += new Vector2(movement, 0f);
            if (rectTransform.anchoredPosition.x >= maxX)
            {
                movingRight = false;
            }
        }
        else
        {
            rectTransform.anchoredPosition -= new Vector2(movement, 0f);
            if (rectTransform.anchoredPosition.x <= minX)
            {
                movingRight = true;
            }
        }
    }

    private void ChangeColor()
    {
        colorChangeTimer += Time.deltaTime;
        if (colorChangeTimer >= colorChangeInterval)
        {
            colorIndex = (colorIndex + 1) % colors.Length;
            image.color = colors[colorIndex];
            colorChangeTimer = 0f;
        }
    }
}
