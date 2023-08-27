using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coloredBar : MonoBehaviour
{
    private float fallSpeed = 0.5f;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb2D.velocity = new Vector2(0f, -fallSpeed);
    }
}
