using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchGenerator : MonoBehaviour {
    GameObject[] go;
    public GameObject branch;
    public GameObject leaves;
    public Material m;
	// Use this for initialization
	void Start () {
        go = (GameObject[])FindObjectsOfType(typeof(GameObject));
        for (int i = 0; i < go.Length; i++)
        {
            if (go[i].name.Contains("birch"))
            {
                addBranch(go[i], Random.Range(0,2));
            }
        } 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void addBranch(GameObject go, int nb)
    {
        for (int i = 0; i < nb; i++)
        {
            GameObject b = Instantiate(branch);
            SpriteRenderer s = b.GetComponent<SpriteRenderer>();
            SpriteRenderer sg = go.GetComponent<SpriteRenderer>();
            float size = Random.Range(-.7f, .7f);
            b.transform.localScale = new Vector3(size, Mathf.Abs(size), 1);
            b.transform.position = new Vector3(go.transform.position.x + (s.size.x * size) / 2, Random.Range(go.transform.position.y, go.transform.position.y + 2*s.size.y), go.transform.position.z);
            /*s.flipX = (Random.value < .5f);
            switch (s.flipX){
                case true:
                    b.transform.position = new Vector3(go.transform.position.x - s.size.x / 2, Random.Range(go.transform.position.y - s.size.y / 2, go.transform.position.y + s.size.y / 2), go.transform.position.z);
                    break;
                case false:
                    b.transform.position = new Vector3(go.transform.position.x + s.size.x / 2, Random.Range(go.transform.position.y - s.size.y / 2, go.transform.position.y + s.size.y / 2), go.transform.position.z);
                    break;
            }*/
            s.sortingLayerName = sg.sortingLayerName;
            s.sortingOrder = sg.sortingOrder;
            //b.transform.Rotate(new Vector3(Random.Range(-10, 10),0,0));
            //b.tag = "parallable";
            b.transform.parent = go.transform;
            GameObject l = Instantiate(leaves);
            SpriteRenderer sl = l.GetComponent<SpriteRenderer>();
            l.transform.localScale = new Vector3(size, Mathf.Abs(size), 1);
            l.transform.position = new Vector3(go.transform.position.x + 2+(s.size.x * size) / 2, b.transform.position.y+2, go.transform.position.z);
            sl.sortingLayerName = sg.sortingLayerName;
            sl.sortingOrder = sg.sortingOrder;
            sl.material = m;
            l.transform.parent = b.transform;
        }
    }
}
