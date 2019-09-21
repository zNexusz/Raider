using UnityEngine;


public class Shootbullet : MonoBehaviour
{
	public PlayerShootTrigger PlayerShootTrigger;
	public Animator Anim;
	public Transform player;
	private Rigidbody2D rb;
	private float wait;
	public float StartSec;
	private bool shoot;
	public float Ypos;

	//
	ObjectPooler objectPooler;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		objectPooler = ObjectPooler.Instance;
	}


	// Update is called once per frame
	void Update()
	{
		rb.freezeRotation = true;

		wait -= Time.deltaTime;
		if (wait <= 0)
		{
			shoot = true;
			wait = 0;
		}
	}

    public void ShootNOW()
    {
        if (PlayerPrefs.GetInt("CurrCharacter") == 2)
        {
            if (shoot == true)
            {
                objectPooler.SpawnFromPool("ToxBullet", new Vector3(transform.position.x, transform.position.y + Ypos, 0), Quaternion.identity);
                wait = StartSec;
                shoot = false;
                //shoot animation
                StartCoroutine(PlayerShootTrigger.ShootAnim());
            }
        }
        else if (shoot == true)
        {
            objectPooler.SpawnFromPool("Bullets", new Vector3(transform.position.x, transform.position.y + Ypos, 0), Quaternion.identity);
            wait = StartSec;
            shoot = false;
            StartCoroutine(PlayerShootTrigger.ShootAnim());
        }
    }
}
