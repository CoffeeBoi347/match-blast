using UnityEngine;

public class BoardBehaviour : MonoBehaviour
{
    [Header("Array Components")]
    public int rows;
    public int cols;
    public float spacingFactorX;
    public float spacingFactorY;
    public GameObject tileReference; // tile prefab
    public GameObject[,] tileReferences;
    public Gem[] gems;

    [Header("Storing Gems")]
    public Gem[,] gemReferences;

    public GameObject gemsStoreObj;

    private void Start()
    {
        gemReferences = new Gem[rows, cols];
        tileReferences = new GameObject[rows, cols];
        CreateBoard();
    }

    void CreateBoard()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                Vector2 tilePosition = new Vector2(x + spacingFactorX, y + spacingFactorY);
                GameObject backgroundTile = Instantiate(tileReference, tilePosition, Quaternion.identity, gemsStoreObj.transform);
                tileReferences[x, y] = backgroundTile;

                int gemToUse = Random.Range(0, gems.Length);
                SpawnGem(tilePosition, gems[gemToUse], x, y);
            }
        }
    }

    void SpawnGem(Vector2 gemPosition, Gem gemToSpawn, int x, int y)
    {
        var gemSpawned = Instantiate(gemToSpawn, new Vector3(gemPosition.x, gemPosition.y, 0), Quaternion.identity, gemsStoreObj.transform);
        gemSpawned.SetPosition(x, y);
        gemReferences[x, y] = gemSpawned;
        Vector2Int gemPosVector2Int = Vector2Int.RoundToInt(gemPosition);
        gemSpawned.StoreGems(gemPosVector2Int, this);
    }
}
