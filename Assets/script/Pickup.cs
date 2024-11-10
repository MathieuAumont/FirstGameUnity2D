using System.Data;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem;
    public bool isHealth;
    public bool isCollected;
    public GameObject pickupEffect;
   // public AudioSource pickupSoundEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isCollected = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isCollected)
        {
            if(isGem)
            {
                LevelManager.instance.gemsCollected++;
                UIController.instance.UpdateGemsCount();
                isCollected = true;
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                
                AudioManager.instance.PlaySFX(6);
            }
            if(isHealth)
            {
                if(PlayerHealth.instance.currentHealth != PlayerHealth.instance.maxHealth)
                {

                    PlayerHealth.instance.HealPlayer();
                    isCollected=true;
                    Destroy(gameObject);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    
                    AudioManager.instance.PlaySFX(7);

                }

            }
        }
    }
}
