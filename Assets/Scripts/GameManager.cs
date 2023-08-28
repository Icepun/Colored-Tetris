using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image coloredBarPrefab; // Prefab olarak eklediðiniz coloredBar öðesi
    public RectTransform spawnArea; // Canvas içinde spawn yapýlacak alan
    public TextMeshProUGUI scoreText;
    public int maxEndPoints;
    public Color[] colors; // Renk array'i

    public Image minibarObj;
    private List<coloredBar> spawnedBars = new List<coloredBar>();

    private float spawnInterval = 5f; // Yeni coloredBar'ýn spawn aralýðý
    private float spawnTimer = 0f; // Zamanlayýcý

    public static int score = 0;
    public static int endPoints = 0;

    private void Start()
    {
        endPoints = 0;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval && endPoints < maxEndPoints + 3)
        {
            SpawnColoredBar();
            spawnTimer = 0f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            CheckColorsAndScore();
        }

        if (endPoints >= maxEndPoints + 3)
        {
            Time.timeScale = 0;
        }
    }

    private void SpawnColoredBar()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        Image newColoredBar = Instantiate(coloredBarPrefab, spawnPosition, Quaternion.identity);

        int randomIndex = Random.Range(0, colors.Length);
        newColoredBar.color = colors[randomIndex];

        newColoredBar.transform.SetParent(spawnArea, false);

        // Yeni coloredBar'ý listeye ekle
        spawnedBars.Add(newColoredBar.GetComponent<coloredBar>());
    }

    private void CheckColorsAndScore()
    {
        foreach (coloredBar bar in spawnedBars)
        {
            if (bar != null)
            {
                if (!bar.CompareTag("endPoint")) // Eðer endPoint tag'ine sahip deðilse
                {
                    Color activeColor = bar.GetCurrentColor();
                    Color miniBarColor = minibarObj.GetComponent<Image>().color;

                    float colorDifference = CalculateColorDifference(activeColor, miniBarColor);

                    if (colorDifference <= 0.1f)
                    {
                        score += 10;
                        scoreText.text = score.ToString();
                        Destroy(bar.gameObject);
                        spawnedBars.Remove(bar); // Listedeki coloredBar'ý kaldýr
                        break; // Bir eþleþme bulunduðunda döngüden çýk
                    }
                }
            }
        }
    }

    private float CalculateColorDifference(Color color1, Color color2)
    {
        float rDiff = Mathf.Abs(color1.r - color2.r);
        float gDiff = Mathf.Abs(color1.g - color2.g);
        float bDiff = Mathf.Abs(color1.b - color2.b);

        return (rDiff + gDiff + bDiff) / 3f;
    }

    private Vector2 GetRandomSpawnPosition()
    {
        float x = 0;
        float y = Random.Range(spawnArea.rect.min.y, spawnArea.rect.max.y);
        return new Vector2(x, y);
    }
}
