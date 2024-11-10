using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject deathEffect;

    public GameObject collectible;

    [Range(0,100)]public float chanceToDrop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" )
        {
            //Debug.Log("Hit Enemy");
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);

            PlayerController.instance.Bounce();
            float dropSelect;

            if(PlayerHealth.instance.currentHealth <= PlayerHealth.instance.maxHealth * .5f)
            {
                dropSelect = chanceToDrop;
            }else
            {
                dropSelect = Random.Range(0, 100f);
            }
            
            if (dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
            AudioManager.instance.PlaySFX(3);
        }
    }
}
