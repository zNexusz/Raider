using UnityEngine;

public class StatusCurrency : MonoBehaviour
{
    public int MoneyEarned;
    public int ThisScore;
    public int ThisKilled;
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");//!! enemy counter

        for (int i = 0; i - 1 < enemies.Length; ++i)
        {
            PlayerPrefs.SetInt("EnemyCount", i);
        }

      
    }

    // Update is called once per frame
    public void KillPlus()
    {
        ThisKilled++;
    }

    public void ScorePlus()
    {
        ThisScore += 10;
    }

    public void MoneyPlus()
    {
        MoneyEarned += 5;
    }

    public void SaveMoney()
    {
        int allMoney = PlayerPrefs.GetInt("5631");
        PlayerPrefs.SetInt("5631", allMoney + MoneyEarned);
    }
}
