using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q1Retrieve : MonoBehaviour {
    private int score;
    private int ClickTimes;

    public Button B1;
    public Button B2;
    public Button B3;
    public Button B4;
    public Button B5;
    public Button B6;
    public Button B7;
    public Button B8;
    public Button B9;
    private bool IsCorrect;
    public GameObject canvas;
    private int BlockNumber = 0;
    private  List<int> correctIndexList = new List<int>();
    private GameObject buttonGameObject;
    public bool isDoneClicked;
    public GameObject DoneButton;
    // Use this for initialization
    void Start () {
        score = 0;
        ClickTimes = 0;
        IsCorrect = false;
        isDoneClicked = false;
	}
    private void OnEnable()
    {
        BlockNumber = PlayerPrefs.GetInt("block number");
        correctIndexList = GetComponent<Q1Patten>().correctIndexList;
        GetComponent<Q1Patten>().correctIndexList = new List<int>();
        isDoneClicked = false;
    }
    private void OnDisable()
    {
        score = 0;
        ClickTimes = 0;
        IsCorrect = false;
        correctIndexList = new List<int>();
        BlockNumber = 0;

    }
    // Update is called once per frame
    void Update () {
       
    }


    public void ClickButton(Button button)
    {

    
        if (isActiveAndEnabled)
        {
            buttonGameObject = transform.Find(button.name).gameObject;
            buttonGameObject.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeColor", 0.3f);
          
            if (ClickTimes <= correctIndexList.Count)
            {
       if (score == ClickTimes-1 && button.name.Contains((correctIndexList[ClickTimes-1] + 1).ToString()) )
                {
                    score++;
                }
                 if (score == correctIndexList.Count)
                {
                  IsCorrect = true;
                }
            }
            else
            {
                  IsCorrect = false;
            }
          
        }
     


    }




    public void ClickDone()
    {
        Debug.Log("Is True?" + IsCorrect);
        canvas.GetComponent<GeneralController>().IsCorrectShowUp = IsCorrect;
        canvas.GetComponent<GeneralController>().timer = Time.time;
        canvas.GetComponent<GeneralController>().isQ1 = true;
        gameObject.SetActive(false);
        gameObject.GetComponent<Q1Patten>().enabled = true;
        gameObject.GetComponent<Q1Retrieve>().enabled = false;
        isDoneClicked = true;
        if (canvas.GetComponent<GeneralController>().IsCorrectShowUp)
        {
            canvas.transform.Find("Correct").gameObject.SetActive(true);

        }
        else
        {
            canvas.transform.Find("Wrong").gameObject.SetActive(true);
        }
        DoneButton.SetActive(false);

    }

    void changeColor()
    {


        buttonGameObject.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
    
}
