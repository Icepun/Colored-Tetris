using System.Net;
using UnityEngine;

public class Jokers : MonoBehaviour
{
    public AudioSource jokerSound;
    public GameObject spawnPoint; // Bu, Inspector'da atayabileceğiniz spawnPoint nesnesidir.

    public void RemoveBars(int howManyBars)
    {
        int barsDestroyed = 0;
        jokerSound.Play();

        // SpawnPoint'in tüm child nesnelerini döngüye alalım
        for (int i = 0; i < spawnPoint.transform.childCount; i++)
        {
            Transform child = spawnPoint.transform.GetChild(i);

            // Eğer child objesi "coloredBar" tag'ine sahipse, yok edelim
            if (true)
            {
                Destroy(child.gameObject);
                barsDestroyed++;

                // Belirlenen sayıda çubuk yok edildiyse döngüyü sonlandırabiliriz
                if (barsDestroyed >= howManyBars)
                {
                    break;
                }
            }
        }
    }

    // Diğer methodları da buraya ekleyebilirsiniz
    public void FirstJoker()
    {
        if (GameManager.jokerScore >= 50)
        {
            RemoveBars(2);
            GameManager.endPoints -= 2;
            if (GameManager.endPoints < 0) GameManager.endPoints = 0;

            GameManager.jokerScore -= 50;
        }
        
    }

    public void SecondJoker()
    {
        if (GameManager.jokerScore >= 100)
        {
            RemoveBars(5);
            GameManager.endPoints -= 5;
            if (GameManager.endPoints < 0) GameManager.endPoints = 0;
            GameManager.jokerScore -= 100;
        }
    }

    public void ThirdJoker()
    {
        if (GameManager.jokerScore >= 150)
        {
            RemoveBars(10);
            GameManager.endPoints -= 10;
            if (GameManager.endPoints < 0) GameManager.endPoints = 0;
            GameManager.jokerScore -= 150;
        }
    }

    public void FourthJoker()
    {
        if (GameManager.jokerScore >= 200)
        {
            RemoveBars(15);
            GameManager.endPoints -= 15;
            if (GameManager.endPoints < 0) GameManager.endPoints = 0;
            GameManager.jokerScore -= 200;
        }
    }
}
