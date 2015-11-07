using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    Business business;
    MenuManager menus;

	void Awake() {
        business = FindObjectOfType<Business>();
        menus = FindObjectOfType<MenuManager>();
	}
	
	void Update () {
	    if(Input.GetButtonDown("Fire1") && !menus.MenuOpen())
        {
            Vector2 loc = new Vector2();

            if (Input.touchCount > 0)
            {
                loc = Input.GetTouch(0).position;
            } else
            {
                loc = Input.mousePosition;
            }

            loc.x += Random.Range(-10f, 10f);
            loc.y += Random.Range(-10f, 10f);

            business.EarnMoney(business.MoneyPerClick);

            FloatyTextManager.ShowFloatyMoney(business.MoneyPerClick, loc);
        }
	}
}
