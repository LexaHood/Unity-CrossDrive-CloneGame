using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]
public class showFps : MonoBehaviour {
    Text myFpsText = null;
    void Start() {
        myFpsText = GetComponent<Text>();
        StartCoroutine (calcFps());
    }

    IEnumerator calcFps() {
        while (true) {
            myFpsText.text = "fps: " + 1.0f / Time.deltaTime;
            yield return new WaitForSeconds (0.10f);
        }
    }
}
