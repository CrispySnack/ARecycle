using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnInTrigger : MonoBehaviour
{
    public GameObject CorrectMessage;

    public float coltimer = 3;


    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {

    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
            if(coltimer > 0)
                {
                    coltimer -= Time.deltaTime;
                }
        
            else
                {
                    coltimer = 0;

                    if(other.GetComponent<CustomTag>().HasTag("Chem") || other.GetComponent<CustomTag>().HasTag("Deposit") || other.GetComponent<CustomTag>().HasTag("PlateGlass") || other.GetComponent<CustomTag>().HasTag("Propellant"))
                    {
                        Instantiate(CorrectMessage, new Vector3(0,0,0), Quaternion.identity);
                    }
                }

    }

    void OnTriggerExit(Collider other)
    {
        coltimer = 3;
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
