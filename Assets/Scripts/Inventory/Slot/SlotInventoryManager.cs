using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInventoryManager : MonoBehaviour
{
    public SlotInventory slotObject;
    public SlotInventory[] listSlot;
    public int numOfSlot;
    public static SlotInventoryManager instance;
    void Start()
    {
        if (instance == null) instance = this;
        listSlot = new SlotInventory[numOfSlot];
        DrawSlotInPanel();
        gameObject.GetComponent<InventoryManager>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DrawSlotInPanel()
    {
        int x = -300;
        int y = 300;
        for (int i = 0; i < numOfSlot; i++)
        {
            if (i % 5 == 0 && i > 0)
            {
                x = -300;
                y -= 150;
            }
            listSlot[i] = Instantiate(slotObject, new Vector2(transform.position.x + x,transform.position.y + y), Quaternion.identity, transform);
            x += 150;
        }
    }
}
