using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {
    public float Speed;

    Rigidbody2D body;

	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        body.position += new Vector2(Speed * Time.deltaTime, 0);
	}
}
