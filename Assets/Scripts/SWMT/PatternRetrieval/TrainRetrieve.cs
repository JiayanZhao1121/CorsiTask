using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainRetrieve : MonoBehaviour {
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
   
    public GameObject correctText;
    public GameObject incorrectText;
    public GameObject RetrievalText;
    public GameObject Ready;
    // Use this for initialization
    void Start () {
        score = 0;
        ClickTimes = 0;
        IsCorrect = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ClickTimes ==2)
        {
            RetrievalText.SetActive(false);
            if (!IsCorrect)
            {
                incorrectText.SetActive(true);
            }        
        }
	}
    public void ClickB1()
    {
        if (isActiveAndEnabled)
        {
 B1.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeB1Color", 0.3f);
            if (score == 0 && ClickTimes == 1)
            {
                score++;
            }
        }
       if (ClickTimes > 2)
        {
            incorrectText.SetActive(true);
        }

    }
    public void ClickB2()
    {
        if (isActiveAndEnabled)
        {
            B2.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeB2Color", 0.3f);
        }
        if (ClickTimes > 2)
        {
            IsCorrect = false;
        }
    }
    public void ClickB3()
    {
        if (isActiveAndEnabled)
        {
            B3.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeB3Color", 0.3f);
            if (score == 1 && ClickTimes == 2)
            {
                score++;
                IsCorrect = true;
                incorrectText.SetActive(false);
                correctText.SetActive(true);
            }
        }
        if (ClickTimes > 2)
        {
            IsCorrect = false;
        }
    }
    public void ClickB4()
    {
        if (isActiveAndEnabled)
        {
            B4.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeB4Color", 0.3f);
           
        }
        if (ClickTimes > 2)
        {
            IsCorrect = false;
        }

    }
    public void ClickB5()
    {
        if (isActiveAndEnabled)
        {
            B5.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeB5Color", 0.3f);
        }
        if (ClickTimes > 2)
        {
            IsCorrect = false;
        }

    }
    public void ClickB6()
    {
        if (isActiveAndEnabled)
        {
            B6.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeB6Color", 0.3f);
        }
        if (ClickTimes > 2)
        {
            IsCorrect = false;
        }
    }
    public void ClickB7()
    {
        if (isActiveAndEnabled)
        {
            B7.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeB7Color", 0.3f);
           

        }
        if (ClickTimes > 2)
        {
            IsCorrect = false;
        }
    }
    public void ClickB8()
    {
        if (isActiveAndEnabled)
        {
            B8.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeB8Color", 0.3f);
            
        }
        if (ClickTimes > 2)
        {
            IsCorrect = false;
        }
    }
    public void ClickB9()
    {
        if (isActiveAndEnabled)
        {
            B9.GetComponent<Image>().color = Color.yellow;
            ClickTimes++;
            Invoke("changeB9Color", 0.3f);
        }
        if (ClickTimes > 2)
        {
            IsCorrect = false;
        }
    }
    public void ClickDone()
    {
        Debug.Log("Is True?" + IsCorrect);
        if(IsCorrect) {
        canvas.GetComponent<GeneralController>().timer = Time.time;
        canvas.GetComponent<GeneralController>().isExample = true;     
        gameObject.SetActive(false);
        canvas.GetComponent<GeneralController>().ready.SetActive(true);
        }
       
    }
    public void ClickRetry()
    {
        canvas.GetComponent<GeneralController>().isStartPage = true;
        canvas.GetComponent<GeneralController>().timer = Time.time;
        Ready.SetActive(true);
        gameObject.GetComponent<TrainPatten>().enabled = true;
        gameObject.GetComponent<TrainRetrieve>().enabled = false;
        ClickTimes = 0;
        score = 0;
        IsCorrect = false;
        gameObject.SetActive(false);
       
    }

    void changeB1Color()
    {
       

        B1.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
    void changeB2Color()
    {


        B2.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
    void changeB3Color()
    {


        B3.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
    void changeB4Color()
    {


        B4.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
    void changeB5Color()
    {


        B5.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
    void changeB6Color()
    {


        B6.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
    void changeB7Color()
    {


        B7.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
    void changeB8Color()
    {


        B8.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
    void changeB9Color()
    {


        B9.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
    }
}
