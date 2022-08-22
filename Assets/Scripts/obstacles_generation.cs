using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class obstacles_generation : MonoBehaviour {

//	public List<GameObject> prefabList = new List<GameObject>();
//		public GameObject[] _myPrefabs;
//	public List<GameObject> debrisPrefabs;

	public int rand;
	public static int number = 1;
	public Object high_obstacle;
	public Object low_obstacle;
	public Object tall_obstacle;
	float x;
	float z;
	float prevx;
	float prevz;
	int prevrand;
	public static float secs = 4.0f;

	void Start () {
		high_obstacle = Resources.Load ("high_obstacle");
		low_obstacle = Resources.Load ("low_obstacle");
		tall_obstacle = Resources.Load ("tall_obstacle");

//		Object prefab = AssetDatabase.LoadAssetAtPath("tall_obstacle.prefab", typeof(GameObject));
//		GameObject clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
//		// Modify the clone to your heart's content
//		clone.transform.position = Vector3.one;
//		_myPrefabs = new GameObject[3] { as GameObject,
			//			Resources.Load("prefabs/low_obstacle") as GameObject, Resources.Load("prefabs/tall_obstacle") as GameObject}; 
			//		int prefabIndex = UnityEngine.Random.Range (0, 3);
			//		GameObject x = Resources.Load(_myPrefabs[0]);
//					Instantiate (_myPrefabs[Random.Range(0,_myPrefabs.Length)]) as GameObject;

			InvokeRepeating("generate", 0, secs);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void generate() {
		
		if(general_script.game_started) {
			int count = 0;
			if (general_script.pause || movement_obstacles.gameover) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
				while(count < number) {
					while (prevrand == rand) {
						rand = Random.Range (0, 3);
					}
					Debug.Log (rand);
					while(x > prevx - 1 && x < prevx + 1 && x == prevx) {
						x = Random.Range (-2.023f, 2.2f);
					}
					while (z > prevz - 1 && z < prevz + 1 && z == prevz) {
						z = Random.Range (2.0f, 4.0f);
					}
					if (rand == 0) {
						Instantiate (high_obstacle, new Vector3 (x, 0.75f, z), Quaternion.identity);
					} else if (rand == 1) {
						Instantiate (low_obstacle, new Vector3 (x, 0.25f, z), Quaternion.identity);
					} else if (rand == 2) {
						Instantiate (tall_obstacle, new Vector3 (x, 1.03f, z), Quaternion.identity);
					}
					prevrand = rand;
					prevx = x;
					prevz = z;
					count++;
				}
			}
		}

	}
}
