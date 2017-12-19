using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public Transform interactionLocation;
    public ConditionCollection[] conditionCollections = new ConditionCollection[0];
    public ReactionCollection defaultReactionCollection;
    public Item[] actionate = new Item[0];
    
    bool itemToCheck;
    GameObject givenItem;
    PlayerMovement p;

    void Start()
    {
        p = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {

        if (itemToCheck == true && DragHandeler.itemBeingDragged == null)
        {
            foreach (Item i in actionate)
{
                if (i == DragHandeler.lastDragged)
                {
                    p.OnInteractableClick(this);
                }

            }
            
        }

        itemToCheck = false;

    }


    public void Interact ()
    {
        for (int i = 0; i < conditionCollections.Length; i++)
        {
            if (conditionCollections[i].CheckAndReact ())
                return;
        }

        defaultReactionCollection.React ();
    }

    public void OnMouseOver()
    {
        if (DragHandeler.itemBeingDragged != null)
        {
            itemToCheck = true;
            givenItem = DragHandeler.itemBeingDragged;
            DragHandeler.itemBeingDragged.transform.localScale = new Vector2(DragHandeler.scale.x + 1, DragHandeler.scale.y + 1);//GetComponent<Image>().color = new Color(0, 1, 0);
        }
    }

    public void OnMouseExit()
    {
        if (DragHandeler.itemBeingDragged != null)
        {
            itemToCheck = false;
            givenItem = null;
            DragHandeler.itemBeingDragged.transform.localScale = new Vector2(DragHandeler.scale.x, DragHandeler.scale.y);
            //DragHandeler.itemBeingDragged.GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }



        

}
