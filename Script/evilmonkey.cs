using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilmonkey : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5f;
    public float max=2.2f;
    private float currentpos;
    public float speed = 1f;
    private float oldspeed = 0f;
    void Start()
    {
        currentpos = transform.position[2];
        Debug.Log(transform.position);
        oldspeed=speed;
        speed=0f-speed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0f;
        //get the Input from Vertical axis
        float verticalInput = speed;
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0f, verticalInput * movementSpeed * Time.deltaTime);
        if (transform.position[2]<=currentpos- max)
        {
            speed=oldspeed;
        }
        if (transform.position[2]>= currentpos)
        {
            speed = 0f - oldspeed;
        }
    }
}
