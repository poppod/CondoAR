using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] bool canRotate;

    float screenWidth;
    Vector3 pressPoint;
    Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canRotate)
        {
            pressPoint = Input.mousePosition;
            startRotation = transform.rotation;
        }
        else if (Input.GetMouseButton(0) && canRotate)
        {
            float currentDistance = (Input.mousePosition - pressPoint).x;
            transform.rotation = startRotation * Quaternion.Euler(Vector3.down * (currentDistance / screenWidth * 360));
        }
    }
}
