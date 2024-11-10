using UnityEngine;

public class FallingSpikesController : MonoBehaviour
{
    public static FallingSpikesController Instance;
    public Rigidbody2D FallingSpike;
    public Vector3 originPoint;
    //public Vector3 groundPointPosition;
    public LayerMask isTheGround;
    public bool touchGround;
    public Transform groundPoint;
    public bool isActivated = false;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originPoint = transform.position;
        //groundPointPosition = groundPoint.position;
        touchGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        touchGround = Physics2D.OverlapCircle(groundPoint.position, 0.2f, isTheGround);
        TouchingTheGround();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" )
        {
            PlayerHealth.instance.DealDamage();
        }

        if(other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
        }
        
        
        
    }
    public void TouchingTheGround()
    {
        if(touchGround)
        {
            if (isActivated)
            {   
                
                FallingSpike.gravityScale = 0;
                FallingSpike.position = originPoint;
                FallingSpike.linearVelocity = Vector2.zero;
               // groundPoint.position = groundPointPosition;
                FallingSpike.gravityScale = 0;
                touchGround = false;
                isActivated = false;
                

            }
        }
       
    }
}
