using UnityEngine;

[RequireComponent (typeof (moveCar))]
public class CollisionCars : MonoBehaviour {
    public static bool lose = false;
    private bool onceStop;
    
    void OnCollisionEnter(Collision other) {
       if (other.gameObject.tag == "Car" && !onceStop) {
           lose = true;
           onceStop = true;
           gameObject.GetComponent <moveCar> ().speed = 0f;
           other.gameObject.GetComponent <moveCar>().speed = 0f;
           gameObject.GetComponent <Rigidbody> ().AddRelativeForce (Vector3.forward * -1200);
           gameObject.GetComponent<superTurn>().StopTurnLight();
           Camera.main.GetComponent<Houston>().loseUiActivate();
        }
    }
}
