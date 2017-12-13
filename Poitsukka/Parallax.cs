using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    Transform cam;
    GameObject[] objets;
    SpriteRenderer[] sprites;
    Vector3 previousPos;
    float[] speeds;
    Color col;
    public float smoothing;
    public bool active;
    GameObject ground_talvi, ground_kesä, ground_kevät, ground_syksy;

    private void Awake()
    {

        cam = transform;

    }


    // Use this for initialization
    void Start() {
        active = true;
        ground_talvi = GameObject.Find("ground_talvi");
        ground_kesä = GameObject.Find("ground_kesä");
        ground_kevät = GameObject.Find("ground_kevät");
        ground_syksy = GameObject.Find("ground_syksy");
        objets = GameObject.FindGameObjectsWithTag("parallable");
        sprites = GameObject.FindObjectsOfType(typeof(SpriteRenderer)) as SpriteRenderer[];
        previousPos = cam.position;
        speeds = new float[objets.Length];
        for (int i = 0; i < objets.Length; i++)
        {
            if (objets[i].GetComponent<SpriteRenderer>().sortingOrder < 17 && objets[i].GetComponent<SpriteRenderer>().sortingLayerName != "backgroundGrounds")
            {
                objets[i].GetComponent<SpriteRenderer>().sortingLayerName = "backgrounds";
            }
            speeds[i] = objets[i].GetComponent<SpriteRenderer>().sortingOrder;
            if (objets[i].GetComponent<SpriteRenderer>().sortingLayerName != "backgroundGrounds")
            {
                objets[i].transform.localScale = new Vector3(objets[i].transform.localScale.x - .5f + speeds[i] / 40, objets[i].transform.localScale.y - .5f + speeds[i] / 40, objets[i].transform.localScale.z - .5f + speeds[i] / 40);
            }
            objets[i].transform.position = new Vector3(objets[i].transform.position.x, 5 - 2 * speeds[i] / 3, objets[i].transform.position.z);
        }
        for (int a = 0; a < sprites.Length; a++)
        {
            
            col = new Color(.9f * sprites[a].sortingOrder / 40 + .1f, .9f * sprites[a].sortingOrder / 40 + .1f, .6f + (.4f * sprites[a].sortingOrder / 40));
            sprites[a].color = new Color(col.r, col.g, col.b, sprites[a].color.a);
            
            
        }
        /*for (int i = 0; i < objets.Length; i++) {
            if (objets[i].GetComponent<SpriteRenderer>().sortingLayerName == "interactableLayer")
            {
                objets[i].transform.parent = ground_talvi.transform;
            }
        }*/
        smoothing = 10f;
    }

    // Update is called once per frame
    void Update() {

        if (active)
        {
            for (int i = 0; i < objets.Length; i++)
            {
                if (objets[i].GetComponent<SpriteRenderer>().sortingLayerName != "interactableLayer")
                {
                    float parallaxX = (previousPos.x - transform.position.x) * speeds[i];
                    float parallaxY = (previousPos.y - transform.position.y) * speeds[i];
                    float posXToBe = objets[i].transform.position.x + parallaxX;
                    float posYToBe = objets[i].transform.position.y + parallaxY;

                    Vector3 posToBe = new Vector3(posXToBe, posYToBe, objets[i].transform.position.z);
                    objets[i].transform.position = Vector3.Lerp(objets[i].transform.position, posToBe, smoothing * Time.deltaTime);
                }
            }
        }
        previousPos = cam.position;
    }

}