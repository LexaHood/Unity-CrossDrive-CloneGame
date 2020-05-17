using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        print(transform.localRotation.eulerAngles);
        transform.Rotate(new Vector3 (45, 0, 0) * Time.deltaTime);
    }

    Vector4 rotationVector() {
        return new Vector4 (transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }
}
