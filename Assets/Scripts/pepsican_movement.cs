using UnityEngine;
using System.Collections;

public class pepsican_movement : MonoBehaviour {
	public Object pepsi_can_1;
	float x;
	float y;
	float z;
	// Use this for initialization
	void Start () {
		pepsi_can_1 = Resources.Load ("pepsi_can");
		InvokeRepeating("generate", 0, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void generate() {
		if (general_script.game_started) {
			if (general_script.pause || movement_obstacles.gameover) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
				x = Random.Range (-2.023f, 2.2f);
				z = Random.Range (2.0f, 4.0f);
				y = Random.Range (0.2f, 1.0f);

				Instantiate (pepsi_can_1, new Vector3 (x, y, z), Quaternion.identity);

			}
		}


	}
}
