using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerList : MonoBehaviour {
	public List<Player> players = new List<Player>();

	// Use this for initialization
	void Start () {
		players.Add (new Player ("Tigger", 0));
		players.Add (new Player ("Snow", 1));
	}
}
