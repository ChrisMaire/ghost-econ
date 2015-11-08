using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour {
    public Sprite[] RandomBGSprites;
    public GameObject[] RandomObject;

    public SpriteRenderer BGSprite;
    public Transform ObjectSpawn;

    public SpriteRenderer DistantBG;

    GameObject SpawnedObject;


    GameManager gameManager;

    public void Generate(Color c)
    {
        if(SpawnedObject != null)
        {
            Destroy(SpawnedObject);
        }

        BGSprite.sprite = RandomBGSprites[Random.Range(0, RandomBGSprites.Length)];
        DistantBG.color = c;

        int i = Random.Range(-1, RandomObject.Length);

        if(i >= 0)
        {
            SpawnedObject = Instantiate(RandomObject[i], ObjectSpawn.position, Quaternion.identity) as GameObject;
        }
    }

    public void ClearObject()
    {
        Destroy(SpawnedObject);
    }
}
