using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed=3;
	private float JForce=5;
    private float moveInput;
	private float VerticalInput;
    private Rigidbody2D rb;
	public bool facingRight = true;
	public bool isGrounded;
    public Transform groundCheck;
	private float checkRadius=0.1f;
	public LayerMask whatIsGround;

	private int xJump;
	private int xJumpValue=2;
	//ladder
	private float inputHorizontal;
	private float inputVertical;

	private float checkLRadius=0.3f;
	public bool isLadder;
	public Transform LadderCheck;
	public LayerMask whatIsLadder;

	public GManager gManager;
	public GameObject go;

    public Joystick joystick;



	void Start(){
        joystick = FindObjectOfType<FixedJoystick>();
		//
		rb = GetComponent<Rigidbody2D>();
		go = GameObject.Find("GameManager");
		gManager = go.GetComponent<GManager>();
		///
		rb.gravityScale = 1;
	}


	void FixedUpdate()
    {
		isLadder = Physics2D.OverlapCircle(LadderCheck.position, checkLRadius, whatIsLadder);
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = joystick.Horizontal;//move a and d
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0){
            Flip();
        }else if(facingRight == true && moveInput < 0){
            Flip();
        }

	}
	void Update()
	{	
		if (isGrounded == true)
		{
			xJump = xJumpValue;
		}
		
		if (isGrounded == true && isLadder == false)
		{
			xJump = xJumpValue;
		}

        if(isLadder==true && FindObjectOfType<GameInputFunction>().jump == false)
        {
            rb.velocity = new Vector2(0, -3f);
        }
	}



	void Flip()
	{
      facingRight = !facingRight;
      Vector2 Scaler = transform.localScale;
      Scaler.x *= -1;
      transform.localScale = Scaler;
	}

    public void Jump()
	{
        if (gManager.Char == 1 && isGrounded == true || gManager.Char == 2 && isGrounded == true)
		{
			rb.velocity = Vector2.up * JForce;
        }
        else if (xJump > 1 && PlayerPrefs.GetInt("CurrCharacter") == 3)
        {
            rb.velocity = Vector2.up * JForce;
            xJump--;
        }
		if (isLadder == true)
        {
            rb.velocity = new Vector2(0, 4f);
        }
	}
}

