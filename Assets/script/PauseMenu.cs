using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string levelSelect, mainMenu;
    public GameObject pauseMenu;
    public bool isPaused;

    private void Awake()
    {
        instance = this;    
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            PauseUnPause();
        }
    }

    public void PauseUnPause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void LevelSelected()
    {
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
