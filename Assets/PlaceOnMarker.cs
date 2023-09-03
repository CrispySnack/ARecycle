using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnMarker : MonoBehaviour
{

    
    GameObject binPos;
    GameObject bins;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        binPos = GameObject.Find("binposition");
    if (binPos)
        {
    pos = binPos.transform.position;
    bins.transform.position = pos;
        }

        

    }
}
