using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BusinessDescText : MonoBehaviour
{
    Business business;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        business = FindObjectOfType<Business>();
        business.DescChanged += m => UpdateText(m);
    }

    void UpdateText(string name)
    {
        text.text = name;
    }
}
