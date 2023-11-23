using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoodBad : MonoBehaviour
{

    public GameObject CorrectMessage;
    public int Score = 0;
    public TMP_Text ScoreText;
    public Button StartButton;

    public string sessionName;
    public string resultString = "";
    /*
    Object[] results = {
        new() { "ObjectName" = "Wine Bottle", "Attempts" = "5"},
        new() { "ObjectName" = "Pepsi Can", "Attempts" = "7"},
        new() { "ObjectName" = "Towel", "Attempts" = "3"},
        new() { "ObjectName" = "Milk Carton", "Attempts" = "2"}
    }; */

    // Start is called before the first frame update
    void Start()
    {
        // Button btn = StartButton.GetComponent<Button>();
        StartButton.onClick.AddListener(NewSession);
        Debug.Log("GoodBad Script started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CorrectAttempt(ParticleSystem sprinkles)
    {
        // Create positive message
        Instantiate(CorrectMessage, new Vector3(0,0,0), Quaternion.identity);

        // Create sparkles
        sprinkles.Play();

        //Add to score
        Score = Score+1;

        //Update the score text
        ScoreText.SetText("Score: " + Score.ToString());
    }

    public void PushToData()
    {
       resultString += "\n" + "chica is so cute wtf";
    }

    public void SaveToFile()
    {
        string filePath = Application.persistentDataPath + "/"+ sessionName +".txt";
        System.IO.File.WriteAllText(filePath, resultString);
    }

    public void NewSession()
    {
        Debug.Log("coon is coot");
        sessionName = "ARecycling_Results_" + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
        PushToData();
        PushToData();
        PushToData();
        SaveToFile();
    }




}
