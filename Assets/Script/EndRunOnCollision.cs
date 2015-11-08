using UnityEngine;
using System.Collections;

public class EndRunOnCollision : MonoBehaviour {
    GameManager gameManager;

	void Awake() {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	void OnCollisionEnter2D(Collision2D c)
    {
        gameManager.EndRun();
    }
}
