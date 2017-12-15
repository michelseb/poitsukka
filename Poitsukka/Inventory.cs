using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];


    public const int numItemSlots = 4;


    public void AddItem(Item itemToAdd)
    {

        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }


    public void RemoveItem (Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public void FusionItem(int slotA, int slotB)
    {
        Debug.Log(slotA + " " + slotB);
        if (items[slotA].fusion == items[slotB].nom || items[slotA].fusion2 == items[slotB].nom)
        {
            Item it = items[slotA];
            RemoveItem(items[slotA]);
            RemoveItem(items[slotB]);
            AddItem(it.fusionItem);
            
            /*if (slotA < slotB)
            {
                items[slotB] = null;
                itemImages[slotA].sprite = itemImages[slotB].sprite;
                itemImages[slotB].sprite = null;
                itemImages[slotB].enabled = false;
            }
            else
            {
                items[slotA] = null;
                itemImages[slotB].sprite = itemImages[slotA].sprite;
                itemImages[slotA].sprite = null;
                itemImages[slotA].enabled = false;
            }*/
        }
    }
}
