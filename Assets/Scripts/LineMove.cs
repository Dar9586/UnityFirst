using UnityEngine;
using UnityEngine.UI;

public class LineMove : MonoBehaviour {
    public static float speed=0.1f;
    public static uint score=0;
    public float speedMultiplier=1;
    // Use this for initialization
    
    // Update is called once per frame
    void Update () {
        gameObject.GetComponent<Renderer>().transform.Translate(new Vector3(-speed*speedMultiplier,0,0));
	}
    private void OnBecameInvisible() {
        if(gameObject.name.Contains("Clone")) {Destroy(gameObject);}
    }
}
