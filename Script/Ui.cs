using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class Ui : MonoBehaviour
{
    private bool helps = false;
    public bool MainMenu = true;
    public GameObject helpPanel;
    public GameObject helpButton;
    private Text helpButtonT;
    private Text uid;
    public bool feedbackAvail=false;
    public GameObject buttons;
    public GameObject buttone;
    public GameObject thanksforback;
    public string scorevar = "score";
    public GameObject scoreTxt = null;
    private Text toscore;
    public GameObject removed;
    public GameObject removedbn;
    void Start()
    {
        if (MainMenu)
        {
            helpPanel.SetActive(false);
            if((PlayerPrefs.GetInt("Score")==0&& PlayerPrefs.GetInt("Back") == 0)&&PlayerPrefs.GetInt("removed") != 1)
            {
                removedbn.SetActive(false);
            }
            toscore = scoreTxt.GetComponent<UnityEngine.UI.Text>();
            int scorevarss = PlayerPrefs.GetInt(scorevar);
            if (scorevarss != 0)
            {
                toscore.text = "Score: " + scorevarss.ToString()+" ";
            }
            else
            {
                toscore.text = "";
            }
            if (PlayerPrefs.GetInt("removed") == 1)
            {
                removed.SetActive(true);
                PlayerPrefs.SetInt("removed", 0);
                toscore.text = "Game Data Removed ";
            }
            helpButtonT = helpButton.GetComponent<UnityEngine.UI.Text>();
            uid = helpPanel.GetComponent<UnityEngine.UI.Text>();
            helpButtonT.text = "Help ->";
        }
        if (PlayerPrefs.GetInt("Back")==1&& feedbackAvail)
        {
            buttons.SetActive(false);
            buttone.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    public void loadLevel(int levelid)
    {
        Application.LoadLevel(levelid);
    }
    public void applicationHelp(string textd= "You must collect the Yellow cubes.\nDon't crash into the Walls!")
    {
        removed.SetActive(false);
        if (!helps) {
            helps = true;
            helpButtonT.text = "Help <-";
            helpPanel.SetActive(true);
            uid.text = textd;
        } else {
            uid.text = "";
            helps = false;
            helpButtonT.text = "Help ->";
            helpPanel.SetActive(false);
        }
    }
    public void applicationFeedback(bool typeOfFeedbackPos)
    {
        Analytics.CustomEvent("feedback", new Dictionary<string, object>
        {
            {"positiveFeedback", typeOfFeedbackPos}
        });
        buttons.SetActive(false);
        buttone.SetActive(false);
        PlayerPrefs.SetInt("Back", 1);
        thanksforback.SetActive(true);
    }
}
