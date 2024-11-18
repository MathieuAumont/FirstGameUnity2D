using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform target;

    public Transform farBg, middleBg, frontBg;

    public float minHeight, maxHeight, middleHeight;
   
    private Vector2 lastPos;

    public bool stropFollow;

    public float midSpeed;
    public float frontSpeed;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stropFollow)
        {


            if (target.position.x < 40f)
            {
                transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, middleHeight, maxHeight), transform.position.z);
            }
            else
            {
                transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
            }



            Vector2 amountLastPos = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

            farBg.position += new Vector3(amountLastPos.x, amountLastPos.y, 0f);
            middleBg.position += new Vector3(amountLastPos.x, amountLastPos.y, 0f) * midSpeed;
            frontBg.position += new Vector3(amountLastPos.x, amountLastPos.y, 0f) * frontSpeed;



            lastPos = transform.position;
        }
    }
}
