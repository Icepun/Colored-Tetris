using UnityEngine;

public class Jokers : MonoBehaviour
{
    public GameObject spawnPoint; // Bu, Inspector'da atayabileceğiniz spawnPoint nesnesidir.

    public void RemoveBars(int howManyBars)
    {
        int barsDestroyed = 0;

        // SpawnPoint'in tüm child nesnelerini döngüye alalım
        for (int i = 0; i < spawnPoint.transform.childCount; i++)
        {
            Transform child = spawnPoint.transform.GetChild(i);

            // Eğer child objesi "coloredBar" tag'ine sahipse, yok edelim
            if (child.CompareTag("coloredBar"))
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
        if (GameManager.score > 200)
        {
            RemoveBars(2);
            GameManager.score -= 200;
        }
        
    }

    public void SecondJoker()
    {
        if (GameManager.score > 400)
        {
            RemoveBars(5);
            GameManager.score -= 400;
        }
    }

    public void ThirdJoker()
    {
        if (GameManager.score > 800)
        {
            RemoveBars(10);
            GameManager.score -= 800;
        }
    }
}
