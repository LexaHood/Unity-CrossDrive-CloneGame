using UnityEngine;

[RequireComponent (typeof (moveCar))]
public class Acceleration : MonoBehaviour
{
    private bool accelerate = false;
    
    void OnMouseDown() {
        if (!accelerate) {
            GetComponent <moveCar> ().speed *= 2f;
            accelerate = true;
        }    
    }
}
