using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]//только олин скрипт на объект
public class moveObject : MonoBehaviour {
    [SerializeField] Vector3 movePosiotion = new Vector3 (0, 0, 0);
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] [Range(0, 1)] float moveProgress = 0;
    Vector3 startPosition = new Vector3 (0, 0, 0);
    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        moveProgress = Mathf.PingPong(Time.time * moveSpeed, 1);
        Vector3 offset = movePosiotion * moveProgress;
        transform.position = startPosition + offset;
    }
}
