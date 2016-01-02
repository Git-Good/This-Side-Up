using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SpawnSelectedChar ();
	}
	
	// Update is called once per frame
	public void SpawnSelectedChar () {
		Instantiate (Resources.Load ("Characters/" + PlayerPrefs.GetString ("Player")), transform.position, Quaternion.identity);
	}
}
