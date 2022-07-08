using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static int LastCompleteLevel = 0;

    public static void SaveProgress()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/progress.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        ProgressData data = new ProgressData();

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static ProgressData LoadProgress()
    {
        string path = Application.persistentDataPath + "/progress.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);
            ProgressData data = formatter.Deserialize(stream) as ProgressData;

            stream.Close();
            return data;

        }
        else
        {
            Debug.Log("нічого не завантажилося, немає файлу");
            return null;
        }

    }
}
