using UnityEngine;

public class extraDelete : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Car") 
            other.gameObject.GetComponent<superTurn>().wayCar2("north");
    }
}
