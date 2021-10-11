using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<ItemInfo> item;
    private SlotInventory[] slot;
    public static InventoryManager instance;
    void Start()
    {
        if (instance == null) instance = this;
        slot = GetComponent<SlotInventoryManager>().listSlot;
        AssignDataFromFileToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AssignDataFromFileToList()
    {
        if (GameManager.instance == null) return;
        item = GameManager.instance.itemData;
        for (int i = 0; i < item.Count; i++)
        {
            slot[i].item = item[i];
            slot[i].LoadImage();
        }
        for (int i = item.Count; i < slot.Length; i++)
        {
            slot[i].item = null;
            slot[i].LoadImage();
        }
    }
}
