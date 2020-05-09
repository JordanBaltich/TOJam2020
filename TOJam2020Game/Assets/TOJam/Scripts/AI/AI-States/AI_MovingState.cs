﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_MovingState : StateMachineBehaviour
{
    AI_Vision m_Vision;
    AIMinionController m_Controller;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Vision = animator.GetComponentInChildren<AI_Vision>();
        m_Controller = animator.GetComponent<AIMinionController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceToTarget = Vector3.Distance(m_Controller.m_Agent.destination, animator.transform.position);

        //check if hostile unit walks into vision
        if (m_Vision.CheckForPlayerUnits() != Vector3.zero)
        {
            m_Controller.m_Agent.SetDestination(m_Vision.CheckForPlayerUnits());
        }

        if (m_Vision.currentTarget.gameObject.tag == m_Vision.aIControlTag)
        {
            m_Controller.m_Agent.destination = animator.transform.position;
            animator.SetBool("TargetFound?", false);
        }

        //check if target is reached
        if (distanceToTarget < 2)
        {
            m_Controller.m_Agent.destination = animator.transform.position;
            animator.SetBool("TargetFound?", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
