using UnityEngine;
using System.Collections;

public class SwitchSpriteOnCollision : MonoBehaviour {
    public Sprite sprite;
    public SpriteRenderer spriterenderer;

    void OnCollisionEnter2D(Collision2D c)
    {
        spriterenderer.sprite = sprite;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        spriterenderer.sprite = sprite;
    }
}
