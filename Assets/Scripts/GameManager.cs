using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image coloredBarPrefab; // Prefab olarak eklediðiniz coloredBar öðesi
    public RectTransform spawnArea; // Canvas içinde spawn yapýlacak alan
    public Color[] colors; // Renk array'i

    private float spawnInterval = 5f; // Yeni coloredBar'ýn spawn aralýðý
    private float spawnTimer = 0f; // Zamanlayýcý

    private void Start()
    {
        // Ýlk coloredBar spawn'ý için çaðýrýlmýyor, Update içinde kullanýlacak.
    }

    private void Update()
    {
        // Zamanlayýcýyý güncelle
        spawnTimer += Time.deltaTime;

        // Belirli bir aralýkta yeni coloredBar spawn'ý yap
        if (spawnTimer >= spawnInterval)
        {
            SpawnColoredBar();
            spawnTimer = 0f; // Zamanlayýcýyý sýfýrla
        }
    }

    private void SpawnColoredBar()
    {
        // Spawn alaný içinde rastgele bir pozisyon seç
        Vector2 spawnPosition = GetRandomSpawnPosition();

        // coloredBarPrefab'i spawnPosition'da instantiate et
        Image newColoredBar = Instantiate(coloredBarPrefab, spawnPosition, Quaternion.identity);

        // Renk atamasý
        int randomIndex = Random.Range(0, colors.Length);
        newColoredBar.color = colors[randomIndex];

        // Canvas altýna ekle
        newColoredBar.transform.SetParent(spawnArea, false);
    }

    private Vector2 GetRandomSpawnPosition()
    {
        float x = 0;
        float y = Random.Range(spawnArea.rect.min.y, spawnArea.rect.max.y);
        return new Vector2(x, y);
    }
}
