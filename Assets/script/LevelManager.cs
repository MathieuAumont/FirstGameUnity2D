using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
    public Vector3 OriginePoint;
    public int gemsCollected;

    public string levelToLoad;
    
    


    private void Awake()
    {
        instance = this;
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gemsCollected = 0;
        OriginePoint = PlayerController.instance.transform.position;
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

        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.speedFade));

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.speedFade) + 0.2f);

        UIController.instance.FadeFromBlack();


        PlayerController.instance.gameObject.SetActive(true);
        if(PlayerHealth.instance.currentHealth <= 0)
        {
            CheckpointController.instance.SetSpawnPoint(OriginePoint);
            CheckpointController.instance.DeactivateCheckpoints();
        }
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
    }
    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }
    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;

        CameraController.instance.stropFollow = true;

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1f);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.speedFade) + .25f);

        SceneManager.LoadScene(levelToLoad);



        
    }
}
