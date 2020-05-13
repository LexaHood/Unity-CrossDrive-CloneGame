using System.Collections;
using UnityEngine;

[RequireComponent (typeof (moveCar))]
public class eastTurnLeft : MonoBehaviour {
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
        if  (transform.localPosition.x < 1f && carRotation != 0 && !turnOn) {
            if (carRotation >= -1f && carRotation <= 4f) {
                transform.localRotation = Quaternion.Euler (new Vector3 (0, 0f, 0));
                turnOn = true;
                return;
            }
            eularAngelsVelocity = GetComponent <moveCar>().speed * -8.57f;
            Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0, eularAngelsVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation (rb.rotation * deltaRotation);
        }
    }
}
