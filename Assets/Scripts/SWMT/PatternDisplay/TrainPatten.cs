using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainPatten : MonoBehaviour {
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
    public GameObject EncodingTextGameObject;
    public GameObject RetrievalTextGameObject;
    public GameObject correctText;
    public GameObject incorrectText;
    // Use this for initialization
    void Start () {
		
	}
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update () {
        float runTime = Time.time - canvas.GetComponent<GeneralController>().ExampleStartTime;
        if (runTime < 3f && runTime > 0f)
        {
            EncodingTextGameObject.SetActive(true);
            RetrievalTextGameObject.SetActive(false);
            correctText.SetActive(false);
            incorrectText.SetActive(false);

}
        if (runTime > 1f && runTime <= 2f)
        {
            B1.GetComponent<Image>().color = Color.yellow;
           
        }
        else if (runTime > 2f && runTime <= 3f)
        {
            B1.GetComponent<Image>().color = new Color32(58, 177, 255,255); // customized blue
            B3.GetComponent<Image>().color = Color.yellow;
        }
        else if (runTime > 3f)
        {           
            B3.GetComponent<Image>().color = new Color32(58, 177, 255, 255);
            DoneButton.SetActive(true);
            gameObject.GetComponent<TrainRetrieve>().enabled = true;
            EncodingTextGameObject.SetActive(false);
            RetrievalTextGameObject.SetActive(true);
            enabled = false;
        }
    }
}
