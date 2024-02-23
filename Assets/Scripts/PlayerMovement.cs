using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxX = 7.5f;
    public float minX = -7.5f;

    public float movementHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");

        Vector3 newPosition = transform.position + new Vector3 ( movementHorizontal, 0f, 0f ) * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp ( newPosition.x, minX, maxX );

        transform.position = newPosition;

        
        
    }
}
