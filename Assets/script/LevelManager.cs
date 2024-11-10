using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
    private Vector3 OriginePoint;
    public int gemsCollected;
    


    private void Awake()
    {
        instance = this;
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gemsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX(8);

        yield return new WaitForSeconds(waitToRespawn);
       
        PlayerController.instance.gameObject.SetActive(true);
        if(PlayerHealth.instance.currentHealth <= 0)
        {
            CheckpointController.instance.SetSpawnPoint(OriginePoint);
            CheckpointController.instance.DeactivateCheckpoints();
        }
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
    }
}