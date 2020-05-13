using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public Sprite button, pressed;
    public bool music;
    private Image img;
    private float yPos;
    private Transform child;

    void Start() {
        img = GetComponent <Image> ();
        child = transform.GetChild(0).transform;

        if (music) {
            if (PlayerPrefs.GetString ("Music") != "no") { // музыка сейчас играет и мы можем ее выключить
                transform.GetChild (0).gameObject.SetActive (true);
                transform.GetChild (1).gameObject.SetActive (false);
            }
            else {
                transform.GetChild (0).gameObject.SetActive (false);
                transform.GetChild (1).gameObject.SetActive (true);
                child = transform.GetChild(1).transform;
            }
        }
    }

    void OnMouseDown() {
         img.sprite = pressed;
         yPos = child.localPosition.y;
         child.localPosition = new Vector3 (child.localPosition.x, 0, child.localPosition.z); 
    }

    void OnMouseUp() {
        img.sprite = button;
        child.localPosition = new Vector3 (child.localPosition.x, yPos, child.localPosition.z); 
    }

    private void OnMouseUpAsButton() {
        switch (gameObject.name) {
            case "Play":
                StartCoroutine (loadScene("game")); 
                break;
            case "Music": 
                child.gameObject.SetActive (false);
                if (PlayerPrefs.GetString ("Music") != "no") {
                    PlayerPrefs.SetString ("Music", "no");
                    child = transform.GetChild (1).transform;
                }
                else {
                    PlayerPrefs.DeleteKey ("Music");
                    child = transform.GetChild (0).transform;
                }
                child.gameObject.SetActive (true);
                break;
            default: break;
        }
    }

    IEnumerator loadScene (string scene) {
        float fadeTime = Camera.main.GetComponent <Fading>().beginFade (1);
        yield return new WaitForSeconds (fadeTime);
        SceneManager.LoadScene (scene);
    }

    void Update() {
       
    }
}
