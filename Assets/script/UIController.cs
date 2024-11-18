using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Image heart1, heart2, heart3;
    public Sprite heartFull, heartEmpty, heartHalf;
    public TextMeshProUGUI gemsCount;

    public Image fadeScreen;
    public float speedFade;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject levelCompleteText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateGemsCount();
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, speedFade * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        if(shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, speedFade * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }
    public void UpdateHealthDisplay()
    {
        switch (PlayerHealth.instance.currentHealth)
        {
            case 6: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;

            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                break;

            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;

            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;

            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;


        }
    }
    public void UpdateGemsCount()
    {
        gemsCount.text = LevelManager.instance.gemsCollected.ToString(); 
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }
    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
}
