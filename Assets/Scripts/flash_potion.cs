using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash_potion : MonoBehaviour
{
    public Animator anim;
    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        StartCoroutine(Playanim());
    }

    IEnumerator Playanim()
    {
        GameObject.Find("GameManager").GetComponent<GManager>().Enemyflash = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
		GameObject.FindObjectOfType<AudioManager>().Play("Potion_break");
		anim.SetBool("Flash", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("Flash", false);
        yield return new WaitForSeconds(4.55f);
        GameObject.Find("GameManager").GetComponent<GManager>().Enemyflash = false;
        Destroy(gameObject);
    }
  
}
