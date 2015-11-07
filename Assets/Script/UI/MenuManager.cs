using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    public GameObject CEOMenu;
    public GameObject HRMenu;
    public GameObject ShopMenu;

    public bool MenuOpen()
    {
        if(CEOMenu.activeSelf || HRMenu.activeSelf || ShopMenu.activeSelf)
        {
            return true;
        }
        return false;
    }
}
