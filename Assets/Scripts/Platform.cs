using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
   


    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        float mouseX = mouseWorldPosition.x;
        float clampMouseX = Mathf.Clamp(mouseX, minX, maxX);
        float mouseY = transform.position.y;
        transform.position = new Vector3(clampMouseX, mouseY, 0);
    }
}
