using System.Collections;
using UnityEngine;

[RequireComponent (typeof (moveCar))]
public class southTurnLeft : MonoBehaviour {
    Rigidbody rb;
    float eularAngelsVelocity;
    bool turnOn = false;
    
    void Start()  {
        rb = GetComponent <Rigidbody> ();
    }

    private void FixedUpdate() {
        leftTurn();
    }

    void leftTurn () {
        float carRotation = Mathf.Floor(transform.eulerAngles.y);
        if  (transform.localPosition.z > -3.5f && carRotation != 90f && !turnOn) {
            if (carRotation >= 89f && carRotation <= 94f) {
                transform.localRotation = Quaternion.Euler (new Vector3 (0, 90f, 0));
                turnOn = true;
                return;
            }
            eularAngelsVelocity = GetComponent <moveCar>().speed * -88f;
            Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0, eularAngelsVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation (rb.rotation * deltaRotation);
        }
    }
}
