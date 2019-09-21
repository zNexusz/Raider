using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Text EnemyCount;
    private int EnemyIngame;

    // Update is called once per frame
    void Update()
    {
        EnemyIngame = GameObject.Find("GameManager").GetComponent<GManager>().killed;
        EnemyCount.text = EnemyIngame.ToString("0");
    }
}
