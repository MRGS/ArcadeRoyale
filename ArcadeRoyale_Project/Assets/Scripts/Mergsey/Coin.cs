using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Coin : MonoBehaviour {

    public Mergsey side1;
    public Mergsey side2;

    public void updateSide1() {

        side1.updateColours();
        //side2.updateCamera();
    }

    public void updateSide2() {

        side2.updateColours();
        //side1.updateCamera();
    }
}