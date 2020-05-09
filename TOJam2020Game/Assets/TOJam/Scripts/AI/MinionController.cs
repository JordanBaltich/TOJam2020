using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : MonoBehaviour
{
    Rigidbody m_Body;
    Animator m_StateMachine;
    public NavMeshAgent m_Agent;
    public MinionData m_Data;

    [Header("Movement")]
    public Transform MoveTarget;
    [SerializeField] string moveTargetTag = "MoveTarget";

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody>();
        m_StateMachine = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
       MoveTarget = GameObject.FindGameObjectWithTag(moveTargetTag).transform;
    }

    private void Update()
    {
        if (m_Data.isSelected)
        {
            Vector3 Destination = new Vector3(MoveTarget.position.x, transform.position.y, MoveTarget.position.z);
            m_Agent.SetDestination(MoveTarget.position);
        }       
    }
}
