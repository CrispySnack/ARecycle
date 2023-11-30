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
    public List<string> usedObjects =  new List<string>();
    public GameObject TutorialCanvas;
    public GameObject FeedbackTextBox;



    // Start is called before the first frame update
    void Start()
    {
        // Button btn = StartButton.GetComponent<Button>();
        StartButton.onClick.AddListener(NewSession);
        TutorialCanvas = GameObject.FindWithTag("TutorialUI_Tag");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  /*  public void CorrectAttempt(ParticleSystem sprinkles)
    {
        // Create positive message
        Instantiate(CorrectMessage, new Vector3(0,0,0), Quaternion.identity);

        // Create sparkles
        sprinkles.Play();

        //Add to score
        Score = Score+1;

        //Update the score text
        ScoreText.SetText("Score: " + Score.ToString());
    } */

    public void putInBin(string itemName, string binName, bool isCorrect, ParticleSystem sprinkles, string messageType)
    {
        
    
        string FeedbackText = FeedbackTextLookup(messageType);
        

        FeedbackTextBox.GetComponent<TMP_Text>().text = FeedbackText;


        //Show Message
        //Instantiate(messageObject, new Vector3(0,0,0), Quaternion.identity);

        //Change colour
        if(isCorrect)
        {
            FeedbackTextBox.GetComponent<TMP_Text>().color = Color.green;
        }
        else
        {
            FeedbackTextBox.GetComponent<TMP_Text>().color = Color.red;
        }

    
        if(!usedObjects.Contains(itemName))
        {
            if(itemName == "tutorialitem")
            {
                TutorialCanvas.GetComponent<UIscript>().tutInBin(isCorrect);
            }
            else
            {
                //Add line to savefile for every attempt
                PushToData(itemName + ":" + isCorrect.ToString());
            }

            

            if(isCorrect)
            {
                //add object to list of used objects
                usedObjects.Add(itemName);

                //Display fireworks
                sprinkles.Play();

                //Add to score
                Score = Score+1;

                //Update the score text
                ScoreText.SetText("Score: " + Score.ToString());
            }
        }
    }

    public string FeedbackTextLookup(string messageType)
    {
        if(messageType == "CorrectMessage")
        {
            return "Correct! This object belongs in this bin.";
        }
        else if(messageType == "ChemMessage")
        {
            return "Incorrect! This object contains chemical waste and should be thrown away separately, as it could contaminate other waste.";
        }
        else if(messageType == "RecOtherBinMessage")
        {
            return "Incorrect! The object is recyclable but contains materials that do not belong in this bin.";
        }
        else if(messageType == "NonRecMessage")
        {
            return "Incorrect! The object is not easily recyclable and should be thrown away in a different bin.";
        }
        else if(messageType == "NoFoodMessage")
        {
            return "Incorrect! The object contains glass, but not glass that can easily be recycled. It should go somewhere else.";
        }
        else if(messageType == "DepositMessage")
        {
            return "Incorrect! The object contains the correct materials but has a deposit on it.";
        }
        else if(messageType == "PlateMessage")
        {
            return "Incorrect! The object contains plate glass. This glass can be recycled but should be separated from normal glass.";
        }
        else if(messageType == "PropMessage")
        {
            return "Incorrect! The object contains propellants, which are not allowed in this bin.";
        }
        else if(messageType == "GeneralMessage")
        {
            return "Incorrect! The object is not easily recyclable but does not have to be turned in.";
        }
        else if(messageType == "RecSpecificMessage")
        {
            return "Incorrect! The object can be recycled or reused. It should go in a more specific bin.";
        }
        else if(messageType == "RecyclableMessage")
        {
            return "Incorrect! The object can be recycled or reused. It should go in a more specific bin.";
        }
        else if(messageType == "NotCompostableMessage")
        {
            return "Incorrect! The object is organic but not compostable, making it difficult to reuse.";
        }
        else if(messageType == "WetMessage")
        {
            return "Incorrect! The object contains paper but is too dirty or wet to recycle in this case.";
        }
        else if(messageType == "LiningMessage")
        {
            return "Incorrect! The object contains paper but also contains materials that do not belong in this bin.";
        }
        else if(messageType == "NoRipMessage")
        {
            return "Incorrect! The object contains paper but cannot be recycled very well because it is too strong.";
        }
        else if(messageType == "DirtyMessage")
        {
            return "Incorrect! The object contains the correct materials and is usually recyclable but is too dirty to recycle in this case.";
        }
        else
        {
            return "Incorrect!!!!!";
        }

    }

    public void PushToData(string resultLine)
    {
       resultString += "\n" + resultLine;
       SaveToFile();
    }

    public void SaveToFile()
    {
        string filePath = Application.persistentDataPath + "/"+ sessionName +".txt";
        System.IO.File.WriteAllText(filePath, resultString);
    }

    public void NewSession()
    {
        resultString = "";
        usedObjects.Clear();
        sessionName = "ARecycling_Results_" + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
    }




}
