using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroPanel : MonoBehaviour {
    public InputField NameInput;
    public InputField DescInput;

    public GameObject CreateBusinessPanel;
    public GameObject CreateCEOPanel;

    Business business;

	void Awake() {
        business = FindObjectOfType<Business>();
	}
	
	void Update () {
	
	}

    void CreateBusiness()
    {
        business.name = NameInput.text;
        business.Description = DescInput.text;

        CreateBusinessPanel.SetActive(false);
    }

    public void UpdateName(string newName)
    {
        business.name = newName;
    }

    public void UpdateDesc(string newDesc)
    {
        business.Description = newDesc;
    }
}
