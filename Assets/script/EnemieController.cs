using UnityEngine;

public class EnemieController : MonoBehaviour
{
    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D theRb;

    public SpriteRenderer theSR;

    public float moveTime, waitTime;

    private float moveCount, waitCount;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theRb= GetComponent<Rigidbody2D>();
        leftPoint.parent = null;
        rightPoint.parent = null;
        movingRight = true;
        moveCount = moveTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {   
            
            moveCount-= Time.deltaTime;
            if (movingRight)
            {
                theRb.linearVelocity = new Vector2(moveSpeed, theRb.linearVelocity.y);
                theSR.flipX = true;
                
                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRb.linearVelocity = new Vector2(-moveSpeed, theRb.linearVelocity.y);
                theSR.flipX = false;
                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            anim.SetBool("isMoving", true);

            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime *.5f, waitTime * 1.25f);
            }
        }
        else if(waitCount > 0)
        {
            
            waitCount -= Time.deltaTime;
            theRb.linearVelocity = new Vector2(0f, theRb.linearVelocity.y);

            anim.SetBool("isMoving", false);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .5f, moveTime * 1.25f);
            }
        }
    }
}
