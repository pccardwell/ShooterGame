using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour {

	public Texture2D Background;
	public Texture2D Loading;
	public Texture2D Jeff_Huggins;
	public Texture2D Patrick_Cardwell;
	public Texture2D Steve_Moskal;
	public Texture2D Aaron_Camm;
	public Texture2D OSU_Logo;
	public Texture2D OSU_CSE_Logo;
	public Texture2D Unity_Logo;
	public Texture2D Spinner_Top_Bottom;
	public Texture2D Spinner_Left_Right;
	public Texture2D Spinner_TR_BL;
	public Texture2D Spinner_TL_BR;

	private Rect JeffRect = new Rect ();
	private Rect PatrickRect = new Rect ();
	private Rect SteveRect = new Rect ();
	private Rect AaronRect = new Rect ();
	private Rect OSURect = new Rect ();
	private Rect OSUCSERect = new Rect ();
	private Rect UnityRect = new Rect ();

	private bool position2 = false;
	private bool position3 = false;
	private bool position4 = false;
	private bool position6 = false;
	private bool position8 = false;
	private bool position9 = false;
	private bool position10 = false;

	private int spinnerCounter = 0;
	private int spinnerTimeMod = 10;

	IEnumerator Start() {
		AsyncOperation async = Application.LoadLevelAsync (1);
		yield return async;
		HideLoadingScreen();
	}

	void OnGUI () {
		DrawBackground ();
		DrawLoadingText ();
		DrawSpinner ();
		if (Time.fixedTime % 1f == 0) {
			int selector = Random.Range (0, 5);
			if (selector < 4) {
				DrawSomething ();
			} else {
				RemoveSomething ();
			}
		}
		if (JeffRect != new Rect ()) {
			DrawJeff();
		}
		if (PatrickRect != new Rect ()) {
			DrawPatrick();
		}
		if (SteveRect != new Rect ()) {
			DrawSteve();
		}
		if (AaronRect != new Rect ()) {
			DrawAaron();
		}
		if (OSURect != new Rect ()) {
			DrawOSULogo();
		}
		if (OSUCSERect != new Rect ()) {
			DrawOSUCSELogo();
		}
		if (UnityRect != new Rect ()) {
			DrawUnityLogo();
		}
	}

	private void DrawSomething () {
		int selector = Random.Range (0, 7);
		switch (selector) {
			case 0: 
				DrawJeff();
				break;
			case 1: 
				DrawPatrick();
				break;
			case 2: 
				DrawSteve();
				break;
			case 3: 
				DrawAaron();
				break;
			case 4: 
				DrawOSULogo();
				break;
			case 5: 
				DrawOSUCSELogo();
				break;
			case 6: 
				DrawUnityLogo();
				break;
		}
	}

	private void RemoveSomething () {
		int selector = Random.Range (0, 7);
		switch (selector) {
		case 0: 
			if (JeffRect.center.x > Screen.width / 2) {
				position2 = false;
			} else {
				position10 = false;
			}
			JeffRect = new Rect ();
			break;
		case 1: 
			if (PatrickRect.center.x > Screen.width / 2) {
				position2 = false;
			} else {
				position10 = false;
			}
			PatrickRect = new Rect ();
			break;
		case 2: 
			if (SteveRect.center.x < Screen.width / 3) {
				position8 = false;
			} else if (SteveRect.center.x > 2 * Screen.width / 3) {
				position4 = false;
			} else {
				position6 = false;
			}
			SteveRect = new Rect ();
			break;
		case 3: 
			if (AaronRect.center.x < Screen.width / 3) {
				position8 = false;
			} else if (AaronRect.center.x > 2 * Screen.width / 3) {
				position4 = false;
			} else {
				position6 = false;
			}
			AaronRect = new Rect ();
			break;
		case 4: 
			if (OSURect.center.x < Screen.width / 3) {
				position8 = false;
			} else if (OSURect.center.x > 2 * Screen.width / 3) {
				position4 = false;
			} else {
				position6 = false;
			}
			OSURect = new Rect ();
			break;
		case 5: 
			if (OSUCSERect.center.x > Screen.width / 2) {
				position3 = false;
			} else {
				position9 = false;
			}
			OSUCSERect = new Rect ();
			break;
		case 6: 
			if (UnityRect.center.x > Screen.width / 2) {
				position3 = false;
			} else {
				position9 = false;
			}
			UnityRect = new Rect ();
			break;
		}
	}

	private void DrawBackground () {
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), Background);
	}

	private void DrawLoadingText () {
		GUI.DrawTexture (new Rect(Screen.width / 2 - 128, 60, 256, 64), Loading);
	}

	private void DrawSpinner () {
		if (spinnerCounter < 0 * spinnerTimeMod) {
			GUI.DrawTexture (new Rect (Screen.width / 2 - 8, 149, 16, 32), Spinner_Top_Bottom); //Top
			GUI.DrawTexture (new Rect (Screen.width / 2 + 4, 156, 32, 32), Spinner_TR_BL); //TR
		} else if (spinnerCounter < 1 * spinnerTimeMod) {
			GUI.DrawTexture (new Rect (Screen.width / 2 + 4, 156, 32, 32), Spinner_TR_BL); //TR
			GUI.DrawTexture (new Rect (Screen.width / 2 + 10, 183, 32, 16), Spinner_Left_Right); //Right
		} else if (spinnerCounter < 2 * spinnerTimeMod) {
			GUI.DrawTexture (new Rect (Screen.width / 2 + 10, 183, 32, 16), Spinner_Left_Right); //Right		
			GUI.DrawTexture (new Rect (Screen.width / 2 + 4, 195, 32, 32), Spinner_TL_BR); //BR
		} else if (spinnerCounter < 3 * spinnerTimeMod) {		
			GUI.DrawTexture (new Rect (Screen.width / 2 + 4, 195, 32, 32), Spinner_TL_BR); //BR
			GUI.DrawTexture (new Rect (Screen.width / 2 - 8, 201, 16, 32), Spinner_Top_Bottom); //Bottom
		} else if (spinnerCounter < 4 * spinnerTimeMod) {
			GUI.DrawTexture (new Rect (Screen.width / 2 - 8, 201, 16, 32), Spinner_Top_Bottom); //Bottom
			GUI.DrawTexture (new Rect (Screen.width / 2 - 35, 195, 32, 32), Spinner_TR_BL); //BL
		} else if (spinnerCounter < 5 * spinnerTimeMod) {
			GUI.DrawTexture (new Rect (Screen.width / 2 - 35, 195, 32, 32), Spinner_TR_BL); //BL
			GUI.DrawTexture (new Rect (Screen.width / 2 - 42, 183, 32, 16), Spinner_Left_Right); //Left
		} else if (spinnerCounter < 6 * spinnerTimeMod) {
			GUI.DrawTexture (new Rect (Screen.width / 2 - 42, 183, 32, 16), Spinner_Left_Right); //Left
			GUI.DrawTexture (new Rect (Screen.width / 2 - 35, 156, 32, 32), Spinner_TL_BR); //TL
		} else {
			GUI.DrawTexture (new Rect (Screen.width / 2 - 35, 156, 32, 32), Spinner_TL_BR); //TL
			GUI.DrawTexture (new Rect (Screen.width / 2 - 8, 149, 16, 32), Spinner_Top_Bottom); //Top
		}
		spinnerCounter++;
		if (spinnerCounter == 7 * spinnerTimeMod) {
			spinnerCounter = 0;
		}
	}

	private void DrawJeff () {
		if (JeffRect == new Rect ()) {
			JeffRect = GetVertRect (JeffRect);
		}
		GUI.DrawTexture (JeffRect, Jeff_Huggins);
	}

	private void DrawPatrick () {
		if (PatrickRect == new Rect ()) {
			PatrickRect = GetVertRect (PatrickRect);
		}
		GUI.DrawTexture (PatrickRect, Patrick_Cardwell);
	}

	private void DrawSteve () {
		if (SteveRect == new Rect ()) {
			SteveRect = GetSquareRect (SteveRect);
		}
		GUI.DrawTexture (SteveRect, Steve_Moskal);
	}

	private void DrawAaron () {
		if (AaronRect == new Rect ()) {
			AaronRect = GetSquareRect (AaronRect);
		}
		GUI.DrawTexture (AaronRect, Aaron_Camm);
	}

	private void DrawOSULogo () {
		if (OSURect == new Rect ()) {
			OSURect = GetSquareRect (OSURect);
		}
		GUI.DrawTexture (OSURect, OSU_Logo);
	}

	private void DrawOSUCSELogo () {
		if (OSUCSERect == new Rect ()) {
			OSUCSERect = GetHorizRect (OSUCSERect);
		}
		GUI.DrawTexture (OSUCSERect, OSU_CSE_Logo);
	}

	private void DrawUnityLogo () {
		if (UnityRect == new Rect ()) {
			UnityRect = GetHorizRect (UnityRect);
		}
		GUI.DrawTexture (UnityRect, Unity_Logo);;
	}

	private Rect GetVertRect (Rect namedRect) {
		int selector = Random.Range (0, 2);
		if (selector == 0 && !position2) {
			position2 = true;
			return new Rect (Screen.width - 160, 10, 150, 200);
		} else if (!position10) {
			position10 = true;
			return new Rect (10, 10, 150, 200);
		}
		return namedRect;
	}

	private Rect GetHorizRect (Rect namedRect) {
		int selector = Random.Range (0, 2);
		if (selector == 0 && !position3) {
			position3 = true;
			return new Rect(Screen.width - 210, Screen.height / 2 - 32, 200, 64);
		} else if (!position9) {
			position9 = true;
			return new Rect(10, Screen.height / 2 - 32, 200, 64);
		}
		return namedRect;
	}

	private Rect GetSquareRect (Rect namedRect) {
		int selector = Random.Range (0, 3);
		if (selector == 0 && !position4) {
			position4 = true;
			return new Rect(Screen.width - 190, Screen.height - 190, 180, 180);
		} else if (selector == 1 && !position6) {
			position6 = true;
			return new Rect(Screen.width / 2 - 90, Screen.height - 190, 180, 180);
		} else if (!position8) {
			position8 = true;
			return new Rect(10, Screen.height - 190, 180, 180);
		}
		return namedRect;
	}

	public void ShowLoadingScreen () {
		gameObject.SetActive (true);
	}

	public void HideLoadingScreen () {
		gameObject.SetActive (false);
	}
}