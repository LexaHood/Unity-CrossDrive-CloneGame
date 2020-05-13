﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]//только олин скрипт на объект
public class moveObject : MonoBehaviour {
    [SerializeField] Vector3 movePosiotion;
    [SerializeField] float moveSpeed;
    [SerializeField] [Range(0, 1)] float moveProgress;
    Vector3 startPosition;
    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        moveProgress = Mathf.PingPong(Time.time * moveSpeed, 1);
        Vector3 offset = movePosiotion * moveProgress;
        transform.position = startPosition + offset;
    }
}
