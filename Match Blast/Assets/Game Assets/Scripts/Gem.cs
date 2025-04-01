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
    private bool mousePressed = false;
    private void Start()
    {
        boardBehaviour = FindObjectOfType<BoardBehaviour>();
    }

    private void Update()
    {
        if (mousePressed && Input.GetMouseButtonUp(0))
        {
            finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SwapAngle();
        }
    }
    public void SetPosition(int x, int y)   // to instantiate the fruit object in same position as the background tile
    {
        gridX = x;
        gridY = y;
        gemPosition = new Vector2Int(x, y);
    }

    public void StoreGems(Vector2Int gemPositionBoard, BoardBehaviour bourd) // storing for future use
    {
        gemPosition = gemPositionBoard;
        boardBehaviour = bourd;
    }

    private void OnMouseDown()
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Debug.Log(firstTouchPosition);
        mousePressed = false;
    }

    private void OnMouseUp()
    {
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(finalTouchPosition);
        mousePressed = true;
    }

    void SwapAngle()
    {
        Vector2 swapDirection = finalTouchPosition - firstTouchPosition;
        swapAngle = Mathf.Atan2(swapDirection.y, swapDirection.x) * Mathf.Rad2Deg;

        if (swapAngle > -45 && swapAngle <= 45)
        {
            Debug.Log("Swipe Right");
        }
        else if (swapAngle > 45 && swapAngle <= 135)
        {
            Debug.Log("Swipe Up");
        }
        else if (swapAngle > 135 || swapAngle <= 180)
        {
            Debug.Log("Swipe Left");
        }
        else if (swapAngle > -135 && swapAngle <= -45)
        {
            Debug.Log("Swipe Down");
        }

    }
}