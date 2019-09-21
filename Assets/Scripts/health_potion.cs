using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_potion : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
		GameObject.FindObjectOfType<AudioManager>().Play("Potion_break");
		gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.6f);
        gameObject.GetComponent<ParticleSystem>().Stop();
    }
}
