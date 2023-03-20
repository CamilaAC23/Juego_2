using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objetivo;
    NavMeshAgent agente;
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(objetivo.position);
        //agente.Warp(objetivo.position);

    }
}
