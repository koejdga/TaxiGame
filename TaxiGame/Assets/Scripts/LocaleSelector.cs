using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private bool active = false;
    public void ChangeLocale(int LocaleID)
    {
        if (active)
        {
            return;
        }
        StartCoroutine(SetLocale(LocaleID));
    }

    IEnumerator SetLocale(int localeID)
    {
        active = true;
        yield return LocalizationSettings.AvailableLocales.Locales[localeID];
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        active = false;
    }

}
