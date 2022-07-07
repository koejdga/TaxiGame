using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void quitGame()
    {
        // SaveProgress();
        Application.Quit();
        
    }

    public void SaveProgress()
    {
        SaveSystem.SaveProgress();
    }

    private void Start()
    {
        // LoadProgress();
    }

    public void LoadProgress()
    {
        ProgressData data = SaveSystem.LoadProgress() as ProgressData;
        if (data != null)
        {
            LocaleSelector.localeID = data.LocaleID;
            SaveSystem.LastCompleteLevel = data.lastCompleteLevel;
        }
    }
}
