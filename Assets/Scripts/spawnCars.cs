using System.Collections;
using UnityEngine;

public class spawnCars : MonoBehaviour {
    public GameObject[] cars;
    private float startSpawn = 0f, waitSpawn = 4f;
    int countCars = 0;
    private bool onceStop = false;
    void Start() {
        StartCoroutine (westCars());
        StartCoroutine (eastCars());
        StartCoroutine (northCars());
        StartCoroutine (southCars());

        CollisionCars.lose = false;
    }

    void FixedUpdate() {
        if (countCars > 60) waitSpawn = 1f;
        else if (countCars > 40) waitSpawn = 2f;
        else if (countCars > 20) waitSpawn = 3f;  

        if (CollisionCars.lose && !onceStop) {
            StopAllCoroutines();
            onceStop = true;
        }  
    }

    IEnumerator westCars() {
        yield return new WaitForSeconds (Random.Range(startSpawn, startSpawn + 4.5f));
        while (true) {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-105f, -1.87f, -3.6f), //место спавна
                Quaternion.Euler (new Vector3 (0, -90f, 0))) as GameObject;
            countCars++;
            yield return new WaitForSeconds (Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }

    IEnumerator eastCars() {
        yield return new WaitForSeconds (Random.Range(startSpawn, startSpawn + 4.5f));
        while (true) {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(67f, -1.87f, 3.75f), 
                Quaternion.Euler (new Vector3 (0, 90f, 0))) as GameObject;
            countCars++;
            yield return new WaitForSeconds (Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }

    IEnumerator northCars() {
        yield return new WaitForSeconds (Random.Range(startSpawn, startSpawn + 4.5f));
        while (true) {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-6.5f, -1.87f, 90f), 
                Quaternion.Euler (new Vector3 (0, 0f, 0))) as GameObject;
            countCars++;
            yield return new WaitForSeconds (Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }

    IEnumerator southCars() {
        yield return new WaitForSeconds (Random.Range(startSpawn, startSpawn + 4.5f));
        while (true) {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(0.6f, -1.87f, -55f), 
                Quaternion.Euler (new Vector3 (0, 180f, 0))) as GameObject;
            countCars++;
            yield return new WaitForSeconds (Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }
}
