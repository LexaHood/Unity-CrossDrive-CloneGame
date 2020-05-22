using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triger: MonoBehaviour
{
    void Start() {
        //print(this.gameObject.name);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Car" && !other.isTrigger) {
            //print(this.gameObject.name);
            other.gameObject.GetComponent<superTurn>().wayCar2(this.gameObject.name);
        }  
    }


}
