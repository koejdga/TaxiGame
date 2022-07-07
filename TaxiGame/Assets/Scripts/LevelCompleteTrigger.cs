using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    public GameManager GameManager;

    void OnTriggerEnter()
    {
        Debug.Log("����� �� ���� " + SaveSystem.LastCompleteLevel);
        if (LevelMenu.Level > SaveSystem.LastCompleteLevel)
        {
            SaveSystem.LastCompleteLevel++;
        }
        Debug.Log("����� ���� ���� " + SaveSystem.LastCompleteLevel);
        GameManager.CompleteLevel();
    }
}