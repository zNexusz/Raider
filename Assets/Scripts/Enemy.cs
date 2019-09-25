using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Variables
    public Animator animator;
	public float speed;
	public float stoppingDistance;
	public float AllowDistance;
	///dwn - y distance
	public float YDistance;
	Vector2 gyDistance;
	Vector2 pyDistance;
	//
	public float XDistance;
	Vector2 gxDistance;
	Vector2 pxDistance;
	//
	public int health;
	public GManager gManager;
    public Vector2 offset;
	private Rigidbody2D rb;
	public int killReward=5;
	//
	/*public float Cdistance;
	public float Csdistance;
	public Transform CheckPoint;
	public Vector2 offC;*/
	public PlayerShootTrigger PlayerShootTrigger;
	//
	public float timeBtwShots;
	public float startTimeBtwShots;
	public Transform player;
	public GameObject Player;
	public float choose=2;
	Vector3 dir;
	float angle;
    bool RunNow;
    //toxcolor
    int ColorON;
    bool dead;
    public SpriteRenderer opacity;
    float ColorChangeRate=0.1f;
    //weapon flip
    public GameObject child;
	public GameObject eBullet;

	float Bulletspeed;

	ObjectPooler objectPooler;
    //
     int kill;



    #endregion
    #region Methods

    void Start()
    {
        PlayerPrefs.SetInt("KillCount", 0);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = 1;
		timeBtwShots = startTimeBtwShots;
		StartCoroutine(Starting());
        kill = PlayerPrefs.GetInt("KillCount");
        opacity = gameObject.GetComponent<SpriteRenderer>();
        objectPooler = ObjectPooler.Instance;
    }

    IEnumerator Starting()
	{
		yield return new WaitForSeconds(0.5f);
		Player = GameObject.FindGameObjectWithTag("Player");
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//
		gManager = FindObjectOfType<GManager>();
		//
        RunNow = true;

    }

	void Update()
    {
	    if (gManager.Enemyflash == false)
	    {
		    if (RunNow == true)
		    {
			    dir = player.position - transform.position; //look towards player +weapon flip
			    angle = Mathf.Atan2(0, dir.x) * Mathf.Rad2Deg;
			    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			    if (angle == 180 && eBullet.activeSelf == false)
			    {
				    transform.localScale = new Vector2(-1, 1);
			    }
			    else if (angle != 180 && eBullet.activeSelf == false)
			    {
				    transform.localScale = new Vector2(1, 1);
			    }

			    //
			    YDistance = Vector2.Distance(gyDistance, pyDistance);
			    gyDistance = new Vector2(0, transform.position.y);
			    pyDistance = new Vector2(0, player.position.y);
			    //
			    XDistance = Vector2.Distance(gxDistance, pxDistance);
			    gxDistance = new Vector2(transform.position.x, 0);
			    pxDistance = new Vector2(player.position.x, 0);
			    //
			    if (XDistance < AllowDistance)
			    {
				    if (XDistance > stoppingDistance)
				    {
					    if (YDistance < stoppingDistance && dead == false) //shoot
					    {
						    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
						    StartCoroutine(Shoot());
					    }
				    }
				    else if (XDistance < stoppingDistance)
				    {
					    if (YDistance < stoppingDistance && dead == false) //shoot
					    {
						    transform.position = this.transform.position;
						    StartCoroutine(Shoot());
					    }
				    }
			    }
		    }

		    if (health <= 0 && angle == 180 && ColorON <= 0)//fall and die
		    {
			    animator.SetBool("dead_left", true);
			    dead = true;
		    }
		    else if (health <= 0 && angle == 180 && ColorON > 0)
		    {
			    animator.SetBool("dead_left_t", true);
			    dead = true;
		    }

		    if (health <= 0 && angle != 180 && ColorON <= 0)
		    {
			    animator.SetBool("dead_right", true);
			    dead = true;
		    }
		    else if (health <= 0 && angle != 180 && ColorON > 0)
		    {
                animator.SetBool("dead_right_t", true);
			    dead = true;
		    }
            if(health < 1)
            {
                StartCoroutine(ColorChanger());
            }
		    timeBtwShots -= Time.deltaTime;
	    }
		else
		{
			return;
		}    
		StartCoroutine(EnemyStop());
    }

	private IEnumerator EnemyStop()
	{
		yield return new WaitForSeconds(0.5f);
		if (player.GetComponent<PlayerHealth>().health <= 0)
		{
			RunNow = false;
		}
		else
		{
			RunNow = true;
		}
	}

    private IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.2f);
        RunNow = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
    }

    IEnumerator Chase()
	{
		AllowDistance = 50;
		yield return new WaitForSeconds(3);
		AllowDistance = 01;
	}


	IEnumerator Shoot()
	{
		if (Player.GetComponent<Renderer>().enabled == true)
		{
			yield return new WaitForSeconds(0.1f);
			if (timeBtwShots <= 0)
			{
				eBullet.SetActive(true);
				eBullet.GetComponent<eBullet>().speed = 5;
				timeBtwShots = startTimeBtwShots;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("pBullet"))
		{
			health -= gManager.EDamage;
			StartCoroutine(Chase());
        }

        if (other.CompareTag("toxBullet") && PlayerPrefs.GetInt("CurrCharacter") == 2)
        {
            health -= gManager.EDamage;
            StartCoroutine(Chase());
            StartCoroutine(ToxHit());
            ColorON++;
            StartCoroutine(ColorChanger());
        }

        if (other.CompareTag("DeathBlock"))
        {
            health = 0;
            dead = true;
        }

		if (other.CompareTag("Range"))
		{
			health = 0;
			dead = true;
		}
	}

    IEnumerator ColorChanger()
    {
        if (ColorON == 1)
        {
            opacity.color = new Color(255, 255, 255, 0.6f);
            yield return new WaitForSeconds(.1f);
            opacity.color = new Color(255, 255, 255, 0.65f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .7f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .75f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .85f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .9f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .95f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, 1);
        }

        if(dead == true && RunNow == true)
        {
            StartCoroutine(Stop());
            opacity.color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .9f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .8f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .7f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .6f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .5f);
            yield return new WaitForSeconds(ColorChangeRate);
            opacity.color = new Color(255, 255, 255, .45f);
            yield return new WaitForSeconds(0.2f);
            RunNow = false;
        }else if(RunNow == false)
        {
            kill++;
            PlayerPrefs.SetInt("KillCount", kill);
            gManager.Kill();
            FindObjectOfType<StatusCurrency>().KillPlus();
            FindObjectOfType<StatusCurrency>().ScorePlus();
            FindObjectOfType<StatusCurrency>().MoneyPlus();
            Destroy(gameObject.gameObject);
        }
    }



    IEnumerator ToxHit()
    {
        animator.SetBool("poisoned", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("poisoned", false);
    }
    #endregion
}
