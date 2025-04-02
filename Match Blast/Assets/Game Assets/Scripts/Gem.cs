using UnityEngine;

public class Gem : MonoBehaviour
{
    [Header("Grid Values")]
    public int gridX;
    public int gridY;
    public BoardBehaviour boardBehaviour;
    public Vector2Int gemPosition;

    [Header("Positional Values")]

    public Vector2 firstTouchPosition;
    public Vector2 finalTouchPosition;
    private float swapAngle = 0f;
    public float threshold = 0.5f;
    private void Start()
    {
        boardBehaviour = FindObjectOfType<BoardBehaviour>();
    }

    private void Update()
    {
        Debug.Log($"FIRST TOUCH POSITION : {firstTouchPosition}. FINAL TOUCH POSITION {finalTouchPosition}");
        if (Input.GetMouseButtonUp(0))
        {
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            firstTouchPosition = Vector3.zero;
            finalTouchPosition = Vector3.zero;
        }
    }
    public void SetPosition(int x, int y)   // to instantiate the fruit object in same position as the background tile
    {
        gridX = x;
        gridY = y;
        gemPosition = new Vector2Int(x, y);
    }

    public void StoreGems(Vector2Int gemPositionBoard, BoardBehaviour board) // storing for future use
    {
        gemPosition = gemPositionBoard;
        boardBehaviour = board;
    }

    private void OnMouseDown()
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(firstTouchPosition);
        Debug.Log("OnMouseDown()");
    }

    private void OnMouseUp()
    {
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(finalTouchPosition);
        Debug.Log("OnMouseUp()");
        SwapAngle();

    }

    void SwapAngle()
    {
        Vector2 swapDirection = finalTouchPosition - firstTouchPosition;
        swapAngle = Mathf.Atan2(swapDirection.y, swapDirection.x) * Mathf.Rad2Deg;
        Debug.Log($"SWAP ANGLE: {swapAngle}");

        if (Vector3.Distance(firstTouchPosition, finalTouchPosition) > threshold)
        {
            if (swapAngle > -45 && swapAngle <= 45)
            {
                Debug.Log("Swipe Right");
                SwapRight();
            }
            else if (swapAngle > 45 && swapAngle <= 135)
            {
                Debug.Log("Swipe Up");
                SwapUp();
            }
            else if (swapAngle > 135 || swapAngle <= -135)
            {
                Debug.Log("Swipe Left");
                SwapLeft();
            }
            else if (swapAngle < -45 && swapAngle >= -135)
            {
                Debug.Log("Swipe Down");
                SwapDown();
            }
        }
    }

    void SwapRight()
    {
        SwapFruits(gridX + 1, gridY);
    }

    void SwapLeft()
    {
        SwapFruits(gridX - 1, gridY);
    }

    void SwapUp()
    {
        SwapFruits(gridX, gridY + 1);
    }

    void SwapDown()
    {
        SwapFruits(gridX, gridY - 1);
    }

    void SwapFruits(int targetX, int targetY)
    {
        Gem targetGem = boardBehaviour.GetGem(targetX, targetY);

        boardBehaviour.gemReferences[gridX, gridY] = targetGem;
        (gridX, gridY, targetGem.gridX, targetGem.gridY) = (targetGem.gridX, targetGem.gridY, gridX, gridY);
        (transform.position, targetGem.transform.position) = (targetGem.transform.position, transform.position);
    }


}