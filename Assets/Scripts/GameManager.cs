using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Voodoo.Utils;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour
{
    public  GameObject gameOverScreen;
    public AudioSource breakSound;

    public Image coloredBarPrefab; // Prefab olarak ekledi�iniz coloredBar ��esi
    public RectTransform spawnArea; // Canvas i�inde spawn yap�lacak alan
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI jokerText;
    public TextMeshProUGUI highScoreText;
    public int maxEndPoints;
    public Color[] colors; // Renk array'i

    public Image minibarObj;
    private List<coloredBar> spawnedBars = new List<coloredBar>();

    private float spawnInterval = 6f; // Yeni coloredBar'�n spawn aral���
    private float spawnTimer = 0f; // Zamanlay�c�

    public static int score = 0;
    public static int jokerScore = 0;
    public static int highScore = 0;
    public static int endPoints = 0;

    public GameObject clickDetection;

    public static bool isStarted = false;
    public GameObject tapToStart;
    public GameObject jokers;
    public TextMeshProUGUI yourScore;
    public GameObject particle;
    public GameObject newHighScore;
    public GameObject bgColorChange;
    
    public GameObject PauseBtn; 

    public Color joker1Color;
    public Color joker2Color;
    public Color joker3Color;
    public Color joker4Color;

    public InterstitialAD interstitial;

    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            interstitial.LoadInterstitialAd();
        });
        clickDetection.SetActive(false);
        bgColorChange.SetActive(false);
        particle.SetActive(false);
        tapToStart.SetActive(true);
        jokers.SetActive(false);
        isStarted = false;
        newHighScore.SetActive(false);
        gameOverScreen.SetActive(false);
        PauseBtn.SetActive(false);
        endPoints = 0;
        score = 0;
        jokerScore = PlayerPrefs.GetInt("jokerScore");
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = highScore.ToString();
    }

    private void Update()
    {
        if (isStarted)
        {
            scoreText.text = score.ToString();
            jokerText.text = jokerScore.ToString();

            if (score > highScore)
            {
                scoreText.color = Color.yellow;
            }

            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval && endPoints < maxEndPoints + 3)
            {
                SpawnColoredBar();
                spawnTimer = 0f;
            }

            //if (Input.GetMouseButtonDown(0))
            //{
            //    CheckColorsAndScore();
            //}

            if (endPoints >= maxEndPoints + 3)
            {
                gameOverScreen.SetActive(true);
                jokers.SetActive(false);
                isStarted = false;
                yourScore.text = "Your Score: " + score.ToString();
                Vibrations.Haptic(HapticTypes.MediumImpact);
                PlayerPrefs.SetInt("jokerScore", jokerScore);
                Debug.Log("Game Over");

                if (score >= highScore)
                {
                    newHighScore.SetActive(true);
                    highScore = score;
                    PlayerPrefs.SetInt("highScore", highScore);
                }
            }

            if (jokerScore < 50) jokerText.color = Color.black;
            else if (jokerScore >= 50 && jokerScore < 100) jokerText.color = joker1Color;
            else if (jokerScore >= 100 && jokerScore < 150) jokerText.color = joker2Color;
            else if (jokerScore >= 150 && jokerScore < 200) jokerText.color = joker3Color;
            else if (jokerScore >= 200) jokerText.color = joker4Color;

            if (score >= 50 && score < 100) spawnInterval = 5;
            else if (score >= 100 && score < 150) spawnInterval = 4;
            else if (score >= 150 && score < 200) spawnInterval = 3;
            else if (score >= 200) spawnInterval = 2;
        }
    }

    public void GameStart()
    {
        ShowInterstitial();
        clickDetection.SetActive(true);
        bgColorChange.SetActive(true);
        isStarted = true;
        tapToStart.SetActive(false);
        jokers.SetActive(true);
        PauseBtn.SetActive(true);
    }

    public void ShowInterstitial()
    {
        interstitial.ShowAd();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void SpawnColoredBar()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        Image newColoredBar = Instantiate(coloredBarPrefab, spawnPosition, Quaternion.identity);

        int randomIndex = Random.Range(0, colors.Length);
        newColoredBar.color = colors[randomIndex];

        newColoredBar.transform.SetParent(spawnArea, false);

        // Yeni coloredBar'� listeye ekle
        spawnedBars.Add(newColoredBar.GetComponent<coloredBar>());
    }

    public void CheckColorsAndScore()
    {
        foreach (coloredBar bar in spawnedBars)
        {
            if (bar != null && !bar.CompareTag("endPoint")) 
            {
                Color activeColor = bar.GetCurrentColor();
                Color miniBarColor = minibarObj.GetComponent<Image>().color;

                float colorDifference = CalculateColorDifference(activeColor, miniBarColor);

                if (colorDifference <= 0.1f)
                {
                    PlayBreakSound();
                    Vibrations.Haptic(HapticTypes.LightImpact);
                    score += 10;
                    jokerScore += 10;

                    particle.SetActive(false);
                    particle.SetActive(true);
                    particle.transform.position = bar.gameObject.transform.position;
                    Destroy(bar.gameObject);
                    spawnedBars.Remove(bar);
                    break; 
                }
                else
                {
                    bar.gameObject.tag = "endPoint";
                    bar.currentFallSpeed = bar.currentFallSpeed * 8f;
                    break; 
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

    public void PlayBreakSound()
    {
        if (!breakSound.isPlaying)  // eğer ses çalmıyorsa çalmasını sağlar
            {
                breakSound.Play();
            }
    }
}
