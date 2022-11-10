using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float move; 
    private float moveSpeed;
    private float rotation;
    private float rotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        rotateSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * - rotateSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }
}
