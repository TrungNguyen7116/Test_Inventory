using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Character characterData;
    public List<ItemInfo> itemData = new List<ItemInfo>();
    public Image avatar;

    //public Character CharacterData 
    //{ 
    //    get => characterData; 
    //    set
    //    {
    //        characterData = value;
    //        SaveManager.SaveDataCharacter(ref characterData);
    //    }
    //}

    //public List<ItemInfo> ItemData { get => itemData; set => itemData = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadData()
    {
        SaveManager.LoadDataCharacter(ref characterData);
        SaveManager.LoadDataItem(ref itemData);
    }
    public void SaveDataCharacter()
    {
        SaveManager.SaveDataCharacter(ref characterData);
    }
    public void SaveDataItem()
    {
        SaveManager.SaveDataItem(ref itemData);
    }
    public void SaveAll()
    {
        SaveManager.SaveDataCharacter(ref characterData);
        SaveManager.SaveDataItem(ref itemData);
    }
}
