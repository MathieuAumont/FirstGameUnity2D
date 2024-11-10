using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float Speed;
    public Rigidbody2D TheRb;
    public float Jumpforce;
    private bool isGrounded;

    public Transform groundCheck;
    public LayerMask whatIsGround;

    private bool canDoubleJump;
    public Animator anim;
    public SpriteRenderer theSR;

    private bool isClimbing;
    private bool isJumping;
    public float gravity;

    public float knockBackLength;
    public float knockBackForce;
    private float knockBackCounter;

    public float bounceForce;
    

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        isClimbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            
            TheRb.linearVelocity = new Vector2(Speed * Input.GetAxis("Horizontal"), TheRb.linearVelocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);
            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    TheRb.gravityScale = gravity;
                    TheRb.linearVelocity = new Vector2(TheRb.linearVelocity.x, Jumpforce);
                    isClimbing = false;
                    anim.SetBool("isClimbing", false);
                    AudioManager.instance.PlaySFX(10);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        TheRb.linearVelocity = new Vector2(TheRb.linearVelocity.x, Jumpforce);
                        canDoubleJump = false;
                        isJumping = false;
                        AudioManager.instance.PlaySFX(10);
                    }
                }
            }
       
        

            if (TheRb.linearVelocity.x  < 0)
            {
                theSR.flipX = true;
            }
            else if(TheRb.linearVelocity.x > 0)
            {
                theSR.flipX = false;
            }
        } else
        {
            knockBackCounter -= Time.deltaTime;
            if(theSR.flipX)
            {
                TheRb.linearVelocity = new Vector2(knockBackForce, TheRb.linearVelocity.y);
            }
            else
            {
                TheRb.linearVelocity = new Vector2(-knockBackForce, TheRb.linearVelocity.y);
            }
        }
           
        if(isClimbing)
        {
            TheRb.linearVelocity = new Vector2(TheRb.linearVelocity.x, Speed * Input.GetAxis("Vertical"));
           
        }
        anim.SetFloat("Speed", Mathf.Abs(TheRb.linearVelocity.x));
        anim.SetBool("isGrounded", isGrounded);
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "ladder")
            {

                //Debug.Log("Climb");
                isClimbing = true;
                anim.SetBool("isClimbing", true);
                //TheRb.linearVelocity = new Vector2(TheRb.linearVelocity.x, Speed * Input.GetAxis("Vertical"));
                
                TheRb.gravityScale = 0;
            }
        
        

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ladder" )
        {
            //Debug.Log("Climb");
            anim.SetBool("isClimbing", false);
            isClimbing=false;
            TheRb.gravityScale = gravity;
        }
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        TheRb.linearVelocity = new Vector2(0f, knockBackForce);
        anim.SetTrigger("isHurt2");
    }

    public void Bounce()
    {
        TheRb.linearVelocity = new Vector2(TheRb.linearVelocity.x, bounceForce);
        AudioManager.instance.PlaySFX(10);
    }

}
