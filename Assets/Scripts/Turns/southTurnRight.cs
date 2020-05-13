using System.Collections;
using UnityEngine;

[RequireComponent (typeof (moveCar))]
public class southTurnRight : MonoBehaviour {
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
        if  (transform.localPosition.z > -11f && carRotation != 270f && !turnOn) {
            if (carRotation >= 269f && carRotation <= 274f) {
                transform.localRotation = Quaternion.Euler (new Vector3 (0, 270f, 0));
                turnOn = true;
                return;
            }
            eularAngelsVelocity = GetComponent <moveCar>().speed * 8.57f;
            Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0, eularAngelsVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation (rb.rotation * deltaRotation);
        }
    }
}
