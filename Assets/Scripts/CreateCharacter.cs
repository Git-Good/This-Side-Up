using UnityEngine;
using System.Collections;

public class CreateCharacter : MonoBehaviour {

    // Cat Colour 1
	void OnTriggerEnter2D(Collider2D colour1)
    {
        if (colour1.gameObject.tag == "CreateCat")
        {
            colour1.gameObject.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
        }
    }

    // Cat Colour 2

    // Cat Eye Colour

    // Cat Pattern Colour
}
