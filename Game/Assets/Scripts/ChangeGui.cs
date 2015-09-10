using UnityEngine;
using System.Collections;

public class ChangeGui : MonoBehaviour {

	OverlayController controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GuiController").GetComponent<OverlayController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(int n){
		controller.OpenGuiPanel (n);
	}
}
