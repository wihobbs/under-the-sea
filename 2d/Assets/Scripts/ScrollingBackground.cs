using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

[ExecuteInEditMode]
public class ScrollingBackground : MonoBehaviour
{
    [Range(0, 1)]
    public float scrollprogress = 0;
    public ScrollingBackgroundElement[] elementArray;
    public SpriteRenderer spriteTemplate;

    
    // Start is called before the first frame update
    void Start()
    {
        //SpriteRenderer[] tempArray = GetComponentsInChildren<SpriteRenderer>();
        //elementArray = new ScrollingBackgroundElement[tempArray.Length];
        for (int i = 0; i < elementArray.Length; i++){

            for (int j = 0; j < elementArray[i].count; j++)
            {
                SpriteRenderer tmpIndividualPiece = GameObject.Instantiate(spriteTemplate,
                    elementArray[i].position + j * elementArray[i].scrollingOffset,
                    elementArray[i].rotation) as SpriteRenderer;
                //tmpIndividualPiece.GetComponent<SpriteRenderer>().color = elementArray[i].tint;
                //tmpIndividualPiece.GetComponent<SpriteRenderer>().sprite = elementArray[i].sourceImage;
                //tmpIndividualPiece.transform.localScale = elementArray[i].scale;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
