using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logica_personaje : MonoBehaviour
{
    public float velocidad = 0.0f;
    public float aceleracion = 0.1f;
    public float desaceleracion = 0.5f;

    Animator anim;
    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool moverseoprimido = Input.GetKey("w");
        bool saltaroprimido = Input.GetKey("space");

        if(moverseoprimido && velocidad < 1.0f)
        {
            velocidad += Time.deltaTime * aceleracion;
        }
        if (!moverseoprimido && velocidad > 0.0f)
        {
            velocidad -= Time.deltaTime * desaceleracion;
        }
        if (!moverseoprimido && velocidad < 0.0f)
        {
            velocidad = 0.0f;
        }
        if (saltaroprimido)
        {
            anim.SetBool("saltar", true);
        }
        if (!saltaroprimido)
        {
            anim.SetBool("saltar", false);
        }

        anim.SetFloat("velocidad",velocidad);

    }
}
