using UnityEngine;
using UnityEngine.Rendering;

public class KillPlayer : MonoBehaviour
{
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
        if(other.tag == "Player")
        {
           
            LevelManager.instance.RespawnPlayer();
            PlayerHealth.instance.currentHealth--;
            UIController.instance.UpdateHealthDisplay();

        }
    }
}