using UnityEngine;
using System.Collections;

public class LineScript : MonoBehaviour {
    private Vector3 dir;  

	// Use this for initialization
	void Start () {
        this.dir = Instantiator.dir;
        transform.localScale = Vector3.one * Instantiator.balkScale;
        this.GetComponent<Renderer>().material.color = Instantiator.getRandomColor();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < Instantiator.horizontalBorders && transform.position.x > -Instantiator.horizontalBorders && transform.position.y < Instantiator.verticalBorders && transform.position.y > -Instantiator.verticalBorders)
        {
            transform.position = transform.position + dir * Instantiator.speed * Time.deltaTime;
        }
        else
            Destroy(this.gameObject);
	}
}
