using UnityEngine.SceneManagement;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public string currentScene;
    private bool EndlessMode=false;
    private GManager gManager;
    public int Difficulty;
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GManager>();
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Endless")
        {
            EndlessMode = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
