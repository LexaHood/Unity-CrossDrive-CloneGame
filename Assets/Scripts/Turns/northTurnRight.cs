using System.Collections;
using UnityEngine;

[RequireComponent (typeof (moveCar))]
public class northTurnRight : MonoBehaviour {
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
        if  (transform.localPosition.z < 10f && carRotation != 90f && !turnOn) {
            if (carRotation >= 89f && carRotation <= 94f) {
                transform.localRotation = Quaternion.Euler (new Vector3 (0, 90f, 0));
                turnOn = true;
                return;
            }
            eularAngelsVelocity = GetComponent <moveCar>().speed * 8.57f;
            Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0, eularAngelsVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation (rb.rotation * deltaRotation);
        }
    }
}
