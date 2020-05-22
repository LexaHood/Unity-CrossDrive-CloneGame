using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class superTurn : MonoBehaviour {

    class myWay {
        bool north, south, west, east;
        
        public myWay() {
            north = false;
            south = false;
            west = false;
            east = false;
        }

        public myWay(bool north, bool south, bool west, bool east) {
            this.north = north;
            this.south = south;
            this.west = west;
            this.east = east;    
        }

        public void setWay (string way) {
            switch (way) {
                case "triger_north": north = true; break;
                case "triger_south": south = true; break;
                case "triger_west": west = true; break;
                case "triger_east": east = true; break;
                default: errors(0); break;
            }
        }

        public string getWay() {
            if (north) return "north";
            else if (south) return "south";
            else if (west) return "west";
            else if (east) return "east";
            else return null;
        }

        public bool checkWriteWay() {
            if (north == false && south == false && west == false && east == false) return true;
            else return false;
        }

        private void errors(int num) {
            switch (num) {
                case 0: print("Неверное присваивание стороны света(направления)"); break;
                default: break;
            }
        }
    }

    myWay myCarWay = new myWay();
    bool turned = false;
    bool turnOn = false;
    Rigidbody rb = null;
    float tempRotation = 0f;
    float speedRotationEtalon = 0f;
    float mirrorTurn = 0f;
    enum side {
        Right, Left, Straight
    }
    side turnSide;

    void Start() {
        rb = GetComponent <Rigidbody> ();
        switch (Random.Range(0, 4)) {
            case 0: turnSide = side.Left; break;
            case 1: turnSide = side.Right; break;
            default: turnSide = side.Straight; break;
        }
        mirrorTurn = mirrorTurnCheck();
        print("" + this.gameObject.name + "  turnSide = " + turnSide); 
    }

    private void FixedUpdate() {
        if (turnOn && Mathf.Abs(tempRotation) <= 90f) 
            tempRotation += Turn();
        else if (tempRotation >= 90 && !turned) {
            turned = true; //конец поворота
            fixedRotation();
        }
    }

    float Turn () {
        float indexTurn = 0; //+ left     - right
        speedRotationEtalon = GetComponent <moveCar>().speed * 6.8f; 
        //print(transform.localRotation.eulerAngles);

        if (turnSide == side.Right) indexTurn = -1f * mirrorTurn; // +90      
        else if (turnSide == side.Left) indexTurn = 0.55f * mirrorTurn; //-90

        float rat = speedRotationEtalon * indexTurn * Time.deltaTime;
        transform.Rotate(new Vector3(0, rat, 0));

        return Mathf.Abs(rat);
    }

    public void wayCar2(string name) {
        if (myCarWay.checkWriteWay()) {
            myCarWay.setWay(name);
            print(gameObject.name + " " + myCarWay.getWay());
        }
        else destroyCar();
        
    }

    void fixedRotation() {
        float angel = transform.localRotation.eulerAngles.y;
        angel = Mathf.Round(angel / 10) * 10;
        transform.rotation = Quaternion.Euler(new Vector3(0, angel, 0));
        int angelInt = (int)transform.localRotation.eulerAngles.y;

        print ("angelInt " + angelInt);
        if (angelInt % 10 != 0) { 
            angelInt = angelInt / 10;
            transform.rotation = Quaternion.Euler(new Vector3(0, angelInt * 10, 0));
        }
    }

    public void turnOnCar () {
        if (!turnOn) 
            turnOn = true;
    }

    float mirrorTurnCheck() {
        if (transform.forward.x > 0) return -1f;
        else if (transform.forward.x < 0) return -1f;
        else if (transform.forward.z > 0) return -1f;
        else if (transform.forward.z < 0) return 1f;
        else print ("" + this.gameObject.name + "pizdec"); return 0f;
    }

    void destroyCar() {
        print(gameObject.name + " destroy");
        Destroy(gameObject);
    }
}
