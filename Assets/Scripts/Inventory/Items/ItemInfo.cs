using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfo
{
    public string name;
    public ItemKind kind;
    public string image;
    public int price;
    public int quantity;
    public string property;

    public ItemInfo()
    {
        this.name = null;
        this.kind = ItemKind.NOTHING;
        this.image = null;
        this.price = 0;
        this.quantity = 0;
        this.property = null;
    }

    public ItemInfo(string name, ItemKind kind)
    {
        this.name = name;
        this.kind = kind;
    }
    public ItemInfo(string name, ItemKind kind, string image)
    {
        this.name = name;
        this.kind = kind;
        this.image = image;
    }
}
