using UnityEngine;
using System.Collections;

public class FaceCollision : MonoBehaviour {

    CatScript cs;

    void Start()
    {
        cs = GameObject.FindObjectOfType<CatScript>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            cs.SendMessage("Lost");
        }
    }
}