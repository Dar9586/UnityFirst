using UnityEngine;

public class bonusLine : LineMove {
	private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name=="Triangle") { 
        score+=5;
            Destroy(gameObject);
        }
    }
}

