using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player{
	public string catName;
	public int catID;
	public GameObject catIcon;

	public Player (string name, int ID){
		catName = name;
		catID = ID;
		catIcon = Resources.Load<GameObject> ("Characters/Cat Selector/" + name);
	}
}
