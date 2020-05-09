using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMinionController : MonoBehaviour
{
    Rigidbody m_Body;
    Animator m_StateMachine;
    public NavMeshAgent m_Agent;
    public MinionData m_Data;

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody>();
        m_StateMachine = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}
