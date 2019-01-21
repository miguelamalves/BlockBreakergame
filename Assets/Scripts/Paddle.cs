using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //configuration parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;


    [SerializeField] float ScreenWidthUnits = 16f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float currentPosition = Input.mousePosition.x / Screen.width * ScreenWidthUnits;

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(currentPosition, minX, maxX);

        transform.position = paddlePos;
	}
}
