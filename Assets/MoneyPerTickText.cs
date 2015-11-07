using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyPerTickText : MonoBehaviour
{
    Business business;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        business = FindObjectOfType<Business>();
        business.MoneyPerTickChanged += m => UpdateText(m);
    }

    void UpdateText(int money)
    {
        text.text = money + "";
    }
}
