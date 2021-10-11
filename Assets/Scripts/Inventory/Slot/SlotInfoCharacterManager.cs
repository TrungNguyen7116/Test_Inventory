using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInfoCharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SlotInfoCharacter[] slot = new SlotInfoCharacter[9];
    public static SlotInfoCharacterManager instance;
    void Start()
    {
        if (instance == null) instance = this;
        for (int i = 0; i < 9; i++)
        {
            slot[i].item = null;
        }
        DisplayInfo();
    }
    void DisplayInfo()
    {
        if (GameManager.instance.characterData != null)
        {
            slot[(int)ItemKind.HAIR].item = GameManager.instance.characterData.hair;
            slot[(int)ItemKind.GLASSES].item = GameManager.instance.characterData.glasses;
            slot[(int)ItemKind.SKIN].item = GameManager.instance.characterData.skin;
            slot[(int)ItemKind.ACCESSORIES_1].item = GameManager.instance.characterData.accessories[0];
            slot[(int)ItemKind.ACCESSORIES_2].item = GameManager.instance.characterData.accessories[1];
            slot[(int)ItemKind.ACCESSORIES_3].item = GameManager.instance.characterData.accessories[2];
            slot[(int)ItemKind.WEAPON].item = GameManager.instance.characterData.weapon;
            slot[(int)ItemKind.SECOND_WEAPON].item = GameManager.instance.characterData.sed_weapon;
            slot[(int)ItemKind.ACCELERATOR].item = GameManager.instance.characterData.accelerator;
        }
        for (int i = 0; i < 9; i++)
        {
            if (slot[i].item == null)
            {
                slot[i].isEmpty = true;
            }
            else
            {
                slot[i].isEmpty = false;
            }
            slot[i].LoadImage();
        }
    }
}
