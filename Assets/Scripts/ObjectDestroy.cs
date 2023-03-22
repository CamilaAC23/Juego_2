using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : Interactable
{
    public override void Interact()
    {
        base.Interact();
        Destroy(gameObject);

    }
}
