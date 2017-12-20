using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Aika : MonoBehaviour {
    public float päivämäärä;
    public TimeSpan currenttime;
    public int season;
    public Transform aurinkoMissä, aurinkoMissä2;
    public Color fogNight = Color.black;
    public Color fogDay = Color.gray;
    public Light aurinko, aurinko2;
    public float intensity;
    public GameObject talvi, kevät, kesä, syksy;
    SpriteRenderer[] c0, c1, c2, c3;
    float actalpha = 0, deactalpha = 1;
    public int speed;

    private void Awake()
    {

    }

    private void Start()
    {
        c0 = kevät.GetComponentsInChildren<SpriteRenderer>();
        c1 = kesä.GetComponentsInChildren<SpriteRenderer>();
        c2 = syksy.GetComponentsInChildren<SpriteRenderer>();
        c3 = talvi.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sp in c0)
        {
            if (sp.gameObject.tag != "Staying")
            {
                //sp.enabled = false
                sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 0);
            } 
        }
        foreach (SpriteRenderer sp in c1)
        {
            if (sp.gameObject.tag != "Staying") {
                //sp.enabled = false
                sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 0);
            }
        }
        foreach (SpriteRenderer sp in c2)
        {
            if (sp.gameObject.tag != "Staying")
            {
                //sp.enabled = false
                sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 0);
            }
        }
    }
    // Update is called once per frame
    void Update () {

        ChangeTime();

	}

    public void ChangeTime()
    {
        päivämäärä += (Time.deltaTime * speed);
        if (päivämäärä > 21600 && season < 1)
        {
            season = 1;
            StartCoroutine(DeactivateSprites(c0));
            StartCoroutine(ActivateSprites(c1));
            }
        else if (päivämäärä > 43200 && season < 2)
            {
                season = 2;
                StartCoroutine(DeactivateSprites(c1));
                StartCoroutine(ActivateSprites(c2));
            }
        else if (päivämäärä > 64800 && season < 3)
            {
                season = 3;
                StartCoroutine(DeactivateSprites(c2));
                StartCoroutine(ActivateSprites(c3));
            }
        else if (päivämäärä < 21600 && season > 0)
            {
                season = 0;
                StartCoroutine(ActivateSprites(c0));
                StartCoroutine(DeactivateSprites(c3));
            }
        else if (päivämäärä > 86400)
            {
                päivämäärä = 0;
            }
                    

        if (päivämäärä < 0)
        {
            season -= 1;
            if (season < 0) { season = 3; }
            switch (season)
            {
                case 0:
                    StartCoroutine(ActivateSprites(c0));
                    StartCoroutine(DeactivateSprites(c1));
                    break;
                case 1:
                    StartCoroutine(DeactivateSprites(c2));
                    StartCoroutine(ActivateSprites(c1));
                    break;
                case 2:
                    StartCoroutine(DeactivateSprites(c3));
                    StartCoroutine(ActivateSprites(c2));
                    break;
                case 3:
                    StartCoroutine(DeactivateSprites(c0));
                    StartCoroutine(ActivateSprites(c3));
                    break;
            }
            päivämäärä = 86400;
        }
        aurinkoMissä.rotation = Quaternion.Euler(new Vector3((päivämäärä - 21600) / 86400 * 360, 0, 0));
        aurinkoMissä2.rotation = Quaternion.Euler(new Vector3(-100+(päivämäärä - 21600) / 86400 * 360, 0, 0));
        if (päivämäärä < 43200)
        {
            intensity = 1 - (43200 - päivämäärä) / 43200;
        }
        else if (päivämäärä > 43200 && päivämäärä < 65400)
        {
            intensity = 1;//- ((43200 - päivämäärä) / 43200 * (-1));
        }
        else
        {
            intensity = 0;
        }
        RenderSettings.fogColor = Color.Lerp(fogNight, fogDay, intensity * intensity);
        aurinko.intensity = intensity;
        aurinko2.intensity = intensity;
    }

    IEnumerator ActivateSprites(SpriteRenderer[] s)
    {

        foreach (SpriteRenderer sp in s)
        {
            sp.enabled = true;
        }
        while (actalpha < 1) { 
            foreach (SpriteRenderer sp in s)
            {
                //sp.enabled = false
                if (sp.gameObject.tag != "Staying")
                {
                    actalpha = sp.color.a + .02f;
                    sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, actalpha);
                }
            }

            yield return null;
        }
        actalpha = 0;
    }

    IEnumerator DeactivateSprites(SpriteRenderer[] s)
    {
        
        
        while (deactalpha > 0)
        {
            foreach (SpriteRenderer sp in s)
            {
                //sp.enabled = false
                if (sp.gameObject.tag != "Staying")
                {
                    deactalpha = sp.color.a - .02f;
                    sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, deactalpha);
                }
            }
            yield return null;
        }
        foreach (SpriteRenderer sp in s)
        {
            if (sp.gameObject.tag != "Staying")
            {
                sp.enabled = false;
            }
        }
        deactalpha = 1;
    }
}
