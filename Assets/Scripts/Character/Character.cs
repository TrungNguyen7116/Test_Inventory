using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string name;
    public int level;
    public int money;
    public int HP;
    public int attack;
    public int defense;
    public int speed;
    public ItemInfo hair;
    public ItemInfo glasses;
    public ItemInfo skin;
    public ItemInfo weapon;
    public ItemInfo sed_weapon;
    public ItemInfo accelerator;
    public ItemInfo[] accessories = new ItemInfo[3];
}
