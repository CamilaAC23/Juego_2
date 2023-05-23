using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : Interactable
{
    //public ScoreDisplay scoreDisplay;
    public override void Interact()
    {
        base.Interact();
        Destroy(gameObject);
        //scoreDisplay.IncrementDestroyedObjects();


    }
}
