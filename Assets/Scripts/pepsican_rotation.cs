using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pepsican_rotation : MonoBehaviour {
	public int rand;
	public Object pepsi_can_1;
	float x;
	float y;
	float z;
	float prevx;
	float prevy;
	float prevz;
	int prevrand;
	public static int score = 0;
	public static float speed = -0.015f;
	// Use this for initialization
	void Start () {
		
		pepsi_can_1 = Resources.Load ("pepsi_can");
//		InvokeRepeating("generate", 0, 4);
	}
	
	// Update is called once per frame
	void Update () {
		if(general_script.game_started) {
			if(general_script.pause || movement_obstacles.gameover) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
				float offset =  speed;
				transform.Translate (new Vector3 (0, 0, offset));
				transform.Rotate (new Vector3 (0, 0, 1));
			}
		}


	}

	void generate() {


			x = Random.Range (-2.023f, 2.2f);
			z = Random.Range (2.0f, 4.0f);
			y = Random.Range (0.2f, 1.0f);

		Instantiate (pepsi_can_1, new Vector3 (x, y, z), Quaternion.identity);



	}

	void OnTriggerEnter(Collider c) {
//		c = GetComponent<Collider>();
		if (c.tag == "player") {
			Debug.Log ("Working");
		
			score = score + 10;
			Debug.Log (score);
			if (score % 50 == 0 && score != 0) {
			
				speed -= 0.015f;
				infinite_wall.speed += 0.1f;
				infinite_wall_2.speed -= 0.1f;
				movement_obstacles.speed -= 0.015f;
				infinite_world.speed -= 0.1f;
				obstacles_generation.number += 1;
				obstacles_generation.secs -= 0.5f;
				Debug.Log (speed);
			}
			Destroy (this.gameObject);
		}
	}
		
}
