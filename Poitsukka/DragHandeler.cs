using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject itemBeingDragged;
    public static Item lastDragged;
    public static Vector2 startPosition;
    public static int activeSlot, destSlot;
    public static Vector2 scale;
    Inventory inv;
    //Interactable[] interactables;

    /*private void Awake()
    {
        interactables = GameObject.FindObjectsOfType<Interactable>();
    }*/


    #region IBeginDragHandler implementation
    public void OnBeginDrag(PointerEventData eventData)
    {
        scale = new Vector2(transform.localScale.x, transform.localScale.y);
        activeSlot = transform.parent.GetComponent<Slot>().id;
        itemBeingDragged = gameObject;
        lastDragged = inv.items[activeSlot];
        startPosition = transform.position;
        TouchInput.dragging = true;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        
    }
    #endregion
    #region IDragHandler implementation
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        if (Input.touchCount == 1)
        {
            pos = Input.GetTouch(0).position;
        }
        else
        {
            pos = new Vector2(Input.mousePosition.x + 20, Input.mousePosition.y - 20);
        }
        transform.position = new Vector3(pos.x - 20, pos.y + 20, -1);
        /*foreach(Interactable i in interactables)
        {
            if (i.GetComponent<SpriteRenderer>().sprite.rect.Overlaps(GetComponent<Image>().sprite.rect))
            {
                GetComponent<Image>().color = new Color(0, 1, 0);
            }
            else
            {
                GetComponent<Image>().color = new Color(1, 1, 1);
            }
        }*/

    }
    #endregion
    #region IEndDragHandler implementation
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localScale = new Vector2(scale.x, scale.y);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = startPosition;
        TouchInput.dragging = false;
        GetComponent<Image>().color = new Color(1, 1, 1);
        DragHandeler.itemBeingDragged = null;
    }
    #endregion

}
