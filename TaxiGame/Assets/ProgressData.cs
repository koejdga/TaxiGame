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
        SaveSystem.LastCompleteLevel = lastCompleteLevel;
    }
}
