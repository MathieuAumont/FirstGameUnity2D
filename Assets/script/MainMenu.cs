using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelSelect;
      //public GameObject startButton, quitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
