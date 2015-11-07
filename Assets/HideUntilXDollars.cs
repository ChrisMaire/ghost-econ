using UnityEngine;
using System.Collections;

public class HideUntilXDollars : MonoBehaviour {
    public int X;

    Business business;

    void Awake()
    {
        business = FindObjectOfType<Business>();
        business.MoneyChanged += UpdateText;

        gameObject.SetActive(false);

        UpdateText(business.Money);
    }

    void UpdateText(int money)
    {
        if (money >= X)
        {
            gameObject.SetActive(true);
            business.MoneyChanged -= UpdateText;
            Destroy(this);
        }
    }
}
