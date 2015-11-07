using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyText : MonoBehaviour {
    Business business;
    Text text;

	void Awake() {
        text = GetComponent<Text>();
        business = FindObjectOfType<Business>();
        business.MoneyChanged += m => UpdateText(m);
	}

    void UpdateText(int money)
    {
        text.text = money+"";
    }
}
