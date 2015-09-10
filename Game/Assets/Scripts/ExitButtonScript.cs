using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void onClick(){
		Debug.Log ("Exiting game");
		Application.Quit ();
	}


}
