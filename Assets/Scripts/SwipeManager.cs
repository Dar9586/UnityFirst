using UnityEngine;
 
public enum Swipe { None, Up, Down, Left, Right };
 
public class SwipeManager : MonoBehaviour
{
    public float minSwipeLength = 50f;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    bool canMove=true;
 
    public static Swipe swipeDirection;
 
    void Update ()
    {
        DetectSwipe();
    }
    void executeCheck() {
                // Swipe up
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    swipeDirection = Swipe.Up;canMove=false;
                // Swipe down
                } else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    swipeDirection = Swipe.Down;canMove=false;
                // Swipe left
                } else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                    swipeDirection = Swipe.Left;canMove=false;
                // Swipe right
                } else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                    swipeDirection = Swipe.Right;canMove=false;
                }
    }
    public void DetectSwipe ()
    {
        if (Input.touches.Length > 0) {
             Touch t = Input.GetTouch(0);
 
             if (t.phase == TouchPhase.Began) {
                 firstPressPos = new Vector2(t.position.x, t.position.y);
             }
             
             if (t.phase == TouchPhase.Moved&&canMove) {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
           
                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength) {
                    swipeDirection = Swipe.None;
                    return;
                }
                currentSwipe.Normalize();
                executeCheck();
                
             }
             else if(t.phase == TouchPhase.Ended) {
                if(canMove)executeCheck();
                canMove=true;
            }
        }
        else {
            swipeDirection = Swipe.None;
        }
    }
}
 