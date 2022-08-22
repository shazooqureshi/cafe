using UnityEngine;
using System.Collections;

public class infinite_wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public static float speed = 0.1f;
	void Update () {
//		if(pepsican_rotation.score % 50 == 0 && pepsican_rotation.score != 0) {
//			speed += 0.1f;
//		}
		if(general_script.game_started) {
			float offset = Time.time * speed;
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (offset, 0);
		}
	}
}
