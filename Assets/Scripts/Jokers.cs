using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Voodoo.Utils;

public class Jokers : MonoBehaviour
{
    public AudioSource jokerSound;
    public GameObject spawnPoint; // Bu, Inspector'da atayabileceğiniz spawnPoint nesnesidir.

    public void RemoveBars(int howManyBars)
    {
        int barsDestroyed = 0;
        jokerSound.Play();
        Vibrations.Haptic(HapticTypes.MediumImpact);

        // SpawnPoint'in tüm child nesnelerini toplayalım ve ters sırada döngüye alalım
        List<Transform> coloredBars = new List<Transform>();

        for (int i = 0; i < spawnPoint.transform.childCount; i++)
        {
            Transform child = spawnPoint.transform.GetChild(i);
            if (child.CompareTag("endPoint"))
            {
                coloredBars.Add(child);
            }
        }

        // Tersten döngü yaparak son girenleri yok edelim
        for (int i = coloredBars.Count - 1; i >= 0; i--)
        {
            Destroy(coloredBars[i].gameObject);
            barsDestroyed++;

            // Belirlenen sayıda çubuk yok edildiyse döngüyü sonlandırabiliriz
            if (barsDestroyed >= howManyBars)
            {
                break;
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
