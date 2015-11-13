using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Background : MonoBehaviour {

    public float speed;
    SpriteRenderer sprite;

    public Color backgroundColor;

    void Awake() {

        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {

        sprite.color = Color.Lerp(sprite.color, backgroundColor, Time.deltaTime * speed);
    }

}