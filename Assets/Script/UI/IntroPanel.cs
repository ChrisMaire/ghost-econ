using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroPanel : Menu {
    public InputField NameInput;
    public InputField DescInput;

    public GameObject CreateBusinessPanel;
    public GameObject CreateCEOPanel;

    Business business;

	void Awake() {
        business = FindObjectOfType<Business>();
	}

    void Start()
    {
        if(PlayerPrefs.HasKey("businessname"))
        {
            Hide();
        }
    }
	
	void Update () {
	
	}

    public void CreateBusiness()
    {
        UpdateName(NameInput.text);
        UpdateDesc(DescInput.text);

        Hide();
    }

    public void UpdateName(string newName)
    {
        if(string.IsNullOrEmpty(newName))
        {
            return;
        }
        business.SetName(newName);
    }

    public void UpdateDesc(string newDesc)
    {
        if (string.IsNullOrEmpty(newDesc))
        {
            return;
        }
        business.SetDesc(newDesc);
    }
}
