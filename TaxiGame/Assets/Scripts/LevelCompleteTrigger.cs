using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    public GameManager GameManager;

    void OnTriggerEnter()
    {
        if (LevelMenu.Level > SaveSystem.LastCompleteLevel)
        {
            SaveSystem.LastCompleteLevel++;
        }
        GameManager.CompleteLevel();
    }
}