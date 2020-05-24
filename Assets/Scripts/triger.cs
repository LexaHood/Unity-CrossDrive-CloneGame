using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triger: MonoBehaviour
{
    superTurn thisCar = null;
    void Start() {
        //print(this.gameObject.name);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Car" && !other.isTrigger) {
            //print(this.gameObject.name);
            thisCar = other.gameObject.GetComponent<superTurn>();
            thisCar.wayCar2(this.gameObject.name);
        }  
    }




}
