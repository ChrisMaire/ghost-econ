using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    Business business;

	void Awake() {
        business = FindObjectOfType<Business>();
	}
	
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            Vector2 loc = new Vector2();

            if (Input.touchCount > 0)
            {
                loc = Input.GetTouch(0).position;
            } else
            {
                loc = Input.mousePosition;
            }

            loc.x += Random.Range(-5f, 5f);
            loc.y += Random.Range(-5f, 5f);

            business.EarnMoney(business.MoneyPerClick);

            FloatyTextManager.ShowFloatyMoney(business.MoneyPerClick, loc);
        }
	}
}
