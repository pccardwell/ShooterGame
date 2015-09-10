using UnityEngine;
using System.Collections;

public class DontDestoryScirpt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}

}
