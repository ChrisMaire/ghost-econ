using UnityEngine;
using System.Collections;

public class DeskLocation : MonoBehaviour {
    public int Index;

    public string Layer;
    public int LayerInt;

	void Awake() {
        LayerInt = SortingLayer.NameToID(Layer);
	}
}
