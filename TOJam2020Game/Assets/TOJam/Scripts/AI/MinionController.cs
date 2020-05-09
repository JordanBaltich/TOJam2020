using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : MonoBehaviour
{
    Rigidbody m_Body;
    Animator m_StateMachine;
    Health m_Health;
    public NavMeshAgent m_Agent;
    public MinionData m_Data;

    [Header("Movement")]
    public Transform MoveTarget;
    [SerializeField] string moveTargetTag = "MoveTarget";

    [SerializeField] MeshRenderer playerBody;
    Shader OutlineShader;

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody>();
        m_StateMachine = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
        m_Health = GetComponent<Health>();
    }

    private void Start()
    {
       MoveTarget = GameObject.FindGameObjectWithTag(moveTargetTag).transform;

        m_Health.FindUnitType();

        m_Agent.speed = m_Data.moveSpeed;
        m_Data.currentHealth = m_Data.maxHealth;
        m_Data.isSelected = false;
    }

    private void Update()
    {
        if (m_Data.isSelected)
        {
            Vector3 Destination = new Vector3(MoveTarget.position.x, transform.position.y, MoveTarget.position.z);
            m_Agent.SetDestination(MoveTarget.position);
            playerBody.material.SetFloat("_OutlineWidth", 0.1f);
        }
        else
        {
            playerBody.material.SetFloat("_OutlineWidth", 0.0f);
        }
    }
}
