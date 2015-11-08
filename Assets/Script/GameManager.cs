using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public Transform Player;
    Vector3 playerStart;

    public bool Running;

    public System.Action RunStarted;
    public System.Action RunEnded;

    public static GameManager instance;

    void Awake() {
        instance = this;
        playerStart = Player.transform.position;
    }
	
	public void StartRun()
    {
        Running = true;

        if(RunStarted != null)
        {
            RunStarted();
        }
    }

    public void EndRun()
    {
        Running = false;

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
