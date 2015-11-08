using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatyTextManager : MonoBehaviour {
    public GameObject FloatyTextPrefab;
    static GameObject floatyTextPrefab;
    public GameObject FloatyTextMoneyPrefab;
    static GameObject floatyTextMoneyPrefab;

    static Transform thisTransform;

    void Awake()
    {
        thisTransform = transform;
        floatyTextMoneyPrefab = FloatyTextMoneyPrefab;
        floatyTextPrefab = FloatyTextPrefab;
    }

    public static void ShowFloatyText(string text, Vector2 ScreenLocation) {
        Show(floatyTextPrefab, text, ScreenLocation);
    }

    public static void ShowFloatyMoney(int money, Vector2 ScreenLocation)
    {
        Show(floatyTextMoneyPrefab, money+"", ScreenLocation);
    }

    public static void Show(GameObject g, string t, Vector2 loc)
    {
        GameObject newText = Instantiate(g) as GameObject;
        newText.transform.SetParent(thisTransform, false);
        newText.GetComponent<FloatyText>().Init(loc, t);
    }
}
