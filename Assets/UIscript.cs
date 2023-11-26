using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{

    public GameObject Tutpage1;
    public GameObject Tutpage2;
    public GameObject Tutpage3;
    public GameObject Tutpage4;
    public GameObject Tutpage5;
    public GameObject Tutpage6;
    public GameObject Tutpage7r;
    public GameObject Tutpage7w;
    public GameObject Tutpage8;

    public GameObject TutPanel;

    public Button Button1;
    public Button Button3;
    public Button Button5;
    public Button Button7r;
    public Button Button7w;
    public Button Button8;

    public bool BinScanned;

    public int CurrentPage = 1;
    public DateTime startTime;
    public DateTime currentTime;

    public GameObject ScriptContainer;
    public GameObject FeedbackPanel;
    //public Stopwatch stopWatch;

    // Start is called before the first frame update
    void Start()
    {
        ScriptContainer = GameObject.FindWithTag("ScriptContainer_Tag");
        Button1.onClick.AddListener(Button1Press);
        Button3.onClick.AddListener(Button3Press);
        Button5.onClick.AddListener(Button5Press);
        Button7r.onClick.AddListener(Button7rPress);
        Button7w.onClick.AddListener(Button7wPress);
        Button8.onClick.AddListener(Button8Press);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Button1Press()
    {
        ChangePage(2);
        //stopWatch.Start();
    }

    public void Button3Press()
    {
        ChangePage(4);
    }

    public void Button5Press()
    {
        ChangePage(6);
    }

    public void Button7wPress()
    {
        ChangePage(6);
    }

    public void Button7rPress()
    {
        ChangePage(8);
    }

    public void Button8Press()
    {
        TutPanel.SetActive(false);
        ScriptContainer.GetComponent<GoodBad>().NewSession();
    }

    public void lookingAtBins()
    {
        // Debug.Log("looking at the bins");
        if(CurrentPage == 2)
        {
            currentTime = System.DateTime.UtcNow;
            double diffInSeconds = (currentTime - startTime).TotalSeconds;

            if(diffInSeconds > 5)
            {
                ChangePage(3);
            }
        }
    }

    public void lookingAtTutItem()
    {
        //Debug.Log("looking at the tutorial item");
        if(CurrentPage == 4)
        {
            currentTime = System.DateTime.UtcNow;
            double diffInSeconds = (currentTime - startTime).TotalSeconds;

            if(diffInSeconds > 5)
            {
                ChangePage(5);
            }
        }
    }

    public void tutInBin(bool isCorrect)
    {
        if(CurrentPage == 6)
        {

            FeedbackPanel.SetActive(true);
            
            if(isCorrect)
            {
                ChangePage(71);
            }
            else
            {
                ChangePage(72);
            }
            
        }
    }


    public void ChangePage(int PageNumber)
    {
        Debug.Log("PageNumber:" + PageNumber);

        //Reset startTime for timer
        startTime = System.DateTime.UtcNow;

        //Set it to page
        CurrentPage = PageNumber;

        //Close everything
        Tutpage1.SetActive(false);
        Tutpage2.SetActive(false);
        Tutpage3.SetActive(false);
        Tutpage4.SetActive(false);
        Tutpage5.SetActive(false);
        Tutpage6.SetActive(false);
        Tutpage7r.SetActive(false);
        Tutpage7w.SetActive(false);
        Tutpage8.SetActive(false);

        //Open pages
        if(PageNumber == 1)
        {
            Tutpage1.SetActive(true);
        }
        else if(PageNumber == 2)
        {
            Tutpage2.SetActive(true);
        }
        else if(PageNumber == 3)
        {
            Tutpage3.SetActive(true);
        }
        else if(PageNumber == 4)
        {
            Tutpage4.SetActive(true);
        }
        else if(PageNumber == 5)
        {
            Tutpage5.SetActive(true);
        }
        else if(PageNumber == 6)
        {
            Tutpage6.SetActive(true);
        }
        else if(PageNumber == 71)
        {
            Tutpage7r.SetActive(true);
        }
        else if(PageNumber == 72)
        {
            Tutpage7w.SetActive(true);
        }
        else if(PageNumber == 8)
        {
            Tutpage8.SetActive(true);
        }

    }
}
