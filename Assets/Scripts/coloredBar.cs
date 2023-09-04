using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class coloredBar : MonoBehaviour
{
    private float fallSpeedIncrement = 0.1f; // Hızın arttırılacağı miktar
    private int fallSpeedMultipler; // Hızın kaç ile çarpılacağını belirler
    public float currentFallSpeed; // Başlangıç hızı

    private Rigidbody2D rb2D;
    private bool isMoving = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        fallSpeedMultipler = GameManager.score / 40;
        currentFallSpeed = 0.5f + fallSpeedIncrement * fallSpeedMultipler;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (isMoving)
        {
            rb2D.velocity = new Vector2(0f, -currentFallSpeed);
        }
        else
        {
            // Barın hareketini durdur
            rb2D.velocity = Vector2.zero;

            // Barın diğer fiziksel etkileşimlerini kapat
            rb2D.gravityScale = 0;
            rb2D.angularVelocity = 0;
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
