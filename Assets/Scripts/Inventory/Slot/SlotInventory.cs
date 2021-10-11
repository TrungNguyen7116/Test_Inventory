using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInventory : Slot
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void OnPointerDown(PointerEventData eventData)
    {
        clicked++;
        if (clicked == 1) clicktime = Time.time;
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            Debug.Log("Double click");
            Equip();
            clicked = 0;
            clicktime = 0;
        }
        else if (clicked > 2 || Time.time - clicktime > clickdelay)
        {
            clicked = 0;
        }
    }
    void Equip()
    {
        switch (item.kind)
        {
            case ItemKind.HAIR:
                ChangeItem((int)ItemKind.HAIR, ref GameManager.instance.characterData.hair);
                break;
            case ItemKind.GLASSES:
                ChangeItem((int)ItemKind.GLASSES, ref GameManager.instance.characterData.glasses);
                break;
            case ItemKind.SKIN:
                ChangeItem((int)ItemKind.SKIN, ref GameManager.instance.characterData.skin);
                break;
            case ItemKind.ISACCESSORIES:
                ChangeAccesories();
                break;
            case ItemKind.WEAPON:
                ChangeItem((int)ItemKind.WEAPON, ref GameManager.instance.characterData.weapon);
                break;
            case ItemKind.SECOND_WEAPON:
                ChangeItem((int)ItemKind.SECOND_WEAPON, ref GameManager.instance.characterData.sed_weapon);
                break;
            case ItemKind.ACCELERATOR:
                ChangeItem((int)ItemKind.ACCELERATOR, ref GameManager.instance.characterData.accelerator);
                break;
            default:
                Debug.Log("nothing");
                break;
        }
    }
    void ChangeItem(int itemKind, ref ItemInfo itemCharacterInfo)
    {
        if (SlotInfoCharacterManager.instance.slot[itemKind].isEmpty)
        {
            SlotInfoCharacterManager.instance.slot[itemKind].item = this.item;
            SlotInfoCharacterManager.instance.slot[itemKind].isEmpty = false;
            itemCharacterInfo = this.item;
            GameManager.instance.itemData.Remove(this.item);
            //InventoryManager.instance.item.Remove(this.item);
            InventoryManager.instance.AssignDataFromFileToList();
            GameManager.instance.SaveAll();
        }
        else
        {
            ItemInfo temp = itemCharacterInfo;
            int index = GameManager.instance.itemData.FindIndex(obj => obj == this.item);
            SlotInfoCharacterManager.instance.slot[itemKind].item = this.item;
            itemCharacterInfo = this.item;
            GameManager.instance.itemData[index] = temp;
            InventoryManager.instance.item[index] = temp;
            this.item = temp;
            GameManager.instance.SaveAll();
        }
        LoadImage(); //Change image of slot in inventory
        SlotInfoCharacterManager.instance.slot[itemKind].gameObject.GetComponent<Slot>().LoadImage(); //Change image of slot in character panel
        DisplayCharacter.instance.DisplayItemOnCharacter(); //Change image on your character
    }
    void ChangeAccesories()
    {
        if (SlotInfoCharacterManager.instance.slot[(int)ItemKind.ACCESSORIES_1].isEmpty)
        {
            ChangeItem((int)ItemKind.ACCESSORIES_1, ref GameManager.instance.characterData.accessories[0]);
            return;
        }
        if (SlotInfoCharacterManager.instance.slot[(int)ItemKind.ACCESSORIES_2].isEmpty)
        {
            ChangeItem((int)ItemKind.ACCESSORIES_2, ref GameManager.instance.characterData.accessories[1]);
            return;
        }
        if (SlotInfoCharacterManager.instance.slot[(int)ItemKind.ACCESSORIES_3].isEmpty)
        {
            ChangeItem((int)ItemKind.ACCESSORIES_3, ref GameManager.instance.characterData.accessories[2]);
            return;
        }
        if (!SlotInfoCharacterManager.instance.slot[(int)ItemKind.ACCESSORIES_1].isEmpty
            && !SlotInfoCharacterManager.instance.slot[(int)ItemKind.ACCESSORIES_2].isEmpty
            && !SlotInfoCharacterManager.instance.slot[(int)ItemKind.ACCESSORIES_3].isEmpty)
        {
            ChangeItem((int)ItemKind.ACCESSORIES_1, ref GameManager.instance.characterData.accessories[0]);
            return;
        }
    }
}
