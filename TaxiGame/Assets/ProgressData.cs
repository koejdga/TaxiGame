using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData
{
    public int LocaleID;
    public int lastCompleteLevel;

    public ProgressData()
    {
        LocaleID = LocaleSelector.localeID;
        Debug.Log("збережено локаль id " + LocaleID);
        SaveSystem.LastCompleteLevel = lastCompleteLevel;
        Debug.Log("збережено останній рівень " + lastCompleteLevel);
    }
}
