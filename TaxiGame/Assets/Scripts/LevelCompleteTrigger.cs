using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    public GameManager GameManager;

    void OnTriggerEnter()
    {
        GameManager.CompleteLevel();
        if (LevelMenu.Level > SaveSystem.LastCompleteLevel)
        {
            SaveSystem.LastCompleteLevel++;
            Debug.Log(SaveSystem.LastCompleteLevel);
        }
    }
}