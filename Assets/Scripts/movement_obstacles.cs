using UnityEngine;
using System.Collections;

public class movement_obstacles : MonoBehaviour {
	public static int HP = 3;
	public static bool gameover = false;
	// Use this for initialization
	void Start () {
	
	}
	
	public static float speed = -0.015f;
	// Update is called once per frame
	void Update () {
		if(general_script.game_started) {
	//		float offset =  speed;
	//		if(pepsican_rotation.score % 50 == 0 && pepsican_rotation.score != 0) {
	//			offset -= 0.015f;
	//		}
			if(general_script.pause || movement_obstacles.gameover) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
				transform.Translate (new Vector3 (0, 0, speed));
			}

			//		transform.Translate (Vector3.right * h * speed * Time.deltaTime);
		}
	}
	public bool getGameOver() {
		return gameover;
	}

	void OnTriggerEnter(Collider c) {
//		c = GetComponent<Collider>();
		if (c.tag == "player") {
			HP = HP - 1;
			Debug.Log (HP);
			if (HP < 0) {
				gameover = true;

			}
			Debug.Log (gameover);
			Destroy (this.gameObject);
		}
	}
}
