using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform farBg, middleBg;

    public float minHeight, maxHeight, middleHeight;
   
    private Vector2 lastPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x < 40f)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, middleHeight, maxHeight), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
        }
    
        

        Vector2 amountLastPos = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBg.position += new Vector3(amountLastPos.x, amountLastPos.y, 0f);
        middleBg.position += new Vector3(amountLastPos.x, amountLastPos.y, 0f) * .5f;
        

        lastPos = transform.position;   
    }
}
