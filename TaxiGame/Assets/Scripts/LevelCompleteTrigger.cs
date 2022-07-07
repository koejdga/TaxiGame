using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    public GameManager GameManager;

    void OnTriggerEnter()
    {
        Debug.Log("π³βενό δξ ημ³νθ " + SaveSystem.LastCompleteLevel);
        if (LevelMenu.Level > SaveSystem.LastCompleteLevel)
        {
            SaveSystem.LastCompleteLevel++;
        }
        Debug.Log("π³βενό ο³ρλÿ ημ³νθ " + SaveSystem.LastCompleteLevel);
        GameManager.CompleteLevel();
    }
}