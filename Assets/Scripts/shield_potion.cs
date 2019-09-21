using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_potion : MonoBehaviour
{
    private int used;
    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        if (used < 1)
        {
            used++;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
			GameObject.FindObjectOfType<AudioManager>().Play("Potion_break");
			gameObject.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(0.6f);
            gameObject.GetComponent<ParticleSystem>().Stop(); 
        }
    }
}
