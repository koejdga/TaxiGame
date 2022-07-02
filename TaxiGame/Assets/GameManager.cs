using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject YouHaveAnOrder;
    public GameObject Map;
    public GameObject Background;

    void Start()
    {
        YouHaveAnOrder.SetActive(true);
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (YouHaveAnOrder.activeSelf)
            { 
                YouHaveAnOrder.SetActive(false);
                Map.SetActive(true);
            } 
            else if (Map.activeSelf)
            {
                Map.SetActive(false);
                Background.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
