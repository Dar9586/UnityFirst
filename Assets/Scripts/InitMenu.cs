using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find("BtnInit").GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
	}
	void TaskOnClick(){
        Debug.Log("fdsfdsffs");
		SceneManager.LoadScene ("Arrow", LoadSceneMode.Single);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
