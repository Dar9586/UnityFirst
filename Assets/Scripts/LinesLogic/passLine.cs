using UnityEngine;

public class passLine : LineMove {
    bool block=false;
	private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name=="Triangle") { 
            block=true;
            //gameObject.GetComponent<SpriteRenderer>().color=new Color(255,255,0);
            Destroy(gameObject);
        }
    }
    private void OnDestroy() {
        GameObject.Find("locked").GetComponent<UnityEngine.UI.Text>().text=block?"":"Locked";
        ArrowController.isControllable=block;
    }
}
