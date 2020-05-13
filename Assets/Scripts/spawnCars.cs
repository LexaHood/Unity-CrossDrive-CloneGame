using System.Collections;
using UnityEngine;

public class spawnCars : MonoBehaviour {
    public GameObject[] cars;
    private float startSpawn = 0.5f, waitSpawn = 5f;
    void Start() {
        StartCoroutine (westCars());
    }

    IEnumerator westCars() {
        yield return new WaitForSeconds (Random.Range(startSpawn, startSpawn + 4.5f));
        while (true) {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-85.7f, -1.87f, -3.6f), 
                Quaternion.Euler (new Vector3 (0, -90f, 0))) as GameObject;
            int rand = Random.Range (0, 4);
            switch (rand) {
                case 1: carInst.AddComponent <westTrunLeft> ();
                    break;
                case 2: carInst.AddComponent <westTurnRight> ();
                    break;
                default: break;
            }
            yield return new WaitForSeconds (Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }
}
