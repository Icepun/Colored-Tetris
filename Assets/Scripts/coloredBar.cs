using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class coloredBar : MonoBehaviour
{
    private float fallSpeedIncrement = 0.1f; // Hýzýn arttýrýlacaðý miktar
    private int fallSpeedMultipler; // Hýzýn kaç ile çarpýlacaðýný belirler
    private float currentFallSpeed; // Baþlangýç hýzý

    private Rigidbody2D rb2D;
    private bool isMoving = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        fallSpeedMultipler = GameManager.score / 40;
        currentFallSpeed = 0.5f + fallSpeedIncrement * fallSpeedMultipler;
    }

    private void Update()
    {
        if (isMoving)
        {
            rb2D.velocity = new Vector2(0f, -currentFallSpeed);
        }

        else
        {
            rb2D.gravityScale = 0;
            rb2D.angularVelocity = 0;
            rb2D.velocity = Vector2.zero;
            rb2D.mass = 0;
        }
    }

    public Color GetCurrentColor()
    {
        return GetComponent<Image>().color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("endPoint"))
        {
            isMoving = false;
            gameObject.tag = "endPoint";
            GameManager.endPoints++;
        }
    }
}
