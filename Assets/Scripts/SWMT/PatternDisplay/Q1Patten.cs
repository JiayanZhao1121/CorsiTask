using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Q1Patten : MonoBehaviour {
    public Button B1;
    public Button B2;
    public Button B3;
    public Button B4;
    public Button B5;
    public Button B6;
    public Button B7;
    public Button B8;
    public Button B9;

    public GameObject DoneButton;
    public GameObject canvas;
    public List<int> correctIndexList = new List<int>();
    private int BlockNumber = 0;
    private int timeCount = 0;
    private float startTime = 0;
    // Use this for initialization
    void Start()
    {
     
       // correctIndexArray = new int[BlockNumber];
    }
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerPrefs.SetInt("block number", PlayerPrefs.GetInt("block number"));
        BlockNumber = PlayerPrefs.GetInt("block number");
        for (int i = 0; i < BlockNumber; i++)
        {
            correctIndexList.Add((int)Random.Range(0.0001f, 8.9999f));
            if (correctIndexList.Count > 1)
            {
                while (correctIndexList[correctIndexList.Count-1] == correctIndexList[correctIndexList.Count - 2])
                {
                    correctIndexList[correctIndexList.Count - 1] = (int)Random.Range(0.0001f, 8.9999f);
                }
            }
        }
        timeCount = BlockNumber;
        startTime = Time.time;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        timeCount = 0;
        BlockNumber = 0;
        startTime = 0;
        correctIndexList = new List<int>();
    }
    // Update is called once per frame
    void Update () {
        //  float runTime = Time.time - canvas.GetComponent<GeneralController>().Q1StartTime;
        float runTime = Time.time - startTime;
        if (timeCount > 0)
        {
         
            if (runTime > BlockNumber - timeCount + 1 && runTime <= BlockNumber - timeCount + 2 && timeCount != 0)
            {
                if (timeCount < BlockNumber)
                {
                    transform.GetChild(correctIndexList[BlockNumber - timeCount - 1]).GetComponent<Image>().color = new Color32(58, 177, 255, 255);
                }
                transform.GetChild(correctIndexList[BlockNumber - timeCount]).GetComponent<Image>().color = Color.yellow;
           
                timeCount = timeCount - 1;
            }
        }
        else if (timeCount <= 0 && runTime > BlockNumber+1)
        {
  transform.GetChild(correctIndexList[BlockNumber - timeCount - 1]).GetComponent<Image>().color = new Color32(58, 177, 255, 255);
        DoneButton.SetActive(true);
        gameObject.GetComponent<Q1Retrieve>().enabled = true;
         
        enabled = false;
        }
      

    }
}
