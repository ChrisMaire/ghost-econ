using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TickTimeImage : MonoBehaviour {
    Image image;
    Business business;

	void Awake() {
        image = GetComponent<Image>();
        business = FindObjectOfType<Business>();
	}
	
	void Update () {
        image.fillAmount = business.TickPercent;
	}
}
