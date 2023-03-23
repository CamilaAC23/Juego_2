using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public new GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        light.GetComponent<Light>().enabled = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        light.GetComponent<Light>().enabled = true;

    }

    private void OnTriggerExit(Collider other)
    {
        light.GetComponent<Light>().enabled = false;

    }


    //    // Update is called once per frame
    //    void Update()
    //    {

    //    }
}
