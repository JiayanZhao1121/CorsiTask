using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GeneralController : MonoBehaviour {
    public float timer;
    public GameObject startPage;
    public GameObject ready;
    public GameObject end;
    public GameObject Example;
    public GameObject Q1;


    public bool isStartPage;
    public bool isExample;
    public bool isQ1;
    public int chance;


    public bool isQ2;



    public float ExampleStartTime;



    public bool IsCorrectShowUp;
    public GameObject canvas;
    public string[] LastCorrectSequencerArray;


    private int CorsiSpanScore;


    //public GameObject enterParticipantNameGameobject;
    public Text ParticipantText;
    // seed
    public int seed = 0;
    public int[] seedValues;
  
    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("block number", 2);

        CorsiSpanScore = 0;

        timer = 0f;
        isStartPage = false;
        isExample = false;
        isQ1 = false;
        chance = 0;



        
  

        ExampleStartTime = 0f;
    

        IsCorrectShowUp = false;

        LastCorrectSequencerArray = new string[8];

        // seed
        Random.InitState(seed);
        seedValues = new int[20];
        int i = 0;
        while (i < seedValues.Length)
        {
            seedValues[i] = Random.Range(1, 1000);
            i++;
        }

    }
	
	// Update is called once per frame
	void Update () {
		if (((Time.time - timer) > 1f) && isStartPage)
        {
            ready.SetActive(false);
            Example.SetActive(true);          
            isStartPage = false;
            timer = 0f;
            ExampleStartTime = Time.time;
        }
        if (((Time.time - timer) > 1f) && isExample)
        {
            ready.SetActive(false);
            Q1.SetActive(true);
            isExample = false;
            timer = 0f;
        }
        else if (isQ1 && ((Time.time - timer) > 1f))
        {
            if ((Time.time - timer) < 2f)
            {
                canvas.transform.Find("Wrong").gameObject.SetActive(false);
                canvas.transform.Find("Correct").gameObject.SetActive(false);
                if ((!canvas.GetComponent<GeneralController>().IsCorrectShowUp && chance == 1) || PlayerPrefs.GetInt("block number") == 9)
                {
                    end.SetActive(true);
                }
                else
                {
    ready.SetActive(true);
                }
            
            }
            else
            {
                ready.SetActive(false);
                if (PlayerPrefs.GetInt("block number") == 9)
                {
                    CorsiSpanScore = PlayerPrefs.GetInt("block number");
                    getTheData();
                    // Application.Quit();
                    UnityEditor.EditorApplication.isPlaying = false;
                }
         
            isQ1 = false;
             
            timer = 0f;
                if (Q1.GetComponent<Q1Retrieve>().isDoneClicked)
                {
       if (canvas.GetComponent<GeneralController>().IsCorrectShowUp)
                {
                        LastCorrectSequencerArray[0] = "once";
                    chance = 0;
                    PlayerPrefs.SetInt("block number", PlayerPrefs.GetInt("block number")+1);
                    timer = Time.time;
                    Q1.SetActive(true);
                }
                else
                {
                    chance++;
                    Debug.Log("chance = " + chance);
                    if (chance == 2)
                    {
                            CorsiSpanScore = PlayerPrefs.GetInt("block number")-1;
                            if (CorsiSpanScore == 1)
                            {
                                CorsiSpanScore = 0;
                            }
                            getTheData();
                            // Application.Quit();
                            UnityEditor.EditorApplication.isPlaying = false;
                    }
                    else
                    {
                        Q1.SetActive(true);
                        timer = Time.time;
                    }
                        Q1.GetComponent<Q1Retrieve>().isDoneClicked = false;
                }

                }
         
               
            }

            
        }
        
       

    }
    public void startTest()
    {
        if (ParticipantText.text != "")
        {
        timer = Time.time;
        startPage.SetActive(false);
        isStartPage = true;
        ready.SetActive(true);
        }
      
    }
    public void getTheData()
    {
         string filePath = @"Assets/Resource/SWMT_saved_data.csv";
       //string filePath = Application.dataPath + "/ExperimentData/SWMT_saved_data.csv";
    
        File.AppendAllText(filePath, ParticipantText.text + "," + CorsiSpanScore.ToString() + "\n");
    }
}
