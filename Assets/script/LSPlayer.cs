using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public static LSPlayer instance;
    public LevelSelect currentPoint;

    public float moveSpeed = 15f;

    private bool levelLoading;

    public LSManager manager;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading)
        {
            if (currentPoint.isLevel)
            {
                LSUIController.instance.ShowInfo(currentPoint);
            }
           
            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);
                }
            }
            if (Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                }
            }
            if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);
                }
            }
            if (Input.GetAxisRaw("Vertical") < -.5f)
            {
                if (currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);
                }
            }
            if ( currentPoint.levelToLoad != "" && currentPoint.isLevel && !currentPoint.isLocked)
            {
               // LSUIController.instance.ShowInfo(currentPoint);
                if(Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;
                    manager.LoadLevel();
                }
            }
        }
    }
    public void SetNextPoint(LevelSelect nextPoint)
    {

        currentPoint = nextPoint;
        LSUIController.instance.HideInfo();
    }
}
