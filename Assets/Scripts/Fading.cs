﻿using System.Collections;
using UnityEngine;

public class Fading : MonoBehaviour {
    public Texture2D fadeOutTexture;
    private float fadeSpeed = 0.8f;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int faderDir = -1;

    void OnGUI() {
        alpha += faderDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01 (alpha);

        GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float beginFade (int derection) {
        faderDir = derection;
        return fadeSpeed;
    }

    void OnEnable() {
        beginFade (-1);    
    }
}
