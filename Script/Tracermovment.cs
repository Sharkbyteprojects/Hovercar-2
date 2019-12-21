using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class Tracermovment : MonoBehaviour
{
    public float baseVelocity = 5F;
    public Rigidbody rigi = null;
    public float rotationv = 10F;
    private bool loose = false;
    public string wallname = null;
    public string enemy = null;
    public GameObject loooser = null;
    public string winin = null;
    public float numberofwin = 0F;
    public GameObject winobjectText=null;
    private bool winner = false;
    public GameObject WinToText = null;
    private Text towinscore;
    public AudioSource collectedServiceWhen;
    private int Scoreflash = 0;
    public string scorevar = "score";
    public GameObject scoreTxt = null;
    private Text toscore;
    private bool onceee=false;
    void Start()
    {
    	Analytics.CustomEvent("levelLoad", new Dictionary<string, object>
            {
                {"level", Application.loadedLevel}
            });
        rigi.velocity = transform.right * baseVelocity;
        loooser.SetActive(false);
        winobjectText.SetActive(false);
        WinToText.SetActive(true);
        Scoreflash=PlayerPrefs.GetInt(scorevar);
        toscore= scoreTxt.GetComponent<UnityEngine.UI.Text>();
        toscore.text = "Score: " + Scoreflash.ToString();
        towinscore =WinToText.GetComponent<UnityEngine.UI.Text>();
        towinscore.text = "You have to collect " + numberofwin.ToString()+" Objects";/*https://answers.unity.com/questions/848230/how-to-edit-ui-text-from-script.html
    */}

    void Update()
    {
        if (numberofwin <= 0&&!loose) {
            if (!onceee)
            {
                onceee=true;
                Scoreflash += 100 * Application.loadedLevel;
                toscore.text = "Score: " + Scoreflash.ToString();
                PlayerPrefs.SetInt(scorevar, Scoreflash);
                Analytics.CustomEvent("winner", new Dictionary<string, object>
                {
                    { "playerscore", Scoreflash},
                    {"level", Application.loadedLevel},
                    { "trys", PlayerPrefs.GetInt("cnall") }
               });
            }
            winobjectText.SetActive(true);
            winner = true;
            WinToText.SetActive(false);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (!loose&&!winner)
        {
            float rotation = 0F;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rotation = 0F - rotationv;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rotation = rotationv;
            }
            if (rotation != 0F)
            {
                transform.Rotate(0F, rotation, 0F);
                rigi.velocity = transform.right * baseVelocity;
            }
            rigi.velocity = transform.right * baseVelocity;
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if ((coll.gameObject.name == wallname&&!winner)||(coll.gameObject.name == enemy&&!winner))
        {
        	bool whygameover=true;
        	if(coll.gameObject.name == enemy){
        		whygameover=false;
        	}
            loose = true;
            loooser.SetActive(true);
            WinToText.SetActive(false);
            Analytics.CustomEvent("gameOver", new Dictionary<string, object>
            {
                { "cubes_needed", numberofwin },
                { "wallcrash", whygameover },
                { "playerscore", Scoreflash},
                {"level", Application.loadedLevel},
                { "trys", PlayerPrefs.GetInt("cnall") }
            });
        }
        else if(coll.gameObject.name == winin){
            coll.gameObject.SetActive(false);
            numberofwin--;
            towinscore.text = "You have to collect " + numberofwin.ToString() + " Objects";
            collectedServiceWhen.Play();
            Scoreflash++;
            toscore.text = "Score: " + Scoreflash.ToString();
            PlayerPrefs.SetInt(scorevar, Scoreflash);
            Analytics.CustomEvent("cubeCollect", new Dictionary<string, object>
            {
                { "cubes_needed", numberofwin },
                {"playerscore",Scoreflash },
                {"level", Application.loadedLevel},
                {"trys", PlayerPrefs.GetInt("cnall") }
            });
        }
    }
    public void reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
