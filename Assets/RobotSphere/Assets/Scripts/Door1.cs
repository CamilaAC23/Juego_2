using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Door1 : Interactable
{
    public Transform Objeto;
   // public Transform objetivoRotacion;

    public float velocidadRotacion = 40.0f;
    public Vector3 rotacionObjetivo = new Vector3(0, -90, 0); // Rotación objetivo en grados

    private Quaternion rotacionInicial; // Rotación inicial del objeto
    private Quaternion rotacionFinal; // Rotación objetivo del objeto
    private bool rotando = false; // Variable para controlar si se está rotando el objeto

    private void Start()
    {
        rotacionInicial = transform.rotation;
        rotacionFinal = Quaternion.Euler(rotacionObjetivo);
    }

    public override void Interact()
    {
        base.Interact();

        if (!rotando)
        {
            rotando = true;
        }

    }

    private void Update()
    {
        if (rotando)
        {
            Objeto.transform.rotation = Quaternion.Lerp(rotacionInicial, rotacionFinal, velocidadRotacion * Time.deltaTime);

            if (Objeto.transform.rotation == rotacionFinal)
            {
                rotando = false;
            }
        }
    }


    //public override void Interact()
    //{
    //    base.Interact();

    //    if (Objeto.rotation != objetivoRotacion.rotation)
    //    {
    //        Objeto.transform.Rotate(Vector3.up * -90);
    //        Debug.Log("Igual");
    //    }

    //}

}
