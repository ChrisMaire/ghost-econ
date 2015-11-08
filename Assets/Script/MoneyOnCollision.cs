using UnityEngine;
using System.Collections;

public class MoneyOnCollision : MonoBehaviour {
    public int Amount;

    Business business;

	void Awake() {
        business = FindObjectOfType<Business>();
	}
	
	void OnCollisionEnter2D(Collision2D c)
    {
        DoCollide();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        DoCollide();
    }

    void DoCollide()
    {
        business.EarnMoney(Amount);
        FloatyTextManager.ShowFloatyMoney(Amount, Camera.main.WorldToScreenPoint(transform.position));
        Destroy(this);
    }
}
