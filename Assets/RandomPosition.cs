using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {
    public float Distance = 8f;

	void Start () {
        Vector3 newpos = transform.position + (Random.onUnitSphere * Distance);
        transform.position = transform.position + newpos;
	}
}
