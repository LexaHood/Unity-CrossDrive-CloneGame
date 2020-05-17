using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigerTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Car") {
            other.gameObject.GetComponent<superTurn>().turnOnCar();
        }  
    }
}
