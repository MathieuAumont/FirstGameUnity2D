using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    private Animator anim;

    public int currentHealth, maxHealth;
    public float InvincibleLength;
    private float InvincibleCounter;

    private SpriteRenderer theSr;

    public GameObject deathEffect;
    

    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        theSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InvincibleCounter > 0)
        {
           
            InvincibleCounter -= Time.deltaTime;
            if(InvincibleCounter <= 0)
            {
                theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, 1f);
            }
            
        }
    }

    public void DealDamage()
    {
        if (InvincibleCounter <= 0)
        {
            currentHealth--;
            


            if (currentHealth <= 0)
            {
                currentHealth = 0;

                //gameObject.SetActive(false);
                LevelManager.instance.RespawnPlayer();
                Instantiate(deathEffect, transform.position, transform.rotation);
                //gameObject.SetActive(true);
                
            }
            else 
            {
                InvincibleCounter = InvincibleLength;
                theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, 0.5f);
                
                PlayerController.instance.KnockBack();
                AudioManager.instance.PlaySFX(9);
               
             
            }
            UIController.instance.UpdateHealthDisplay();
        }
        
    }
    public void HealPlayer()
    {
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }

   




}
