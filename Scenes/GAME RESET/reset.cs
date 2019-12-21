using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    public string score = "score";
    public string feedback= "Back";
    public string cnall = "cnall";
    public int Null = 0;
    public int Loadlevel = 0;
    public void removeall()
    {
        PlayerPrefs.SetInt(score, Null);
        PlayerPrefs.SetInt(feedback, Null);
        PlayerPrefs.SetInt(cnall, Null);
        PlayerPrefs.SetInt("removed", 1);
        Application.LoadLevel(Loadlevel);
    }
    public void stops()
    {
        Application.LoadLevel(Loadlevel);
    }
}
