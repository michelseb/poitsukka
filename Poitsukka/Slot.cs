using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler {

    public int id;
    private Inventory inventory;

    void Start ()

    {
        inventory = FindObjectOfType<Inventory>();
    }

    public GameObject item
    {
        get
        {
            if (transform.GetChild(1).GetComponent<Image>().IsActive()) {
                return transform.GetChild(1).gameObject;
            }
            return null;
        }
    }

    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            transform.GetChild(1).GetComponent<Image>().enabled = true;
            transform.GetChild(1).GetComponent<Image>().sprite = DragHandeler.itemBeingDragged.transform.GetComponent<Image>().sprite;
            DragHandeler.itemBeingDragged.transform.GetComponent<Image>().sprite = null;
            DragHandeler.itemBeingDragged.transform.GetComponent<Image>().enabled = false;
        }
        else {
            /*Sprite swap = new Sprite();
            swap = transform.GetChild(1).GetComponent<Image>().sprite;
            transform.GetChild(1).GetComponent<Image>().sprite = DragHandeler.itemBeingDragged.transform.GetComponent<Image>().sprite;
            DragHandeler.itemBeingDragged.transform.GetComponent<Image>().sprite = swap;
            Debug.Log(id);*/
            inventory.FusionItem(DragHandeler.activeSlot, id);

        }
    }
    #endregion
}
