using UnityEngine;
using System.Collections;

public class TouchPannel : MonoBehaviour
{
    //Effekte
    public GameObject circle;
    public GameObject line;
    public GameObject circleDashed;
    public GameObject box;
    public GameObject lineDashed;
    public GameObject triangle;
    public GameObject triangleDashed;
    public GameObject circleHalfDashed;

    //Screen Grenzen
    public int scaley = Instantiator.verticalBorders;
    public int scalex = Instantiator.horizontalBorders;

    //Private Attribute
    private int shapeType = 0;
    private bool dashedLine = false;
    private float currTap = 0;
    private float lastTap = 0;
    private float tapTime = 0;
    private float stationaryTouchThreshold = .5f;

    // Control values
    //private Vector3[] fingers = new Vector3[5];
    private bool stationary = false;
    private int tapCount = 0;

    private void clear(string objectTag)
    {
        if (GameObject.FindGameObjectsWithTag(objectTag) != null)
        {
            GameObject[] a = GameObject.FindGameObjectsWithTag(objectTag);
            for (int i = 0; i < a.Length; i++)
                Destroy(a[i].gameObject);
        }
    }

    IEnumerator circleDestroyer(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        clear("Circle");
    }

    // Use this for initialization
    void Start()
    {
        // Always rotate
        Instantiator.circRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Set stationary of tap count
        if (Input.touchCount > 0)
        {
            // Touch started
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                currTap = Time.deltaTime;
            }

            // Touch continues
            tapTime += Time.deltaTime;
            stationary = tapTime > stationaryTouchThreshold;
            if (stationary)
            {
                Debug.Log($"Stationary with {Input.touchCount} fingers");
                currTap = 0;
                lastTap = 0;
                switch (Input.touchCount)
                {
                    case 2: TwoFingersHold(); break;
                    case 3: ThreeFingersHold(); break;
                }
            }

            // Touch ended
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                // Check tap count 
                if (currTap - lastTap < stationaryTouchThreshold)
                {
                    tapCount = Input.GetTouch(0).tapCount;
                }

                if (tapCount > 0)
                {
                    Debug.Log($"Handle {tapCount} taps with {Input.touchCount} fingers");
                    switch (Input.touchCount)
                    {
                        case 1: OneFinger(); break;
                        case 2: TwoFingers(); break;
                        case 3: ThreeFingers(); break;
                    }
                    tapCount = 0;
                }

                // Set control values
                lastTap = currTap;
                if (stationary)
                {
                    tapTime = 0;
                    stationary = false;
                }
            }
        }
    }


    /*
    * TouchPanel 1
    * ------------
    * Erzeugen von Kreisen an Kontakt 0 
    * und Echtzeitskallierung bei halten
    */
    void OneFinger()
    {
        switch (tapCount)
        {
            case 1:
                //Figur inititalisieren
                Vector2 touchpos = Input.GetTouch(0).position;
                Vector3 createpos = Camera.main.ScreenToWorldPoint(new Vector3(touchpos.x, touchpos.y, 0));

                GameObject i;
                switch (shapeType)
                {
                    // Circle
                    case 0: i = dashedLine ? circleDashed : circle; break;
                    // Half circle
                    case 1: i = circleHalfDashed; break;
                    // Triangle
                    case 2: i = dashedLine ? triangleDashed : triangle; break;
                    // Rectangle
                    default: i = box; break;
                }
                Instantiator.scale(i, new Vector3(createpos.x, createpos.y, 0));
                break;
            case 2:
                shapeType += 1;
                shapeType %= 4;
                //Figur initialisieren & strichelung wechseln
                break;

        }
    }

    /*
    * TouchPanel 2
    * Erzeugen Von Linien an Kontaktpunkt 1
    * ------------
    */
    void TwoFingersHold()
    {
        // Set rotation by pinch
        Vector2 touch0, touch1;
        touch0 = Input.GetTouch(0).position;
        touch1 = Input.GetTouch(1).position;
        float newRotSpeed = Vector2.Distance(touch0, touch1) * Time.deltaTime;
        if (newRotSpeed >= 10f)
        {
            Instantiator.circRotation = true;
            Instantiator.circRotSpeed = newRotSpeed * 5;
            Instantiator.circRotDir = 1;
        }
        else
        {
            Instantiator.circRotation = false;
            Instantiator.circRotSpeed = 0;
        }
        Debug.Log($"Circle-Rot-Speed {Instantiator.circRotSpeed}");
    }

    void TwoFingers()
    {
        if (!stationary)
        {
        switch (tapCount)
        {
            case 1:
                Vector2 deltTouch = Input.GetTouch(1).position - Input.GetTouch(0).position;
                Vector3 createpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(1).position.x, Input.GetTouch(1).position.y, 0));
                GameObject i = line;
                if (dashedLine == true)
                    i = lineDashed;

                //Spawn der Linien
                if (Mathf.Abs(deltTouch.x) > Mathf.Abs(deltTouch.y))
                {
                    if (Input.GetTouch(1).position.y > Screen.height / 2)
                    {
                        Instantiator.dir = new Vector3(0, -1, 0);
                        Instantiator.rot = new Vector3(-90, 0, 0);
                        Instantiator.move(i, new Vector3(1, createpos.y, 0));
                    }
                    else
                    {
                        Instantiator.dir = new Vector3(0, 1, 0);
                        Instantiator.rot = new Vector3(-90, 0, 0);
                        Instantiator.move(i, new Vector3(1, createpos.y, 0));
                    }
                }
                else
                {
                    if (Input.GetTouch(1).position.x > Screen.width / 2)
                    {
                        Instantiator.dir = new Vector3(-1, 0, 0);
                        Instantiator.rot = new Vector3(0, 90, -90);
                        Instantiator.move(i, new Vector3(createpos.x, 0, 0));
                    }
                    else
                    {
                        Instantiator.dir = new Vector3(1, 0, 0);
                        Instantiator.rot = new Vector3(0, 90, -90);
                        Instantiator.move(i, new Vector3(createpos.x, 0, 0));
                    }
                }
                break;
            case 2:
                dashedLine = !dashedLine;
                break;

        }
        }
    }

    void ThreeFingersHold()
    {
        // Set rotation by pinch
        Vector2 touch0, touch1, touch2;
        touch0 = Input.GetTouch(0).position;
        touch1 = Input.GetTouch(1).position;
        touch2 = Input.GetTouch(2).position;
        float avgDist = (Vector2.Distance(touch0, touch1) + Vector2.Distance(touch0, touch2)) / 2f;
        Instantiator.speed = (avgDist * .5f * Time.deltaTime) - 10f;
        Debug.Log($"Speed: {Instantiator.speed}");
    }
    void ThreeFingers()
    {
        dashedLine = !dashedLine;
    }
}
