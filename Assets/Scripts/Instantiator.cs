using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour
{

    //Attribute
    public static int verticalBorders = 6;
    public static int horizontalBorders = 10;

    //Globale KontrollAttribute
    public static float speed;
    public static bool controllable;

    //Farben
    public static Color verlauf = new Color(255, 0, 0);

    //Balken
    public static Vector3 dir;
    public static Vector3 rot;
    public static float balkScale;

    //Kreis
    public static bool circRotation;
    public static int circScaleDir;
    public static int circRotDir;
    public static float circStartScale;
    public static float circEndScale;
    public static float circRotSpeed;
    public static float liveScaleValue;
    public static bool liveScale = false;

    //Methoden
    public static void move(GameObject obj, Vector3 pos)
    {
        Instantiate(obj, pos, Quaternion.Euler(rot));
    }


    public static void scale(GameObject obj, Vector3 pos)
    {
        if (liveScale == false)
            obj.transform.localScale = new Vector3(circStartScale, circStartScale, circStartScale);
        else
            obj.transform.localScale = new Vector3(liveScaleValue, liveScaleValue, liveScaleValue);
        Instantiate(obj, pos, Quaternion.Euler(rot));
    }

    public static Color getRandomColor()
    {
        int i = Random.Range(1, 10);
        switch (i)
        {
            case 1:
                return new Color(64, 224, 208);
            case 2:
                return new Color(0, 0, 255);
            case 3:
                return new Color(0, 255, 0);
            case 4:
                return new Color(255, 215, 0);
            case 5:
                return new Color(255, 255, 0);
            case 6:
                return new Color(255, 50, 0);
            case 7:
                return new Color(255, 0, 255);
            case 8:
                return new Color(155, 48, 255);
            case 9:
                return new Color(255, 255, 255);
            case 10:
                return new Color(34, 139, 34);
            default:
                return new Color(255, 255, 255);
        }
    }


    void Start()
    {
    }

    void Update()
    {
    }
}
