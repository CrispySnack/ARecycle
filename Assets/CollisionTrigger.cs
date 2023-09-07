using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CollisionTest : MonoBehaviour
{
    public GameObject goodmssg;
    public GameObject wrongmssg;
    public bool IsColliding = false;
    public float coltimer = 3;
    public bool IsCorrect = false;
    public bool IsWrong = false;


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

                    if(other.tag == "GFT")
                    {
                        IsCorrect = true;
                        Instantiate(goodmssg, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.tag == "PMD")
                    {
                        IsWrong = true;
                        Instantiate(wrongmssg, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.tag == "Papier")
                    {
                        IsWrong = true;
                        Instantiate(wrongmssg, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.tag == "Rest")
                    {
                        IsWrong = true;
                        Instantiate(wrongmssg, new Vector3(0,0,0), Quaternion.identity);
                    }
                    else if(other.tag == "Inlever")
                    {
                        IsWrong = true;
                        Instantiate(wrongmssg, new Vector3(0,0,0), Quaternion.identity);
                    }
                }

    }

    void OnTriggerExit(Collider other)
    {
        coltimer = 3;
        IsCorrect = false;
        IsWrong = false;

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
