using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LSUIController : MonoBehaviour
{
    public static LSUIController instance;


    public Image fadeScreen;
    public float speedFade;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, speedFade * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, speedFade * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
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
