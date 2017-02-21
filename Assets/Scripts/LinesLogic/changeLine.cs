using UnityEngine;

public class changeLine : deathLine {
    int pos;
    bool howChange;
    void changePos() {
        pos=pos+(howChange?1:-1);
        if(pos==5) {pos=0; }if(pos==-1) {pos=4; }
        transform.position=new Vector3(transform.position.x,ArrowController.poss[pos],0);
    }
	// Use this for initialization
	void Start () {
        Debug.Log("ciao");
        pos=Random.Range(0,4);
        howChange=Random.Range(0,2)==0;
		InvokeRepeating("changePos",0.0f,Random.Range(1.0f,2.0f));
	}
}
