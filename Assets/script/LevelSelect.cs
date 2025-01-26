using Unity.VisualScripting;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public LevelSelect up, right, down, left;

    public bool isLevel, isLocked;

    public string levelToLoad, levelToCheck, levelName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if(isLevel && levelToLoad != null)
        {
            isLocked = true;

            if(levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }   
            }
        }
        if(levelToLoad == levelToCheck)
        {
            isLocked = false;
            if(levelToCheck == "")
            {
                isLocked = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
