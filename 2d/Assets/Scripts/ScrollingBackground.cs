/*
Written by Myopic Games
10/07/22
ScrollingBackground.cs

This script contains the necessary functions for the scrolling background.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// an element of the background that can scroll
[System.Serializable]
public struct ScrollingBackgroundElement {
    public string layerName;
    public Sprite sourceImage;
    public Vector3 position;
    public Vector3 scrollingOffset;
    public Quaternion rotation;
    public Vector3 scale;
    public float count;
    public Color tint;
}

//[ExecuteInEditMode]
public class ScrollingBackground : MonoBehaviour
{
    [Range(0, 1)]
    public float scrollProgress = 0;
    public float progressionrate = 1;
    public ScrollingBackgroundElement[] elementArray;
    public SpriteRenderer spriteTemplate;


    [Header("Background")]
    public int rows = 10;
    public int columns = 16;
    public float tileSize = 1;
    public GameObject tile;
    public Color tint;
    public bool noSpeedAlphaAdjustment = false;
    // Start is called before the first frame update
    void Start()
    {
        //SpriteRenderer[] tempArray = GetComponentsInChildren<SpriteRenderer>();
        //elementArray = new ScrollingBackgroundElement[tempArray.Length];
        for (int i = 0; i < elementArray.Length; i++){

            for (int j = 0; j < elementArray[i].count; j++)
            {
                //SpriteRenderer tmpIndividualPiece = GameObject.Instantiate(spriteTemplate,
                   // elementArray[i].position + j * elementArray[i].scrollingOffset,
                   // elementArray[i].rotation) as SpriteRenderer;
                //tmpIndividualPiece.GetComponent<SpriteRenderer>().color = elementArray[i].tint;
                //tmpIndividualPiece.GetComponent<SpriteRenderer>().sprite = elementArray[i].sourceImage;
                //tmpIndividualPiece.transform.localScale = elementArray[i].scale;
            }
        }
        
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
            scrollProgress += Time.deltaTime * progressionrate;
        scrollProgress %= 1;

    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(tile);
        
        // make pretty color background
        for (int i = 0; i < rows; i++){
            for (int j = 0; j < columns; j++){
                GameObject tile = GameObject.Instantiate(referenceTile, transform);
                tile.transform.position = new Vector2(j * tileSize, i * -tileSize);
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

        transform.position = new Vector2(-(columns * tileSize) / 2 + tileSize / 2, (rows * tileSize) / 2 - tileSize / 2);
    }
}
