using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Colors;


public class BackgroundObjects : MonoBehaviour {

    List<BackgroundObject> childList = new List<BackgroundObject>();

    public PaletteGenerator paletteGen;

    void Awake() {

        foreach (Transform child in transform) {

            childList.Add(child.GetComponent<BackgroundObject>());
        }
    }

    void Update() {

        foreach (BackgroundObject obj in childList) {

            foreach (Transform child in obj.transform) {

                child.GetComponent<SpriteRenderer>().color = Color.Lerp(child.GetComponent<SpriteRenderer>().color, obj.currentColor, Time.deltaTime * 2);
            }
        }
    }

    public void updateColors(Color color) {
        
        paletteGen.offset.baseColor = color;
        paletteGen.Generate();

        foreach (BackgroundObject obj in childList) {

            obj.currentColor = paletteGen.palette.colors[Random.Range(0, paletteGen.palette.colors.Length)];
        }

    }
}