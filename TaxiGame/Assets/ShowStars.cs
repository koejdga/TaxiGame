using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStars : MonoBehaviour
{
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    public void CloseStars()
    {
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
    }

    public void DisplayStars(int num)
    {
        Star1.SetActive(true);
        if (num > 1)
        {
            Star2.SetActive(true);
        }
        if (num == 3)
        {
            Star3.SetActive(true);
        }
    }
}
