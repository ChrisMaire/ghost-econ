using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
    public Menu CorpMenu;
    public Menu CEOMenu;
    public Menu HRMenu;
    public Menu ShopMenu;

    void Awake()
    {
        CorpMenu.Show();
        CEOMenu.Show();
        HRMenu.Show();
        ShopMenu.Show();
    }
    void Start()
    {
        CorpMenu.Hide();
        CEOMenu.Show();
        HRMenu.Hide();
        ShopMenu.Hide();
    }

    public bool MenuOpen()
    {
        if(CEOMenu.gameObject.activeSelf || 
            HRMenu.gameObject.activeSelf ||
            CorpMenu.gameObject.activeSelf || 
            ShopMenu.gameObject.activeSelf)
        {
            return true;
        }
        return false;
    }
}
