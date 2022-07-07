using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    public RectTransform Star1;
    public Transform Star2;
    public Transform Star3;

    public void ShowStars()
    {
        Star1.LeanScale(Vector2.zero, 0.7f).setEaseInBack();
    }
}
