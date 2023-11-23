using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlassTrigger : MonoBehaviour
{
    public GameObject CorrectMessage;
    public GameObject PlateMessage;
    public GameObject NoFoodMessage;
    public GameObject DepositMessage;
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

                    if(other.GetComponent<CustomTag>().HasTag("Glass"))
                    {
                        //Instantiate(CorrectMessage, new Vector3(0,0,0), Quaternion.identity);
                        //sprinkles.Play();
                        ScriptContainer.GetComponent<GoodBad>().CorrectAttempt(sprinkles);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("Chem"))
                    {
                        Instantiate(ChemMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("GFT") || other.GetComponent<CustomTag>().HasTag("Paper") || other.GetComponent<CustomTag>().HasTag("PMD") || other.GetComponent<CustomTag>().HasTag("Electronics"))
                    {
                        Instantiate(RecOtherBinMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("General"))
                    {
                        Instantiate(NonRecMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("NoFood"))
                    {
                        Instantiate(NoFoodMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("Deposit"))
                    {
                        Instantiate(DepositMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("PlateGlass"))
                    {
                        Instantiate(PlateMessage, new Vector3(0,0,0), Quaternion.identity);
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
