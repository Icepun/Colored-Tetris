using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image coloredBarPrefab; // Prefab olarak ekledi�iniz coloredBar ��esi
    public RectTransform spawnArea; // Canvas i�inde spawn yap�lacak alan
    public Color[] colors; // Renk array'i

    private float spawnInterval = 5f; // Yeni coloredBar'�n spawn aral���
    private float spawnTimer = 0f; // Zamanlay�c�

    private void Start()
    {
        // �lk coloredBar spawn'� i�in �a��r�lm�yor, Update i�inde kullan�lacak.
    }

    private void Update()
    {
        // Zamanlay�c�y� g�ncelle
        spawnTimer += Time.deltaTime;

        // Belirli bir aral�kta yeni coloredBar spawn'� yap
        if (spawnTimer >= spawnInterval)
        {
            SpawnColoredBar();
            spawnTimer = 0f; // Zamanlay�c�y� s�f�rla
        }
    }

    private void SpawnColoredBar()
    {
        // Spawn alan� i�inde rastgele bir pozisyon se�
        Vector2 spawnPosition = GetRandomSpawnPosition();

        // coloredBarPrefab'i spawnPosition'da instantiate et
        Image newColoredBar = Instantiate(coloredBarPrefab, spawnPosition, Quaternion.identity);

        // Renk atamas�
        int randomIndex = Random.Range(0, colors.Length);
        newColoredBar.color = colors[randomIndex];

        // Canvas alt�na ekle
        newColoredBar.transform.SetParent(spawnArea, false);
    }

    private Vector2 GetRandomSpawnPosition()
    {
        float x = 0;
        float y = Random.Range(spawnArea.rect.min.y, spawnArea.rect.max.y);
        return new Vector2(x, y);
    }
}
