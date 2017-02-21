using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class deathLine : LineMove {
	private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name=="Triangle") { 
        GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text="Punteggio: "+score.ToString();
            speed=0;}
        
    }
    
    private void OnDestroy() {
        score++;
        if(score%10==0) {
            speed+=0.1f;
        if(ArrowController.speedGen>0.1f)ArrowController.speedGen-=0.05f;
        }
    }
}
