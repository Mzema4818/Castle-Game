using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveItems(GetData items)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/items.PleaseGodLetThisWork";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(items);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData loadPlayer()
    {
        string path = Application.persistentDataPath + "/items.PleaseGodLetThisWork";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
