using UnityEngine;
using System.Collections;

public class CircleScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Farbe zufällig setzen
        this.GetComponent<Renderer>().material.color = Instantiator.getRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Instantiator.liveScale)
        {
            if (Instantiator.circScaleDir > 0)
            {
                if (transform.localScale.x < Instantiator.circEndScale)
                {
                    transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Instantiator.speed * Time.deltaTime;
                    transform.Rotate(Vector3.down, Instantiator.circRotDir * Instantiator.circRotSpeed * Time.deltaTime);
                }
                else Destroy(this.gameObject);
            }
            else
            {
                if (transform.localScale.x > Instantiator.circEndScale)
                {
                    transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Instantiator.speed * Time.deltaTime;
                    transform.Rotate(Vector3.down, Instantiator.circRotDir * Instantiator.circRotSpeed * Time.deltaTime);
                }
                else Destroy(this.gameObject);
            }
        }
        else
        {
            if (transform.localScale.x >= 0 || Instantiator.liveScaleValue > 0)
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(Instantiator.liveScaleValue, 1, Instantiator.liveScaleValue), Time.deltaTime);
            transform.Rotate(Vector3.down, Instantiator.circRotDir * Instantiator.circRotSpeed * Time.deltaTime);
        }

    }
}
