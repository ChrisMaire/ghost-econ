using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyButton : MonoBehaviour {
    Button button;
    Business business;
    public GameObject deskObj;
    Desk d;

    void Awake()
    {
        button = GetComponent<Button>();
        business = FindObjectOfType<Business>();
        d = deskObj.GetComponent<Desk>();

        business.MoneyChanged += m => UpdateRow(m);

        UpdateRow(business.Money);
    }

    void UpdateRow(int money)
    {
        if (money >= d.BaseCost)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
