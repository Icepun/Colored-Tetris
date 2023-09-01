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
    private float colorChangeInterval = 1f; // Renk de�i�im aral���
    private float colorChangeTimer = 0f; // Renk de�i�im zamanlay�c�s�

    private bool movingRight = true; // ba�lang��ta sa�a m� hareket etsin?

    private RectTransform rectTransform;
    private Image image;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        rectTransform.anchoredPosition = new Vector2(0f, -800f);

        // Renkleri rastgele bir �ekilde kar��t�r
        ShuffleColorsArray(colors);

        image.color = colors[0];
    }

    private void Update()
    {
        if (GameManager.isStarted)
        {
            MoveMiniBar();
            ChangeColor();
        }
    }

    private void ShuffleColorsArray(Color[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = Random.Range(i, array.Length);
            Color temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
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
            int newColorIndex = GetNextColorIndex(); // Bir sonraki renk indexini al
            image.color = colors[newColorIndex];
            colorChangeTimer = 0f;
            colorIndex = newColorIndex; // Mevcut renk indexini g�ncelle
        }
    }

    private int GetNextColorIndex()
    {
        int newColorIndex = colorIndex + 1;

        // E�er yeni renk indexi mevcut renk dizisinin s�n�rlar�n� a�arsa, s�f�ra d�n
        if (newColorIndex >= colors.Length)
        {
            newColorIndex = 0;
        }

        return newColorIndex;
    }
}
