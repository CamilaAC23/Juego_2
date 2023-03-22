using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{

    [SerializeField]
    private Color activeColor;
    [SerializeField]
    private Color inactiveColor;
    [SerializeField]
    private Material material;
    private bool activated;



    public override void Interact()
    {
        //invoca a la funcion padre Interactable
        base.Interact();
        // Destroy(gameObject);
        activated = !activated;
        if (activated)
        {
            material.color = activeColor;
            
        }
        else
        {
            material.color = inactiveColor;
        }
    }
}





