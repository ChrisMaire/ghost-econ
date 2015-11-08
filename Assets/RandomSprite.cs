using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {
    public Sprite[] Sprites;
    SpriteRenderer sprite;

	void Awake() {
        sprite.sprite = Sprites[Random.Range(0, Sprites.Length)];
	}
}
