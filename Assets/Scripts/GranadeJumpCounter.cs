using UnityEngine;

public class GranadeJumpCounter : MonoBehaviour
{
    public int StopJ;
    // Start is called before the first frame update
    void Start()
    {
        StopJ = 0;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BreakBlock"))
        {
            StopJ++;
        }
    }
}
