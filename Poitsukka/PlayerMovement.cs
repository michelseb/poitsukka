using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Transform poitsukka;
    public SaveData playerSaveData;
    public float inputHoldDelay = 0.5f;
    public GameObject interactionPosition;

    private Interactable currentInteractable;
    public Vector2 destinationPosition;
    private float distToArrival;
    public bool hasToGo = false;
    private bool handleInput = true;
    private WaitForSeconds inputHoldWait;
    private TouchInput i;
    private GameObject bodySide, bodyBack;
    static Component[] poitsukkaParts;
    Cam c;



    public const string startingPositionKey = "starting position";



    private void Start()
    {
        c = FindObjectOfType<Cam>();
        bodyBack = GameObject.Find("Body2");
        bodySide = GameObject.Find("Body");
        i = new TouchInput();
        inputHoldWait = new WaitForSeconds (inputHoldDelay);
        SwitchPointOfView("side");
        poitsukkaParts = poitsukka.GetComponentsInChildren<SpriteRenderer>();
        //playerSaveData.Load(startingPositionKey, ref startingPositionName);
    }


    private void Update()
    {
        
        if (currentInteractable)
        {
            destinationPosition = currentInteractable.interactionLocation.position;
            distToArrival = Mathf.Abs(transform.position.x-destinationPosition.x);
        }

        if (hasToGo == true && distToArrival > .2f)
        {
            Moving();
        }
        else if (hasToGo == true && distToArrival <= .2f)
        {
            Stopping();
        }

    }


    private void Stopping ()
    {

        //transform.position = destinationPosition;

        if (currentInteractable)
        {
            if (currentInteractable.interactionLocation.transform.localScale.y < 0)
            {
                SwitchPointOfView("back");
            }
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * currentInteractable.interactionLocation.transform.localScale.x, transform.localScale.y, transform.localScale.z);
            //transform.rotation = currentInteractable.interactionLocation.rotation;
            currentInteractable.Interact();
            currentInteractable = null;
            hasToGo = false;
            //c.UnZoom(10);
            i.stopInteract();
            SwitchPointOfView("side");
            //  StartCoroutine (WaitForInteraction ());
        }
    }


    private void Moving ()
    {
        //Quaternion targetRotation = Quaternion.LookRotation(Vector2.right);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);
        if (destinationPosition.x < transform.position.x)
        {
            i.destinationLocation = destinationPosition;
            i.WalkToInteraction(-1, destinationPosition, transform.position);
        }
        else
        {
            i.destinationLocation = destinationPosition;
            i.WalkToInteraction(1, destinationPosition, transform.position);
        }
            
    }


    public void OnInteractableClick(Interactable interactable)
    {
        //if(!handleInput)
        //    return;

        

        if (Mathf.Abs(interactable.transform.position.x - transform.position.x) < 100)
        {
            Debug.Log("Interaction initialisee");
            currentInteractable = interactable;
            //c.Zoom(10);
            destinationPosition = currentInteractable.interactionLocation.position;

            hasToGo = true;
        }
        else
        {
            Debug.Log("That's too far");
        }
    }

    public void OnGUI()
    {
    }


    /* private IEnumerator WaitForInteraction ()
     {
         handleInput = false;

         yield return inputHoldWait;

         while (animator.GetCurrentAnimatorStateInfo (0).tagHash != hashLocomotionTag)
         {
             yield return null;
         }

         handleInput = true;
     }*/

    void SwitchPointOfView(string ViewPoint)
    {

        switch (ViewPoint)
        {

            case "back":
                foreach (Renderer r in bodySide.GetComponentsInChildren(typeof(Renderer)))
                {
                    r.enabled = false;
                }
                foreach (Renderer r in bodyBack.GetComponentsInChildren(typeof(Renderer)))
                {
                    r.enabled = true;
                }
                break;

            case "side":
                foreach (Renderer r in bodySide.GetComponentsInChildren(typeof(Renderer)))
                {
                    r.enabled = true;
                }
                    foreach (Renderer r in bodyBack.GetComponentsInChildren(typeof(Renderer)))
                {
                    r.enabled = false;
                }
                break;


        }
    }
}
