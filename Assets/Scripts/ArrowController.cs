using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour {
    public short pos=2;
    public Transform obj;
    float lastSpeed=1.0f;
    public static float speedGen=1.0f;
    short[] poss= {-4,-2,0,2,4};
    bool stopped=false;
    private void Start() {
        InvokeRepeating("InstanceObj",0.0f,speedGen);
    }
    void increaseSpeed() {
        LineMove.speed+=0.1f;
        if(speedGen>0.1f)speedGen-=0.05f;
    }
    void InstanceObj() {
        Instantiate(obj,new Vector3(14,poss[Random.Range(0,5)%5],0),Quaternion.identity)
            .GetComponent<Renderer>().transform.localScale=new Vector3(Random.Range(0.5f,2f),0.05f,1f);
    }
    // Update is called once per frame
    void Update () {
#if UNITY_ANDROID
        if(SwipeManager.swipeDirection==Swipe.Up)goUp();
        else if(SwipeManager.swipeDirection==Swipe.Down)goDown();
        else if(SwipeManager.swipeDirection==Swipe.Left)restartGame();
        SwipeManager.swipeDirection=Swipe.None;
#else

		if(Input.GetKeyDown(KeyCode.UpArrow)) {
            goUp();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)&&) {
            goDown();
        }
        else if(Input.GetKeyDown(KeyCode.Space)) {
            restartGame();
        }
        
        #endif
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
        InvokeRepeating("InstanceObj",0.0f,speedGen);
    }
    void goUp() {
        if(pos<4&&LineMove.speed!=0) { 
        pos++;
        Vector3 k=gameObject.GetComponent<Renderer>().transform.position;
        gameObject.GetComponent<Renderer>().transform.Translate(new Vector3(-2,0,0));
            }
    }
    void goDown() {
        if(pos>0&&LineMove.speed!=0) { 
        pos--;
        Vector3 k=gameObject.GetComponent<Renderer>().transform.position;
        gameObject.GetComponent<Renderer>().transform.Translate(new Vector3(2,0,0));
            }
    }
}

