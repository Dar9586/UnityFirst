using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour {
    public short pos=2;
    public Transform[] obj;
    float lastSpeed=1.0f;
    public static float speedGen=1.0f;
    static public short[] poss= {-4,-2,0,2,4};
    bool stopped=false;
    int lastPos=-1;
    public static bool isControllable=true;
    private void Start() {
        InvokeRepeating("InstanceObj",0.0f,speedGen);
    }
    void increaseSpeed() {
        LineMove.speed+=0.1f;
        if(speedGen>0.1f)speedGen-=0.05f;
    }
    Transform choseTransform() {
        int x=Random.Range(0,100000);
        if(x<50000) {return obj[0]; }//50.000
        else if(x<65000) {return obj[1]; }//15.000
        else if(x<70000) {return obj[2]; }//5.000
        else if(x<75000) {return obj[3]; }//5.000
        else if(x<80000) {return obj[4]; }//5.000
        else if(x<100000){return obj[5]; }//20.000
        return obj[0];
    }
    int chosePos() {
         int x;
        do {
            x=Random.Range(0,5);
        }while(x==lastPos);
        lastPos=x;
        return x;
    }
    void InstanceObj() {
        Instantiate(choseTransform(),new Vector3(20,poss[chosePos()],0),Quaternion.identity)
            .GetComponent<Renderer>().transform.localScale=new Vector3(Random.Range(0.5f,2f),0.05f,1f);
    }

    // Update is called once per frame
    void Update () {
//#if UNITY_ANDROID
        switch (SwipeManager.swipeDirection) {
            case Swipe.Up:++pos;changePos();SwipeManager.swipeDirection=Swipe.None;break;
            case Swipe.Down:--pos;changePos();SwipeManager.swipeDirection=Swipe.None;break;
            case Swipe.Left:restartGame();SwipeManager.swipeDirection=Swipe.None;break;
            case Swipe.Right:GameObject.Find("locked").GetComponent<Text>().text="";isControllable=true;SwipeManager.swipeDirection=Swipe.None;break;
        }
//#else
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
            ++pos;changePos();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)) {
            --pos;changePos();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            restartGame();
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)) {
            GameObject.Find("locked").GetComponent<Text>().text="";
            isControllable =true;
        }
     //   #endif
        if(lastSpeed!=speedGen) {
            CancelInvoke("InstanceObj");
            InvokeRepeating("InstanceObj",0.0f,speedGen);
            lastSpeed=speedGen;
        }
        if(LineMove.speed==0&&!stopped) {stopGame(); }
	}
    void stopGame() {
        CancelInvoke();
        stopped=true;
    }
    void restartGame() {
        if(LineMove.speed!=0f)return;
        GameObject.Find("locked").GetComponent<Text>().text="";
        float s=0;
        while(s<10) {s+=Time.deltaTime; }
        GameObject.Find("Score").GetComponent<Text>().text="";
        stopped=false;
        gameObject.GetComponent<Renderer>().transform.position=new Vector3(-8f,0,0);
        pos=2;
        
        speedGen=1.0f;
        LineMove.speed=0.1f;
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("deathLine")) {
            if(x.name.Contains("Clone")) {DestroyImmediate(x); }
        }
        LineMove.score=0;
        isControllable=true;
        InvokeRepeating("InstanceObj",0.0f,speedGen);
    }
    void changePos() {
        if(pos==5) {pos=0; }if(pos==-1) {pos=4; }
        if(LineMove.speed!=0&&isControllable) { 
        Vector3 k=gameObject.GetComponent<Renderer>().transform.position;
        gameObject.GetComponent<Renderer>().transform.position=new Vector3(k.x,poss[pos],k.z);
            }
    }
    
}

