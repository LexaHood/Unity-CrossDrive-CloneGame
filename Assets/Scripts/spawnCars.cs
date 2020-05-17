using System.Collections;
using UnityEngine;

public class spawnCars : MonoBehaviour {
    public GameObject[] cars;
    private float startSpawn = 0.5f, waitSpawn = 5f;
    void Start() {
        StartCoroutine (westCars());
        StartCoroutine (eastCars());
        StartCoroutine (northCars());
        StartCoroutine (southCars());
    }

    IEnumerator westCars() {
        yield return new WaitForSeconds (Random.Range(startSpawn, startSpawn + 4.5f));
        while (true) {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-92f, -1.87f, -3.6f), //место спавна
                Quaternion.Euler (new Vector3 (0, -90f, 0))) as GameObject;
            yield return new WaitForSeconds (Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }

    IEnumerator eastCars() {
        yield return new WaitForSeconds (Random.Range(startSpawn, startSpawn + 4.5f));
        while (true) {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(53f, -1.87f, 3.75f), 
                Quaternion.Euler (new Vector3 (0, 90f, 0))) as GameObject;
            yield return new WaitForSeconds (Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }

    IEnumerator northCars() {
        yield return new WaitForSeconds (Random.Range(startSpawn, startSpawn + 4.5f));
        while (true) {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-6.5f, -1.87f, 66f), 
                Quaternion.Euler (new Vector3 (0, 0f, 0))) as GameObject;
            yield return new WaitForSeconds (Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }

    IEnumerator southCars() {
        yield return new WaitForSeconds (Random.Range(startSpawn, startSpawn + 4.5f));
        while (true) {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(0.6f, -1.87f, -53.61f), 
                Quaternion.Euler (new Vector3 (0, 180f, 0))) as GameObject;
            yield return new WaitForSeconds (Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }
}
