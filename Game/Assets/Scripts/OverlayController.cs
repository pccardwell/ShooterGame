using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverlayController : MonoBehaviour {


	public enum GuiPanel{
		None,
		Main,
		Credit,
		Options
	}

	public float soundVolume { get; set; }
	public float musicVolume { get; set; }
	public GameObject MainPanel;
	public GameObject OptionsPanel;
	public GameObject CreditPanel;

	GameObject currentPanel;


	

	// Use this for initialization
	void Start () {

		currentPanel = MainPanel;
		MainPanel.SetActive(true);

	
	}

	public void OpenGuiPanel(GuiPanel panel){

		currentPanel.SetActive (false);
		switch (panel) {
		case GuiPanel.None:
			currentPanel = null;
			break;
		case GuiPanel.Main:
			currentPanel = MainPanel;
			break;
		case GuiPanel.Credit:
			currentPanel = CreditPanel;
			break;
		case GuiPanel.Options:
			currentPanel = OptionsPanel;
			break;
		}
		if (currentPanel != null)
			currentPanel.SetActive(true);
	}


	public void OpenGuiPanel(int n){
		this.OpenGuiPanel ((GuiPanel)n);

	}



	// Update is called once per frame
	void Update () {

	}

	void Awake(){
		DontDestroyOnLoad (this.gameObject);

	}
	
}
