using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCount : MonoBehaviour
{
    void Start()
    {
        int oldv = PlayerPrefs.GetInt("cnall");
        PlayerPrefs.SetInt("cnall", oldv+1);
    }
}
