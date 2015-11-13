using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Colors;


public class Mergsey : MonoBehaviour {

    public PaletteGenerator paletteGen;

    public SpriteRenderer background;
    public SpriteRenderer head;
    public SpriteRenderer crown;

    public MeshRenderer cylinder;

    public Background back;
    public BackgroundObjects backObjects;

    Color ranColor;

    void Awake() {

        updateColours();

        back.GetComponent<SpriteRenderer>().color = ranColor;
        back.backgroundColor = ranColor;
        backObjects.updateColors(ranColor);
    }

    public void updateColours() {

        ranColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        cylinder.material.SetColor("_Color", ranColor);

        paletteGen.randomWalk.startColor = ranColor;
        paletteGen.Generate();

        background.color = ranColor;

        head.color = paletteGen.palette.colors[0];
        crown.color = paletteGen.palette.colors[1];

        StartCoroutine(backgroundColor());
    }

    IEnumerator backgroundColor() {

        yield return new WaitForSeconds(1.1f);

        backObjects.updateColors(ranColor);
        back.backgroundColor = ranColor;
    }

    public void updateCamera() {

        back.backgroundColor = ranColor;
    }
}