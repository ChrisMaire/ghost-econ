using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public Transform Player;
    Vector3 playerStart;

    public bool Running;

    public System.Action RunStarted;
    public System.Action RunEnded;

    public static GameManager instance;

    bool water;

    public GameObject landTiles;
    public GameObject waterTiles;

    void Awake() {
        instance = this;
        playerStart = Player.transform.position;
    }
	
	public void StartRun(bool water = false)
    {
        Running = true;
        this.water = water;

        if(water)
        {
            landTiles.SetActive(false);
            waterTiles.SetActive(true);
        }

        if(RunStarted != null)
        {
            RunStarted();
        }
    }

    public void EndRun()
    {
        Running = false;

        landTiles.SetActive(true);
        waterTiles.SetActive(true);

        if (RunEnded != null)
        {
            RunEnded();
        }
    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel(0);
    }
}
