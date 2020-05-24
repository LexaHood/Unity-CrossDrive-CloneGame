using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigerTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Car" && !other.isTrigger) {
            other.gameObject.GetComponent<superTurn>().turnOnCar();
        }  
    }

    private void OnTriggerExit(Collider other) {
        if (!other.isTrigger)
            other.gameObject.GetComponent<superTurn>().setTurned();
    }
}
