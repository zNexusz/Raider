using UnityEngine;
using UnityEngine.UI;

public class BombCount : MonoBehaviour
{
    public Text Count;

    // Update is called once per frame
    void Update()
    {
        Count.text = FindObjectOfType<PlayerGranade>().limit.ToString("0");
    }
}
