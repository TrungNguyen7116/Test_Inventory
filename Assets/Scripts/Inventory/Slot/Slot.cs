using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    public ItemInfo item = null;
    public Image image;
    protected float clicked = 0f;
    protected float clicktime = 0f;
    protected float clickdelay = 0.5f;
    virtual public void OnPointerDown(PointerEventData eventData)
    {
        //Nothing
    }
    public void LoadImage()
    {
        if (item == null)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
            image.sprite = Resources.Load<Sprite>("Items/" + item.image);
        }
    }
}
