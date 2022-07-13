using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    static bool LevelMenuIsLoaded;
    public GameObject LevelMenu;
    public GameObject MenuMenu;
    public GameObject ColorMenu;

    private void Start()
    {
        if (LevelMenuIsLoaded)
        {
            MenuMenu.SetActive(false);
            ColorMenu.SetActive(false);
            LevelMenu.SetActive(true);
        }
        LevelMenuIsLoaded = false;
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Menu");
        LevelMenuIsLoaded = true;
    }


    public void ResetProgress()
    {
        SaveSystem.ResetProgress();
        
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
}
