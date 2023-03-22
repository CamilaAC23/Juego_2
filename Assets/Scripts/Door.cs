using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    //private Vector3 StartRotation;
    //private Vector3 StartPosition;
    //private Vector3 Forward;
    //private Vector3 StopRotation;
    //private float RotationAmount = 90f;
    //public bool State = true;
    //private void Awake()
    //{
    //    StartRotation = transform.rotation.eulerAngles;
       
    //}
   
    public override void Interact()
    {

            Vector3 vec = transform.rotation.eulerAngles;
            Debug.Log(vec);


       
        
            base.Interact();
            transform.Rotate(Vector3.up * 90);
            Debug.Log("Door Open");


       




    }
}
