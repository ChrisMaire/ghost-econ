using UnityEngine;
using System.Collections;

public class TilingBackground : MonoBehaviour {
    public float Offset;
    public SpriteRenderer sprite;
    Transform player;

    public Transform[] Tiles;
    TileGenerator[] Generators;

    Vector3[] StartPositions;
    
    float width;

    public Color[] Colors;
    public Color lastColor;
    public Color CurrentColor;
    public Color TargetColor;
    public float ColorChangeSpeed;

    void Awake() {
        player = FindObjectOfType<PlayerController>().transform;

        TargetColor = Colors[Random.Range(0, Colors.Length)];
        CurrentColor = Colors[Random.Range(0, Colors.Length)];
        lastColor = Colors[Random.Range(0, Colors.Length)];

        Generators = new TileGenerator[Tiles.Length];
        StartPositions = new Vector3[Tiles.Length];
        for(int i = 0; i < Tiles.Length; i++)
        {
            Generators[i] = Tiles[i].GetComponent<TileGenerator>();
            StartPositions[i] = Tiles[i].position;

            Generators[i].Generate(CurrentColor);
            Generators[i].ClearObject();
        }

        width = sprite.bounds.size.x;

        FindObjectOfType<GameManager>().RunEnded += () =>
        {
            for (int i = 0; i < Tiles.Length; i++)
            {
                Tiles[i].position = StartPositions[i];
                Generators[i].Generate(CurrentColor);
                Generators[i].ClearObject();
            }
        };
	}
	
	void Update () {
        if(!GameManager.instance.Running)
        {
            return;
        }
	    for(int i = 0; i < Tiles.Length; i++)
        {
            if(Tiles[i].position.x < player.position.x - width)
            {
                Tiles[i].position = new Vector3(Tiles[i].position.x + (width * Tiles.Length), Tiles[i].position.y, Tiles[i].position.z);

                CurrentColor = Color.Lerp(CurrentColor, TargetColor, Time.deltaTime * ColorChangeSpeed);
                if (Mathf.Abs(CurrentColor.r - TargetColor.r) < 0.1f &&
                    Mathf.Abs(CurrentColor.g - TargetColor.g) < 0.1f &&
                    Mathf.Abs(CurrentColor.b - TargetColor.b) < 0.1f)
                {
                    TargetColor = Colors[Random.Range(0, Colors.Length)];
                }

                Generators[i].Generate(CurrentColor);
            }
        }
	}
}
