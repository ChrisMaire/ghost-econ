using UnityEngine;
using System.Collections;

public class MoneyOnCollision : MonoBehaviour {
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
        business.EarnMoney(Business.instance.MoneyPerScare);
        FloatyTextManager.ShowFloatyMoney(Business.instance.MoneyPerScare, Camera.main.WorldToScreenPoint(transform.position));
        Destroy(this);
    }
}
