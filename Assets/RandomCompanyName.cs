using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomCompanyName : MonoBehaviour {
    public string[] Field1;
    public string[] Field2;

    InputField input;

    void Awake() {
        input = GetComponent<InputField>();
        input.text = Field1[Random.Range(0, Field1.Length)] + " " + Field2[Random.Range(0, Field2.Length)];    
	}
}
