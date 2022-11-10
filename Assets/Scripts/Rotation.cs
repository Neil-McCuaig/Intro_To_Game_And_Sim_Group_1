using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float move; 
    public float moveSpeed;
    private float rotation;
    public float rotateSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        rotateSpeed = 100f;
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
