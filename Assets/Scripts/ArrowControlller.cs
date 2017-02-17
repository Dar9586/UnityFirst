using UnityEngine;
using UnityEngine.UI;

public class ArrowControlller : MonoBehaviour {
    public short pos=2;
    public Transform obj;
    float lastSpeed=1.0f;
    public float speedGen=1.0f;
    short[] poss= {-4,-2,0,2,4};
    public float minSwipeDistY=25;
	public float minSwipeDistX=25;
    bool stopped=false;
	private Vector2 startPos;
    private void Start() {
        InvokeRepeating("InstanceObj",0.0f,speedGen);
        InvokeRepeating("increaseSpeed",0.0f,0.7f);
    }
    void increaseSpeed() {
        LineMove.speed+=0.1f;
        if(speedGen>0.1f)speedGen-=0.05f;
    }
    void InstanceObj() {
        Instantiate(obj,new Vector3(14,poss[Random.Range(0,5)%5],0),Quaternion.identity);
    }
    // Update is called once per frame
    void Update () {
#if UNITY_ANDROID
        if (Input.touchCount > 0) {
            restartGame();
			Touch touch = Input.touches[0];
			switch (touch.phase){
				case TouchPhase.Began:startPos = touch.position;break;
				case TouchPhase.Ended:float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    if(swipeDistVertical<10){restartGame();}
        if (swipeDistVertical > minSwipeDistY){
						float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
						if (swipeValue > 0){goUp();}
						else if (swipeValue < 0){goDown(); }
					}
					float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
					if (swipeDistHorizontal > minSwipeDistX){
						
						float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
						
						if (swipeValue > 0){ }//right
                        else if (swipeValue < 0){ }//left
					}break;
			}
		}
#else

		if(Input.GetKeyDown(KeyCode.UpArrow)&&pos<4&&LineMove.speed!=0) {
            goUp();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)&&pos>0&&LineMove.speed!=0) {
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
        GameObject.Find("Score").GetComponent<Text>().text="";
        stopped=false;
        gameObject.GetComponent<Renderer>().transform.position=new Vector3(-7f,0,0);
        pos=2;
        speedGen=1.0f;
        LineMove.speed=0.1f;
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("deathLine")) {
            if(x.name.Contains("Clone")) {DestroyImmediate(x); }
        }
        LineMove.score=0;
        InvokeRepeating("InstanceObj",0.0f,speedGen);
        InvokeRepeating("increaseSpeed",0.0f,0.7f);
        
    }
    void goUp() {
        pos++;
        Vector3 k=gameObject.GetComponent<Renderer>().transform.position;
        gameObject.GetComponent<Renderer>().transform.Translate(new Vector3(-2,0,0));
    }
    void goDown() {
        pos--;
        Vector3 k=gameObject.GetComponent<Renderer>().transform.position;
        gameObject.GetComponent<Renderer>().transform.Translate(new Vector3(2,0,0));
    }
}

