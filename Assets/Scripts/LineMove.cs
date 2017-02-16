using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineMove : MonoBehaviour {
    public static float speed=0.1f;
    static uint score=0;
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject.Find("Score").GetComponent<Text>().text="Punteggio: "+score.ToString();
        speed=0;
        
    }
    // Update is called once per frame
    void Update () {
        gameObject.GetComponent<Renderer>().transform.Translate(new Vector3(-speed,0,0));
        
	}
    private void OnDestroy() {
        score++;
    }
    private void OnBecameInvisible() {
        if(gameObject.name.Contains("Clone")) {Destroy(gameObject);}
    }
}
