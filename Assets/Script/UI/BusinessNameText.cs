using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BusinessNameText : MonoBehaviour
{
    Business business;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        business = FindObjectOfType<Business>();
        business.NameChanged += m => UpdateText(m);
    }

    void UpdateText(string name)
    {
        text.text = name;
    }
}
