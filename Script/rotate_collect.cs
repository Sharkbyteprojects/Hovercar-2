using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_collect : MonoBehaviour
{
    public float rotationv = 10F;
    void Update()
    {
        transform.Rotate(0F, rotationv, rotationv);
    }
}
