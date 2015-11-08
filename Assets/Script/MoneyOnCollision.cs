using UnityEngine;
using System.Collections;

public class MoneyOnCollision : MonoBehaviour {
    public int Amount;

    Business business;

	void Awake() {
        business = FindObjectOfType<Business>();
	}
	
	void OnCollisionEnter2D()
    {
        business.EarnMoney(Amount);
        FloatyTextManager.ShowFloatyMoney(Amount, Camera.main.WorldToScreenPoint(transform.position));
        Destroy(this);
    }
}
