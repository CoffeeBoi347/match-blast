using UnityEngine;

public class MouseTrail : MonoBehaviour
{
    public GameObject circleObj;
    public Vector3 mousePos;


    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 1f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        circleObj.transform.position = worldPos;
    }
}