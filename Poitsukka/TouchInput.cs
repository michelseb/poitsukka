using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{

    Touch t;
    Vector3 ray;
    RaycastHit hit;
    public static Camera cam;
    Cam camScript;
    static Transform tr;
    static GameObject poitsukka, poitsukkaPos;
    static Component[] poitsukkaParts;
    static Poitsukka poitsukkaScript;
    public static float speed;
    public GameObject[] checkpoints;
    public int reachedCheckPoint, reachedMod;
    public int nbCheckpoints;
    public int destination, destMod;
    public Vector2 destinationLocation;
    float dist;
    Vector3 ymove;
    float Direction;
    float scale;
    static float startposY;
    public static bool interacting;
    public static bool dragging;
    static Vector2 sourceDrag;
    static Transform dragParent;
    public static int reachedOrder;
    public static GameObject itemBeingDragged;
    public static bool allowedToMove;
    public GameObject trunc;
    Aika a;


    private void Awake()
    {

        cam = this.GetComponent<Camera>();
        camScript = cam.GetComponent<Cam>();
        poitsukka = GameObject.Find("Poitsukka");
        poitsukkaPos = GameObject.Find("PoitsukkaPosition");
        poitsukkaScript = poitsukka.GetComponent<Poitsukka>();
        tr = transform;
        poitsukkaParts = poitsukka.GetComponentsInChildren<SpriteRenderer>();
        a = gameObject.GetComponent<Aika>();
    }

    // Use this for initialization
    void Start()
    {
        speed = camScript.speed;
        nbCheckpoints = checkpoints.Length;
        startposY = poitsukkaPos.transform.localPosition.y;
        allowedToMove = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        dist = Vector2.Distance(poitsukkaPos.transform.position, destinationLocation);
        //J'ai touché quelque chose
        if (allowedToMove)
        {
            if (Input.touchCount == 1)
            {

                if (Mathf.Abs(poitsukkaPos.transform.position.x - checkpoints[destMod].transform.position.x) < 1)
                {

                    if (destination < reachedCheckPoint)
                    {
                        reachedCheckPoint = reachedCheckPoint - 1;
                    }
                    else
                    {
                        reachedCheckPoint = reachedCheckPoint + 1;
                    }
                    reachedMod = reachedCheckPoint % nbCheckpoints;
                    reachedOrder = checkpoints[reachedMod].GetComponent<SpriteRenderer>().sortingOrder;

                    trunc.GetComponent<SpriteRenderer>().sortingOrder = checkpoints[destMod].GetComponent<SpriteRenderer>().sortingOrder;
                    //sortOrder(checkpoints[destMod].GetComponent<SpriteRenderer>().sortingOrder);

                }

                if (interacting == false && dragging == false)
                {
                    if (Input.GetTouch(0).position.x < Screen.width / 5 && Input.GetTouch(0).position.x > Screen.width / 8)
                    {
                        destination = reachedCheckPoint - 1;
                        if (destination < 0)
                        {
                            destination = nbCheckpoints - 1;
                            reachedCheckPoint = nbCheckpoints;
                        }
                        destMod = destination % nbCheckpoints;
                        destinationLocation = checkpoints[destMod].transform.position;
                        goToGoal(-1, destinationLocation, checkpoints[reachedMod].transform.position, 0);
                        a.speed = -450;
                    }
                    else if (Input.GetTouch(0).position.x > Screen.width * 4 / 5 && Input.GetTouch(0).position.x < Screen.width * 7 / 8)
                    {
                        destination = reachedCheckPoint + 1;
                        if (destination < 0)
                        {
                            destination = nbCheckpoints - 1;
                            reachedCheckPoint = nbCheckpoints;
                        }
                        destMod = destination % nbCheckpoints;
                        destinationLocation = checkpoints[destMod].transform.position;
                        goToGoal(1, destinationLocation, checkpoints[reachedMod].transform.position, 0);
                        a.speed = 450;
                    }
                    else if (Input.GetTouch(0).position.x > Screen.width * 7 / 8)
                    {
                        destination = reachedCheckPoint + 1;
                        if (destination < 0)
                        {
                            destination = nbCheckpoints - 1;
                            reachedCheckPoint = nbCheckpoints;
                        }
                        destMod = destination % nbCheckpoints;
                        destinationLocation = checkpoints[destMod].transform.position;
                        goToGoal(1, destinationLocation, checkpoints[reachedMod].transform.position, 1);
                        a.speed = 900;
                    }
                    else if (Input.GetTouch(0).position.x < Screen.width / 8)
                    {
                        destination = reachedCheckPoint - 1;
                        if (destination < 0)
                        {
                            destination = nbCheckpoints - 1;
                            reachedCheckPoint = nbCheckpoints;
                        }
                        destMod = destination % nbCheckpoints;
                        destinationLocation = checkpoints[destMod].transform.position;
                        goToGoal(-1, destinationLocation, checkpoints[reachedMod].transform.position, 1);
                        a.speed = -900;
                    }
                    else
                    {
                        poitsukkaScript.Idle();
                        a.speed = 0;
                    }
                }

            }
            else if (Input.anyKey)
            {

                if (Mathf.Abs(poitsukkaPos.transform.position.x - checkpoints[destMod].transform.position.x) < 1)
                {

                    if (destination <= reachedCheckPoint)
                    {
                        reachedCheckPoint = reachedCheckPoint - 1;
                        if (reachedCheckPoint < 0)
                        {
                            reachedCheckPoint = nbCheckpoints - 1;
                            destination = nbCheckpoints;
                        }
                    }
                    else
                    {
                        reachedCheckPoint = reachedCheckPoint + 1;
                    }
                    reachedMod = reachedCheckPoint % nbCheckpoints;
                    reachedOrder = checkpoints[reachedMod].GetComponent<SpriteRenderer>().sortingOrder;

                    trunc.GetComponent<SpriteRenderer>().sortingOrder = checkpoints[destMod].GetComponent<SpriteRenderer>().sortingOrder;
                    //sortOrder(checkpoints[destMod].GetComponent<SpriteRenderer>().sortingOrder);

                }

                if (interacting == false && dragging == false)
                {
                    if (Input.GetKey("left"))
                    {
                        destination = reachedCheckPoint;
                        
                        destMod = destination % nbCheckpoints;
                        destinationLocation = checkpoints[destMod].transform.position;
                        goToGoal(-1, destinationLocation, checkpoints[reachedMod].transform.position, 0);
                        a.speed = -450;
                    }
                    else if (Input.GetKey("right"))
                    {
                        destination = reachedCheckPoint + 1;
                        if (destination < 0)
                        {
                            destination = nbCheckpoints - 1;
                            reachedCheckPoint = nbCheckpoints;
                        }
                        destMod = destination % nbCheckpoints;
                        destinationLocation = checkpoints[destMod].transform.position;
                        goToGoal(1, destinationLocation, checkpoints[reachedMod].transform.position, 0);
                        a.speed = 450;
                    }
                    /*else if (Input.GetTouch(0).position.x > Screen.width * 7 / 8)
                    {
                        destination = reachedCheckPoint + 1;
                        if (destination < 0)
                        {
                            destination = nbCheckpoints - 1;
                            reachedCheckPoint = nbCheckpoints;
                        }
                        destMod = destination % nbCheckpoints;
                        destinationLocation = checkpoints[destMod].transform.position;
                        goToGoal(1, destinationLocation, checkpoints[reachedMod].transform.position, 1);
                        a.speed = 900;
                    }
                    else if (Input.GetTouch(0).position.x < Screen.width / 8)
                    {
                        destination = reachedCheckPoint - 1;
                        if (destination < 0)
                        {
                            destination = nbCheckpoints - 1;
                            reachedCheckPoint = nbCheckpoints;
                        }
                        destMod = destination % nbCheckpoints;
                        destinationLocation = checkpoints[destMod].transform.position;
                        goToGoal(-1, destinationLocation, checkpoints[reachedMod].transform.position, 1);
                        a.speed = -900;
                    }
                    else
                    {
                        poitsukkaScript.Idle();
                        a.speed = 0;
                    }*/
                }

            }
            else
            {
                poitsukkaScript.Idle();
                a.speed = 0;
            }
        }
    }

    public void OnGUI()
    {
        
    }

    public void goToGoal(int dir, Vector2 checkpoint, Vector2 provenance, int goMode)
    {


        //float Direction = (checkpoint.y - poitsukkaPos.transform.position.y) * speed * Time.deltaTime / (1 + Mathf.Abs((checkpoint.y - provenance.y) / 10)); // ((checkpoints[destination].transform.position.x - poitsukka.transform.position.x));
        Vector2 Direction = (checkpoint - provenance);
        float scale = (poitsukkaPos.transform.localPosition.y / startposY);
        float dist = Direction.magnitude;
        float goaly = Direction.y / dist * speed * Time.deltaTime;
        float goalx = Direction.x / dist * speed * Time.deltaTime;
        //poitsukka.transform.position = Vector2.Lerp(poitsukka.transform.position, checkpoints[destination].transform.position, speed * Time.deltaTime);

        poitsukka.transform.Translate(new Vector3(0, goaly, 0));
        poitsukka.transform.localScale = new Vector3(scale, scale, scale);

        
        if (dir == 1)
        {
            poitsukkaScript.Flip("droite");
        }
        else
        {
            poitsukkaScript.Flip("gauche");
        }

        switch (goMode)
        {
            case 0:
                //tr.Translate(dir * speed * Time.deltaTime / (1 + Mathf.Abs((checkpoint.y - provenance.y) / 10)), 0, 0);
                tr.Translate(goalx, 0, 0);
                poitsukkaScript.Walk();
                break;
            case 1:
                tr.Translate(dir * 2 * speed * Time.deltaTime / (1 + Mathf.Abs((checkpoint.y - provenance.y) / 10)), 0, 0);
                poitsukkaScript.Run();
                break;
        }
        
    }


    public void WalkToInteraction (int dir, Vector2 checkpoint, Vector2 prov)
    {
        dist = Mathf.Abs(poitsukka.transform.position.x -  destinationLocation.x);
        interacting = true;
        goToGoal(dir, checkpoint, prov, 0);
    }

    public void stopInteract()
    {
        interacting = false;
    }

    public void beginDrag(Transform t)
    {
        sourceDrag = t.position;
        dragParent = t.parent;
        //GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void dragUI(Transform t)
    {
        dragging = true;
        
    }

    public void dropUI(Transform t)
    {
        dragging = false;
        if (t.parent != dragParent)
        {
            t.position = sourceDrag;
        }
        //GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void sortOrder(int ord)
    {
        foreach (SpriteRenderer s in poitsukkaParts)
        {
            s.sortingOrder = s.sortingOrder + (ord - reachedOrder);
        }
    }

}
