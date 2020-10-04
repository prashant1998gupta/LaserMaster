using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {

    public GameObject circle;
    public GameObject Line;
    public GameObject dashedCirc;
    public GameObject box;
    public GameObject LineDashed;
    public GameObject Triangle;
    public GameObject TriangleDashed;

	// Use this for initialization
	void Start () {
	//Dummy initialisierung
        Instantiator.speed = 5;
        Instantiator.balkScale = 1.4f;
        Instantiator.circEndScale = 2;
        Instantiator.circStartScale = 0.02f;
        Instantiator.circRotSpeed = 0;
        Instantiator.dir = Vector3.down;
        Instantiator.rot = new Vector3(-90,0,0);
        Instantiator.circScaleDir = 1;
        Instantiator.circRotation = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiator.dir = new Vector3(0, 1, 0);
            Instantiator.rot = new Vector3(-90, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Instantiator.dir = new Vector3(0, -1, 0);
            Instantiator.rot = new Vector3(-90, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Instantiator.dir = new Vector3(1, 0, 0);
            Instantiator.rot = new Vector3(0, 90, -90);
            Instantiator.circRotDir = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Instantiator.dir = new Vector3(-1, 0, 0);
            Instantiator.rot = new Vector3(0, 90, -90);
            Instantiator.circRotDir = -1;
        }

        if (Input.GetKeyDown(KeyCode.Plus))
        {
            Instantiator.circRotation = true;
            Instantiator.circRotDir = Instantiator.circRotSpeed > 0 ? 1 : -1;
            Instantiator.circRotSpeed += 1f;
            Instantiator.speed += 1f;
            Debug.Log(Instantiator.circRotSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            Instantiator.circRotation = true;
            Instantiator.circRotDir = Instantiator.circRotSpeed > 0 ? 1 : -1;
            Instantiator.circRotSpeed -= 1f;
            Instantiator.speed -= 1f;
            Debug.Log(Instantiator.circRotSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiator.move(Line, Vector3.zero);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiator.scale(circle, Vector3.zero);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiator.scale(dashedCirc, Vector3.zero);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiator.scale(Triangle, Vector3.zero);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiator.scale(TriangleDashed, Vector3.zero);
        }
	}
}
