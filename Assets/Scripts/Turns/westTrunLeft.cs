using System.Collections;
using UnityEngine;

[RequireComponent (typeof (moveCar))]
public class westTrunLeft : MonoBehaviour {
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
        if  (transform.localPosition.x > -7f && carRotation != 180f && !turnOn) {
            if (carRotation >= 180f && carRotation <= 184f) {
                transform.localRotation = Quaternion.Euler (new Vector3 (0, 180f, 0));
                turnOn = true;
                return;
            }
            eularAngelsVelocity = GetComponent <moveCar>().speed * -8.57f;
            Quaternion deltaRotation = Quaternion.Euler (new Vector3 (0, eularAngelsVelocity, 0) * Time.fixedDeltaTime);
            rb.MoveRotation (rb.rotation * deltaRotation);
        }
    }
    

}
