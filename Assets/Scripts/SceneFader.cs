using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneFader : MonoBehaviour
{
    public string FadeTo;
    public Animator anim;
    // Start is called before the first frame update
    
    public void FadeNow()
    {
        StartCoroutine(FadeCheck());
    }
    private IEnumerator FadeCheck()
    {
        anim.SetBool("FadeOut",true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(FadeTo);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("FadeOut",false);
    }
}
