using UnityEngine;

public class ArrowControlller : MonoBehaviour {
    public short pos=2;
    public Transform obj;
    short[] poss= {-4,-2,0,2,4};
    private void Start() {
        pos=2;
        Instantiate(obj,new Vector3(0,poss[Random.Range(0,5)%5],0),Quaternion.identity);
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)&&pos<4) {
            pos++;
            Vector3 k=gameObject.GetComponent<Renderer>().transform.position;
            gameObject.GetComponent<Renderer>().transform.position=new Vector3(k.x,k.y+2,k.z);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)&&pos>0) {
            pos--;
            Vector3 k=gameObject.GetComponent<Renderer>().transform.position;
            gameObject.GetComponent<Renderer>().transform.position=new Vector3(k.x,k.y-2,k.z);
        }
	}
}

