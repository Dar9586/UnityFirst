using UnityEngine;

public class ArrowControlller : MonoBehaviour {
    public short pos=2;
    public Transform obj;
    short[] poss= {-4,-2,0,2,4};
    public float speedGen=1.0f;
    float lastSpeed=1.0f;
    public float minSwipeDistY;

	public float minSwipeDistX;
		
	private Vector2 startPos;
    private void Start() {
        pos=2;
        InvokeRepeating("InstanceObj",1.0f,speedGen);
        
    }
    void increaseSpeed() {
        LineMove.speed+=0.1f;
    }
    void InstanceObj() {
        Instantiate(obj,new Vector3(14,poss[Random.Range(0,5)%5],0),Quaternion.identity);
    }
    // Update is called once per frame
    void Update () {
        #if UNITY_ANDROID
        if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];
			switch (touch.phase){
				case TouchPhase.Began:startPos = touch.position;break;
				case TouchPhase.Ended:float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
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

		if(Input.GetKeyDown(KeyCode.UpArrow)&&pos<4) {
            goUp();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)&&pos>0) {
            goDown();
        }
        #endif
        if(lastSpeed!=speedGen) {
            CancelInvoke("InstanceObj");
            InvokeRepeating("InstanceObj",0.0f,speedGen);
            lastSpeed=speedGen;
        }
        if(LineMove.speed==0) {CancelInvoke("InstanceObj"); }
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

