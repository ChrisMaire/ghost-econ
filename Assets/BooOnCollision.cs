using UnityEngine;
using System.Collections;

public class BooOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D c)
    {
        FloatyTextManager.ShowFloatyText("BOO", Camera.main.WorldToScreenPoint(transform.position + (Random.onUnitSphere * 2)));
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        FloatyTextManager.ShowFloatyText("BOO", Camera.main.WorldToScreenPoint(transform.position) + (Random.onUnitSphere * 2));
    }
}
