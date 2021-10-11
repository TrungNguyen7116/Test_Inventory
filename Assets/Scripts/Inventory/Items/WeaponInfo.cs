using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponInfo : ItemInfo
{
    public int level;

    public WeaponInfo()
    {
        this.name = null;
        this.kind = ItemKind.WEAPON;
        this.price = 0;
        this.quantity = 0;
        this.property = null;
        this.level = 0;
    }

}
