using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_IdleState : StateMachineBehaviour
{
    AI_Vision m_Vision;
    AIMinionController m_Controller;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Vision = animator.GetComponentInChildren<AI_Vision>();
        m_Controller = animator.GetComponent<AIMinionController>();

        if (m_Vision.CheckForPlayerUnits() != Vector3.zero)
        {
            m_Controller.m_Agent.speed = m_Controller.m_Data.moveSpeed;
            m_Controller.m_Agent.SetDestination(m_Vision.CheckForPlayerUnits());
            animator.SetBool("TargetFound?", true);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Controller.m_Agent.speed = m_Controller.m_Data.moveSpeed;
        m_Controller.m_Agent.SetDestination(m_Vision.FindNextDestination(animator.transform.position));

        if (m_Vision.currentTarget != null)
        {
            animator.SetBool("TargetFound?", true);
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
