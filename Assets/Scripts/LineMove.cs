using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMove : MonoBehaviour {
    public float speed=0.1f;
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("sdsf");
    }
    // Update is called once per frame
    void Update () {
        gameObject.GetComponent<Renderer>().transform.Translate(new Vector3(-speed,0,0));
        if(gameObject.name.Contains("Clone")) {Destroy(gameObject,10);}
	}
}
