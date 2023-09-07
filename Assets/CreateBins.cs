using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CreateBins : MonoBehaviour
{
    public GameObject bins;

    // Start is called before the first frame update
    void Start()
    {
       var instance = Instantiate(bins, new Vector3(0,0,2), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
