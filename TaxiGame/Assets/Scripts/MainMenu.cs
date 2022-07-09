using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void ResetProgress()
    {
        SaveSystem.ResetProgress();
        
    }

    public void quitGame()
    {
        Application.Quit();
        
    }
}
