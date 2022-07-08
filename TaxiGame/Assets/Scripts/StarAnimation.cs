using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    public RectTransform Star1;
    public RectTransform Star2;
    public RectTransform Star3;

    public void ShowStars()
    {
        Star1.LeanScale(Vector2.zero, 0.7f).setEaseInBack();
    }

}
