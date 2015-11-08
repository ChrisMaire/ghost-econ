using UnityEngine;
using System.Collections;

public class HideUntilXDollars : MonoBehaviour {
    public int X;
    public bool HideDuringRun = true;

    Business business;

    void Awake()
    {
        business = FindObjectOfType<Business>();
        business.MoneyChanged += UpdateText;

        gameObject.SetActive(false);

        UpdateText(business.Money);

        GameManager.instance.RunStarted += () => Hide();
        GameManager.instance.RunEnded += () => Show();
    }

    void UpdateText(int money)
    {
        if (money >= X)
        {
            gameObject.SetActive(true);
            business.MoneyChanged -= UpdateText;
        }
    }

    void Show()
    {
        if (business.Money >= X)
        {
            gameObject.SetActive(true);
        }
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
