using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ScrollingBackground : MonoBehaviour
{
    [Header("Background")]
    public int rows = 10;
    public int columns = 16;
    public float tileSize = 1;
    public GameObject tile;
    [ColorUsageAttribute(true, true)]
    public Color tint;
    public bool noSpeedAlphaAdjustment = false;
    public bool setInitPosition = true;
    // Start is called before the first frame update
    void Start()
    {     
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(tile);

        for (int i = 0; i < rows; i++){
            for (int j = 0; j < columns; j++){
                GameObject tile = GameObject.Instantiate(referenceTile, transform);
                tile.transform.localPosition = new Vector2(j * tileSize, i * -tileSize);
                Obstacle t = tile.GetComponent<Obstacle>();
                Color spawnColor = new Vector4(
                    -0.6f * ((float)i / rows) + 0.9f,
                    -0.7f * ((float)i / rows) + 1f,
                    -0.6f * ((float)i / rows) + 0.9f,
                    (t.randomSpeed && !noSpeedAlphaAdjustment) ?
                        0.5f + 0.5f * (t.speed - t.speedRange.x) / (t.speedRange.y - t.speedRange.x) :
                        1f) * tint;
                tile.GetComponent<SpriteRenderer>().color = spawnColor;
            }
        }

        Destroy(referenceTile);

        if (setInitPosition)
            transform.position = new Vector2(-(columns * tileSize) / 2 + tileSize / 2, (rows * tileSize) / 2 - tileSize / 2);
    }
}
