using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coloredBar : MonoBehaviour
{
    private float fallSpeed = 1;

    private Rigidbody2D rb2D;

    public Color[] colors;

    private void Start()
    {
        int randomIndex = Random.Range(0, colors.Length);
        gameObject.GetComponent<Image>().color = colors[randomIndex];
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb2D.velocity = new Vector2(0f, -fallSpeed); // Düþme hýzýný ayarla
    }
}
