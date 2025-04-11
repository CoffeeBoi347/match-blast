using UnityEngine;

public class GemFinder : MonoBehaviour
{
    public int rows;
    public int columns;
    public BoardBehaviour board;
    private void Start()
    {
        board = FindObjectOfType<BoardBehaviour>();

        rows = board.rows;
        columns = board.cols;
    }
    private void Update()
    {
        for (int x = 0; x < rows; x++)
        {
            for(int y = 0; y < columns; y++)
            {
                Gem gem1 = board.gemReferences[x, y];
                Gem gem2 = board.gemReferences[x + 1, y];
                Gem gem3 = board.gemReferences[x + 2, y];

                if(gem1 != null && gem2 != null && gem3 != null)
                {
                    if(gemType(gem1, gem2) && gemType(gem2, gem3))
                    {
                        Debug.Log("IT IS A HORIZONTAL MATCH!");
                    }
                }

            }
        }

        for (int y = 0; y < columns; y++)
        {
            for (int x = 0; x < rows; x++)
            {
                Gem gem1 = board.gemReferences[x, y];
                Gem gem2 = board.gemReferences[x + 1, y];
                Gem gem3 = board.gemReferences[x + 2, y];

                if (gem1 != null && gem2 != null && gem3 != null)
                {
                    if (gemType(gem1, gem2) && gemType(gem2, gem3))
                    {
                        Debug.Log("IT IS A VERTICAL MATCH!");
                    }
                }

            }
        }
    }

    bool gemType(Gem gemA, Gem gemB)
    {
        return gemA.GetComponent<GemType>().typeGem == gemB.GetComponent<GemType>().typeGem;
    }
}
