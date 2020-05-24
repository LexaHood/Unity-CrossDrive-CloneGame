using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (superTurn))]
public class antiCrashSys : MonoBehaviour {
    superTurn turnComponent = null;
    moveCar moveCarComponent = null;
    void Start() {
        turnComponent = GetComponent <superTurn>();
        moveCarComponent = GetComponent <moveCar>();
    }

    private void OnTriggerStay(Collider other) {
        if (turnComponent.getTurned() && other.tag == "Car" && !other.isTrigger) {
            moveCarComponent.setSpeed(other.GetComponent <moveCar>().getSpeed());
        }
    }
}
