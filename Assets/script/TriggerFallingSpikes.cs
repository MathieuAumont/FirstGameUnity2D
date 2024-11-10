using System.Collections;
using UnityEngine;

public class TriggerFallingSpikes : MonoBehaviour
{
    
    private FallingSpikesController[] fallingSpikes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //fallingSpikes = FindObjectsOfType<FallingSpikesController>();
        // fallingSpikes = FindObjectsByType <FallingSpikesController>(FindObjectsSortMode.InstanceID);
       
            // Recherche automatique des piques associés à ce trigger (si non assignés)
            fallingSpikes = GetComponentsInChildren<FallingSpikesController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && PlayerController.instance.theSR.flipX == false)
        {
            StartCoroutine(ActiveSequenceSpike());
        }
    }
    private IEnumerator ActiveSequenceSpike()
    {
        for (int i = 0; i < fallingSpikes.Length; i++)
        {

            fallingSpikes[i].isActivated = true;
            //fallingSpikes[i].touchGround = Physics2D.OverlapCircle(fallingSpikes[i].groundPoint.position, 1f, fallingSpikes[i].isTheGround);
            fallingSpikes[i].FallingSpike.gravityScale = 2f;
            yield return new WaitForSeconds(0.25f);


        }
    }
}
    
