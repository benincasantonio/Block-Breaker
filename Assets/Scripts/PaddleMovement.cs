using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    private float screenWidthInUnits;
    private float minX;
    private float maxX;
    

    void Start( ) {
        screenWidthInUnits = Camera.main.orthographicSize * Camera.main.aspect * 2;
        float paddleWidth = transform.localScale.x;
        minX = (0 - (screenWidthInUnits / 2)) + paddleWidth;
        maxX = (screenWidthInUnits / 2) - paddleWidth;
    }
    // Update is called once per frame
    void Update () {
        float mousePosition = Input.mousePosition.x;
        float paddlePositionInUnits = (mousePosition / Screen.width * screenWidthInUnits) - (screenWidthInUnits / 2) ;
        float checkPaddlePosition = Mathf.Clamp(paddlePositionInUnits, minX, maxX);
        Vector2 newPaddlePosition = new Vector2(checkPaddlePosition , transform.position.y);
        transform.position = newPaddlePosition;
	}
}
