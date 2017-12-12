using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public Transform interactionLocation;
    public ConditionCollection[] conditionCollections = new ConditionCollection[0];
    public ReactionCollection defaultReactionCollection;
    public Item[] actionate;
    bool itemToCheck;
    GameObject givenItem;

    public void Interact ()
    {
        for (int i = 0; i < conditionCollections.Length; i++)
        {
            if (conditionCollections[i].CheckAndReact ())
                return;
        }

        defaultReactionCollection.React ();
    }

    public void OnMouseEnter()
    {
        if (DragHandeler.itemBeingDragged != null)
        {
            itemToCheck = true;
            givenItem = DragHandeler.itemBeingDragged;
            DragHandeler.itemBeingDragged.GetComponent<Image>().color = new Color(0, 1, 0);
        }
    }

    public void OnMouseExit()
    {
        if (DragHandeler.itemBeingDragged != null)
        {
            itemToCheck = false;
            givenItem = null;
            DragHandeler.itemBeingDragged.GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }

    public void OnMouseUp()
    {
        if (itemToCheck == true)
        {
            Interact();
        }
    }
        /*foreach (Item i in actionate)
        {
            if (i == DragHandeler.lastDragged)
            {
                
            }
        }*/
        

}
