using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static void SaveDataCharacter(ref Character character)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/character.save");
        bf.Serialize(file, character);
        file.Close();
        Debug.Log("Saved");
    }

    public static void SaveDataItem(ref List<ItemInfo> item)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/item.save");
        bf.Serialize(file, item);
        file.Close();
        Debug.Log("Saved");
    }

    public static void LoadDataCharacter(ref Character character)
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/character.save"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/character.save", FileMode.Open);
            character = (Character)bf.Deserialize(file);
            file.Close();
            Debug.Log("Load");
        }
        else
        {
            character = null;
            Debug.Log("null");
        }
    }

    public static void LoadDataItem(ref List<ItemInfo> item)
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/item.save"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/item.save", FileMode.Open);
            item = (List<ItemInfo>)bf.Deserialize(file);
            file.Close();
            Debug.Log("Load");
        }
        else
        {
            Debug.Log("null");
        }
    }
}
