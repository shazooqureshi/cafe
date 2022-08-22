using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class general_script : MonoBehaviour {
	public static bool game_started = false;

	GameObject[] startMenuObjects;
	GameObject[] settingsMenuObjects;
	public static bool ismute = false;
	AudioSource gameaudio;
	AudioSource menuaudio;
	GameObject[] howToPlay;
	GameObject[] credits;
	GameObject[] mutes;
	GameObject[] unmutes;
	GameObject[] game_overs;
	GameObject[] pauses;
	public static bool pause = false;
	float cure = 0.0f;
	// Use this for initialization
	void Start () {
		startMenuObjects = GameObject.FindGameObjectsWithTag ("start_menu");
		settingsMenuObjects = GameObject.FindGameObjectsWithTag ("settings_menu");
		howToPlay = GameObject.FindGameObjectsWithTag ("how_to_play");
		credits = GameObject.FindGameObjectsWithTag ("credits");
		mutes = GameObject.FindGameObjectsWithTag ("mute");
		unmutes = GameObject.FindGameObjectsWithTag ("unmute");
		game_overs = GameObject.FindGameObjectsWithTag ("game_over");
		pauses = GameObject.FindGameObjectsWithTag ("pause");
		gameaudio = GameObject.Find ("game_audio").GetComponent<AudioSource> ();
		menuaudio = GameObject.Find ("menu_audio").GetComponent<AudioSource> ();
		hidePause ();
		hideGameOver ();
		menuaudio.Play ();
		hideHowToPlay ();
		hideCredits ();
		hideunmute ();
		hideSettings ();


		Debug.Log (howToPlay);
	}
	
	// Update is called once per frame
	void Update () {
		if (game_started) {
			hideStartMenu ();
		} else {
			showStartMenu ();
		}
		if (movement_obstacles.gameover) {
			showGameOver ();
			Time.timeScale = 0;
		}
		if(Input.GetKeyDown (KeyCode.Escape)) {
			pause = !pause;

		}

		if(pause) {
			cure = Time.timeScale;
			Time.timeScale = 0;
			showPause ();
		} else {
			Time.timeScale = 1;
			hidePause ();
		}

	}

	public void startGame() {
		game_started = true;
		gameaudio.Play ();
		menuaudio.mute = true;

	}

	public void showStartMenu () {
		hideSettings ();
		foreach (GameObject g in startMenuObjects) {
			g.SetActive (true);
		}
	}

	public void hideStartMenu () {
		foreach (GameObject g in startMenuObjects) {
			g.SetActive (false);
		}
	}

	public void showSettings () {
		hideStartMenu ();
		foreach (GameObject g in settingsMenuObjects) {
			g.SetActive (true);
		}
	}

	public void hideSettings () {
		foreach (GameObject g in settingsMenuObjects) {
			g.SetActive (false);
		}
	}

	public void mute () {
		gameaudio.mute = true;
		menuaudio.mute = true;
		hidemute ();
		showunmute ();
	}

	public void unmute () {
		if (game_started) {
			gameaudio.mute = false;
		} else {
			menuaudio.mute = false;
		}

		hideunmute ();
		showmute ();
	}

	public void showHowToPlay() {
		foreach (GameObject g in howToPlay) {
			g.SetActive (true);
		}
	}
	public void hideHowToPlay() {
		foreach (GameObject g in howToPlay) {
			g.SetActive (false);
		}
	}

	public void showCredits() {
		foreach (GameObject g in credits) {
			g.SetActive (true);
		}
	}

	public void hideCredits() {
		foreach (GameObject g in credits) {
			g.SetActive (false);
		}
	}

	public void showmute() {
		foreach (GameObject g in mutes) {
			g.SetActive (true);
		}
	}

	public void hidemute() {
		foreach (GameObject g in mutes) {
			g.SetActive (false);
		}
	}

	public void showunmute() {
		foreach (GameObject g in unmutes) {
			g.SetActive (true);
		}
	}

	public void hideunmute() {
		foreach (GameObject g in unmutes) {
			g.SetActive (false);
		}
	}

	public void showGameOver() {
		foreach (GameObject g in game_overs) {
			g.SetActive (true);
		}
	}

	public void hideGameOver() {
		foreach (GameObject g in game_overs) {
			g.SetActive (false);
		}
	}

	public void showPause() {
		foreach (GameObject g in pauses) {
			g.SetActive (true);
		}
	}

	public void hidePause() {
		foreach (GameObject g in pauses) {
			g.SetActive (false);
		}
	}
//
//	public void restart() {
//		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
//	}
		
}
