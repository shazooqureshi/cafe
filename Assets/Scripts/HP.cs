using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HP : MonoBehaviour {

	public Text HPText;
	// Use this for initialization
	void Start () {
		HPText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		HPText.text = "HP: " + movement_obstacles.HP.ToString();
	}
}
