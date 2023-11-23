using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrganicTrigger : MonoBehaviour
{
    public GameObject CorrectMessage;
    public GameObject NotCompostableMessage;
    public GameObject ChemMessage;
    public GameObject RecOtherBinMessage;
    public GameObject NonRecMessage;
    ParticleSystem sprinkles;
    public GameObject ScriptContainer;
    private float coltimer = 2;
    private bool Triggered = false;


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
                    coltimer = 0;

                    if(other.GetComponent<CustomTag>().HasTag("GFT"))
                    {
                        ScriptContainer.GetComponent<GoodBad>().CorrectAttempt(sprinkles);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("Chem"))
                    {
                        Instantiate(ChemMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("PMD") || other.GetComponent<CustomTag>().HasTag("Plastic") || other.GetComponent<CustomTag>().HasTag("Glass") || other.GetComponent<CustomTag>().HasTag("Electronics") || other.GetComponent<CustomTag>().HasTag("Deposit") || other.GetComponent<CustomTag>().HasTag("Paper"))
                    {
                        Instantiate(RecOtherBinMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("General"))
                    {
                        Instantiate(NonRecMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("NotCompostable"))
                    {
                        Instantiate(NotCompostableMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
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
