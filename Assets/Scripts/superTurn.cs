using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (moveCar))]
public class superTurn : MonoBehaviour {
    bool turned = false;
    bool turnOn = false;
    bool sideOfTheWorldAssigned = false;
    float tempRotation = 0f;
    float speedRotationEtalon = 0f;
    float mirrorTurn = 0f;
    enum side
    {
        Right, Left, Straight
    }
    side turnSide;
    Transform turnLightFront = null, turnLightBack = null;

    void Start() {
        switch (Random.Range(0, 4)) {
            case 0: 
                turnSide = side.Left; 
                turnLightFront = gameObject.transform.Find("Left TR Front");
                turnLightBack = gameObject.transform.Find("Left TR Back");
                StartCoroutine (turnLightOn(turnLightFront, turnLightBack));  break;
            case 1: 
                turnSide = side.Right;
                turnLightFront = gameObject.transform.Find("Right TR Front");
                turnLightBack = gameObject.transform.Find("Right TR Back"); 
                StartCoroutine (turnLightOn(turnLightFront, turnLightBack)); break;
            default: 
                turnSide = side.Straight; 
                break;
        }
        mirrorTurn = mirrorTurnCheck();
        //print("" + this.gameObject.name + "  turnSide = " + turnSide); 
        //print("child find res: " + gameObject.transform.Find("LeftTRFront "));
        //gameObject.transform.Find("LeftTRFront ").gameObject.SetActive(true);
    }

    private void FixedUpdate() {
        if (turnOn && Mathf.Abs(tempRotation) <= 90f) 
            tempRotation += Turn(speedRotationEtalon, mirrorTurn);
        else if (tempRotation >= 90 && !turned) {
            turned = true; //конец поворота
            fixedRotation();
            StopAllCoroutines();
            StopTurnLight();
        }
    }

    float Turn (float speedRotation, float mirrorTurn) { //поворот
        float indexTurn = 0; //+ left     - right
        speedRotation = GetComponent <moveCar>().speed * 6.8f; 
        //print(transform.localRotation.eulerAngles);

        if (turnSide == side.Right) indexTurn = -1f * mirrorTurn; // +90      
        else if (turnSide == side.Left) indexTurn = 0.55f * mirrorTurn; //-90

        float rat = speedRotation * indexTurn * Time.deltaTime;
        transform.Rotate(new Vector3(0, rat, 0));

        return Mathf.Abs(rat);
    }

    public void wayCar2(string name) { //тригер вызывает эту фун-ию и назначает сторону света для дальнейшего уничтожения)))
        if (!sideOfTheWorldAssigned) {
            sideOfTheWorldAssigned = true;
        }
        else destroyCar();
        
    }

    void fixedRotation() { //выравнивает после поворота
        float angel = transform.localRotation.eulerAngles.y;
        angel = Mathf.Round(angel / 10) * 10;
        transform.rotation = Quaternion.Euler(new Vector3(0, angel, 0));
        int angelInt = (int)transform.localRotation.eulerAngles.y;

        //print ("angelInt " + angelInt);
        if (angelInt % 10 != 0) { 
            angelInt = angelInt / 10;
            transform.rotation = Quaternion.Euler(new Vector3(0, angelInt * 10, 0));
        }
    }

    public void turnOnCar () { //включаем поворот
        if (!turnOn && turnSide != side.Straight) 
            turnOn = true;
    }

    public bool getTurned() {
        return turned;
    }

    public void setTurned() {
        if (turnSide == side.Straight) turned = true;
    }

    float mirrorTurnCheck() { //отражаем лево и право
        if (transform.forward.x > 0) return -1f;
        else if (transform.forward.x < 0) return -1f;
        else if (transform.forward.z > 0) return -1f;
        else if (transform.forward.z < 0) return 1f;
        else print ("" + this.gameObject.name + "pizdec"); return 0f;
    }

    IEnumerator turnLightOn (Transform turnLightFront, Transform turnLightBack) { //заебали куратины мигаем поворотниками
        while (turnLightFront != null) {
            bool activation = turnLightFront.gameObject.activeSelf;
            turnLightFront.gameObject.SetActive(!activation);
            turnLightBack.gameObject.SetActive(!activation);
            yield return new WaitForSeconds(0.4f);
        }  
    }

    public void StopTurnLight() {
        if (turnSide != side.Straight) {
            turnLightFront.gameObject.SetActive(false);
            turnLightBack.gameObject.SetActive(false);
        }
    }

    void destroyCar() {
        //print(gameObject.name + " destroy");
        Destroy(gameObject);
    }
}
