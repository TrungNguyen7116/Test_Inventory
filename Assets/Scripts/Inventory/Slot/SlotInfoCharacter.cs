using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotInfoCharacter : Slot
{
    public bool isEmpty;
    private void Start()
    {
    }
    override public void OnPointerDown(PointerEventData eventData)
    {
        clicked++;
        if (clicked == 1) clicktime = Time.time;
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            Unequip();
            clicked = 0;
            clicktime = 0;
        }
        else if (clicked > 2 || Time.time - clicktime > clickdelay)
        {
            clicked = 0;
        }
    }
    void Unequip()
    {
        if (isEmpty)
        {
            return;
        }
        else
        {
            GameManager.instance.itemData.Add(this.item);
            InventoryManager.instance.AssignDataFromFileToList();
            checkKindOfItem();
            GameManager.instance.SaveAll();
            this.item = null;
            isEmpty = true;
            LoadImage(); //Change image of slot in character panel
            DisplayCharacter.instance.DisplayItemOnCharacter(); //Change imgae of your character
        }
    }
    void checkKindOfItem()
    {
        switch (this.item.kind)
        {
            case ItemKind.HAIR:
                GameManager.instance.characterData.hair = null;
                break;
            case ItemKind.GLASSES:
                GameManager.instance.characterData.glasses = null;
                break;
            case ItemKind.SKIN:
                GameManager.instance.characterData.skin = null;
                break;
            case ItemKind.ISACCESSORIES:
                UnequipAccessories();
                break;
            case ItemKind.WEAPON:
                GameManager.instance.characterData.weapon = null;
                break;
            case ItemKind.SECOND_WEAPON:
                GameManager.instance.characterData.sed_weapon = null;
                break;
            case ItemKind.ACCELERATOR:
                GameManager.instance.characterData.accelerator = null;
                break;
            default:
                Debug.Log("nothing");
                break;
        }
    }
    void UnequipAccessories()
    {
        if (this.item == GameManager.instance.characterData.accessories[0])
        {
            GameManager.instance.characterData.accessories[0] = null;
        }
        else if (this.item == GameManager.instance.characterData.accessories[1])
        {
            GameManager.instance.characterData.accessories[1] = null;
        }
        else if (this.item == GameManager.instance.characterData.accessories[2])
        {
            GameManager.instance.characterData.accessories[2] = null;
        }
        LoadImage();
    }
}
