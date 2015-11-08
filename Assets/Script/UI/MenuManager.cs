using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    public Menu CEOMenu;
    public Menu HRMenu;
    public Menu ShopMenu;

    void Start()
    {
        CEOMenu.Show();
        HRMenu.Hide();
        ShopMenu.Hide();
    }

    public bool MenuOpen()
    {
        if(CEOMenu.gameObject.activeSelf || 
            HRMenu.gameObject.activeSelf || 
            ShopMenu.gameObject.activeSelf)
        {
            return true;
        }
        return false;
    }
}
