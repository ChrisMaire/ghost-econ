using UnityEngine;
using System.Collections;

//this class is a shitty hack for not having good spawning logic :)
public class MoveOnSpawn : MonoBehaviour {
    public Vector3 Offset;

	void Awake () {
        transform.position = transform.position + Offset;
	}
}
