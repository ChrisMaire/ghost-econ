using UnityEngine;
using System.Collections;

public class HideDuringRun : MonoBehaviour {
    GameManager gameManager;

	void Awake() {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.RunStarted += () => StartRun();
        gameManager.RunEnded += () => EndRun();
    }
	
	void StartRun()
    {
        gameObject.SetActive(false);
    }

    void EndRun()
    {
        gameObject.SetActive(true);
    }
}
