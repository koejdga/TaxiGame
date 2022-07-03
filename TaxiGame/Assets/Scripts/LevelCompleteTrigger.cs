using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{

    public GameManager GameManager;

    void OnTriggerEnter()
    {
        GameManager.CompleteLevel();
    }
}
