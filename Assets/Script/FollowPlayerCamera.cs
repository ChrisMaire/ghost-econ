using UnityEngine;
using System.Collections;

public class FollowPlayerCamera : MonoBehaviour {
    public float CameraSpeed = 5.0f;
    public float CameraOffset = 5.0f;

    Vector3 cameraStart;

    Transform thisTransform;
    GameManager gameManager;
    Transform player;

	void Awake() {
        thisTransform = transform;
        cameraStart = thisTransform.position;
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>().transform;
	}
	
	void LateUpdate () {
	    if(gameManager.Running)
        {
            thisTransform.position = new Vector3(player.position.x + CameraOffset, cameraStart.y, cameraStart.z);//Vector3.Lerp(thisTransform.position, new Vector3(player.position.x + CameraOffset, cameraStart.y, cameraStart.z), CameraSpeed * Time.deltaTime);
        } else
        {
            thisTransform.position = cameraStart;
        }
	}
}
