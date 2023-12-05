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
    public GameObject PropMessage;
    public string DecidedMessage;
    public bool isCorrect;

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
        if(!Triggered)
        {


            if(coltimer > 0)
                {
                    coltimer -= Time.deltaTime;
                }
        
            else
                {
                    Triggered = true;
                    string itemName = other.transform.parent.gameObject.name.Replace("(Clone)","");

                    if(other.GetComponent<CustomTag>().HasTag("Glass"))
                    {
                        isCorrect = true;
                        DecidedMessage = "CorrectMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("Chem"))
                    {
                        // Instantiate(ChemMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "ChemMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("GFT") || other.GetComponent<CustomTag>().HasTag("Paper") || other.GetComponent<CustomTag>().HasTag("PMD") || other.GetComponent<CustomTag>().HasTag("Electronics") || other.GetComponent<CustomTag>().HasTag("Wet") || other.GetComponent<CustomTag>().HasTag("Dirty") || other.GetComponent<CustomTag>().HasTag("NotCompostable") || other.GetComponent<CustomTag>().HasTag("PlasticLining"))
                    {
                        // Instantiate(RecOtherBinMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "RecOtherBinMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("General"))
                    {
                        //Instantiate(NonRecMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "NonRecMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("NoFood"))
                    {
                        //Instantiate(NoFoodMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "NoFoodMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("Deposit"))
                    {
                        //Instantiate(DepositMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "DepositMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("PlateGlass"))
                    {
                        //Instantiate(PlateMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "PlateMessage";
                    }
                    else if(other.GetComponent<CustomTag>().HasTag("Propellant"))
                    {
                        //Instantiate(NoRipMessage, new Vector3(0,0,0), Quaternion.identity);
                        isCorrect = false;
                        DecidedMessage = "PropMessage";
                    }


                    ScriptContainer.GetComponent<GoodBad>().putInBin(itemName, "Glass", isCorrect, sprinkles, DecidedMessage);
                    
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

    }

}
