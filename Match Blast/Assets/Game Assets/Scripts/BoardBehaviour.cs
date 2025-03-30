using System.Collections.Generic;
using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{
    [Header("Array Components")]

    public int rows;
    public int cols;
    public float spacingFactorX;
    public float spacingFactorY;    
    public GameObject tileReference;
    public GameObject[,] tileReferences;
    public GameObject[] fruitObjs;
    public List<GameObject> tilePositions = new List<GameObject>();

    private void Start()
    {
        tileReferences = new GameObject[rows, cols];
        CreateBoard();
    }

    void CreateBoard()
    {
        for(int x = 0; x < rows; x++)
        {
            for(int y = 0; y < cols; y++)
            {
                Vector2 tilePosition = new Vector2 (x + spacingFactorX, y + spacingFactorY); // stores the tile position - x and y position both. 
                GameObject backgroundTile = Instantiate(tileReference, tilePosition, Quaternion.identity, transform);
                GameObject objectTile = fruitObjs[Random.Range(0, fruitObjs.Length)];
                GameObject fruitTile = Instantiate(objectTile, backgroundTile.transform.position, Quaternion.identity, backgroundTile.transform);
                tileReferences[x,y] = backgroundTile;
                tilePositions.Add(fruitTile);
            }
        }
    }
}