using UnityEngine;

[RequireComponent (typeof (Rigidbody))] //при подключении скрипта автоматически подключается rigitbody
public class moveCar : MonoBehaviour {
    Rigidbody rb;
    public float speed = 9f;


    void Start() {
        rb = GetComponent <Rigidbody> ();   
    }

    private void FixedUpdate() {
        rb.MovePosition (transform.position - transform.forward * speed * Time.deltaTime);
    }

    public float getSpeed() {
        return speed;
    }

    public void setSpeed(float speed) {
        this.speed = speed;
    }
}
