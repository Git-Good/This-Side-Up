using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerList : MonoBehaviour {
	public List<Player> players = new List<Player>();

	// Use this for initialization
	void Start () {
		players.Add (new Player ("Tigger", 0));
		players.Add (new Player ("Snow", 1));
		players.Add (new Player ("Cindy", 2));
		players.Add (new Player ("David", 3));
		players.Add (new Player ("Julie", 4));
        players.Add (new Player ("Sock", 5));
        players.Add (new Player ("Doge", 6));
        players.Add (new Player ("Hamilton", 7));
    }
}
