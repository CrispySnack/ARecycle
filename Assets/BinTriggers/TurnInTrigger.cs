using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnInTrigger : MonoBehaviour
{
    public GameObject CorrectMessage;
    public GameObject GeneralMessage;
    public GameObject RecSpecificMessage;
    public GameObject PropMessage;
    ParticleSystem sprinkles;
    public GameObject ScriptContainer;
    private float coltimer = 2;
    private bool Triggered = false;
    public string DecidedMessage;
    public bool isCorrect;


    // Start is called before the first frame update
    void Start()
    {
        sprinkles = GetComponent<ParticleSystem>();
        ScriptContainer = GameObject.FindWithTag("ScriptContainer_Tag");
    }

    void OnTriggerEnter(Collider other)
    {

    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if(!Triggered){
            if(coltimer > 0)
                {
                    coltimer -= Time.deltaTime;
                }
        
            else
                {  
                    Triggered = true;
                    string itemName = other.transform.parent.gameObject.name.Replace("(Clone)","");

                    if(other.GetComponent<CustomTag>().HasTag("Chem") || other.GetComponent<CustomTag>().HasTag("Deposit") || other.GetComponent<CustomTag>().HasTag("PlateGlass"))
                    {
                        isCorrect = true;
                        DecidedMessage = "CorrectMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("General") || other.GetComponent<CustomTag>().HasTag("NoFood"))
                    {
                        //Instantiate(GeneralMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "GeneralMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("GFT") || other.GetComponent<CustomTag>().HasTag("Paper") || other.GetComponent<CustomTag>().HasTag("PMD") || other.GetComponent<CustomTag>().HasTag("Glass"))
                    {
                        //Instantiate(RecSpecificMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "RecSpecificMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("Propellant"))
                    {
                        //Instantiate(PropMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "PropMessage";
                    }

                    ScriptContainer.GetComponent<GoodBad>().putInBin(itemName, "TurnIn", isCorrect, sprinkles, DecidedMessage);
                }
        }
    }

    void OnTriggerExit(Collider other)
    {
        coltimer = 2;
        Triggered = false;
    }

    void Update()
    {
        // Timer for correct/wrong
        /* if(IsColliding == true)
        {
            if(coltimer > 0)
                {
                    coltimer -= Time.deltaTime;
                }
        
            else
                {
                    coltimer = 0;
                    IsCorrect = true;
                }
        }
        */


/*
        if(IsCorrect == true)
        {
            Instantiate(goodmssg, new Vector3(0,0,0), Quaternion.identity);
        }

        if(IsWrong == true)
        {
            Instantiate(wrongmssg, new Vector3(0,0,0), Quaternion.identity);
        }
        */
    }

}
