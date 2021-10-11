using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCharacter : MonoBehaviour
{
    public static DisplayCharacter instance;
    public Image bangs;
    public Image hair;
    public Image skin;
    public Image accelerator;
    public Image glasses;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        DisplayItemOnCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayItemOnCharacter()
    {
        AssignComponet(ref hair, GameManager.instance.characterData.hair);
        AssignComponet(ref skin, GameManager.instance.characterData.skin);
        AssignComponet(ref accelerator, GameManager.instance.characterData.accelerator);
        AssignComponet(ref glasses, GameManager.instance.characterData.glasses);
        if (hair.enabled == true)
        {
            bangs.enabled = true;
            bangs.sprite = Resources.Load<Sprite>("Character/" + GameManager.instance.characterData.hair.image + "_Bangs");
        }
        else
        {
            bangs.enabled = false;
        }
    }
    void AssignComponet(ref Image image, ItemInfo resource)
    {
        if (resource == null)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
            image.sprite = Resources.Load<Sprite>("Character/" + resource.image);
        }
    }
}
