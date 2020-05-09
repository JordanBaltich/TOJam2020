using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_IdleState : StateMachineBehaviour
{
    AI_Vision m_Vision;
    AIMinionController m_Controller;

    Vector3 direction;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Vision = animator.GetComponentInChildren<AI_Vision>();
        m_Controller = animator.GetComponent<AIMinionController>();

        m_Controller.m_Agent.speed = m_Controller.m_Data.moveSpeed;

        if (m_Vision.CheckForPlayerUnits() != Vector3.zero)
        {
            m_Controller.m_Agent.speed = m_Controller.m_Data.moveSpeed;
            m_Controller.m_Agent.SetDestination(m_Vision.CheckForPlayerUnits());
            animator.SetBool("TargetFound?", true);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (m_Vision.FindNextDestination(animator.transform.position) != animator.transform.position)
        {
            m_Controller.m_Agent.SetDestination(m_Vision.FindNextDestination(animator.transform.position));
        }
        else
        {
            RaycastHit hitInfo;
            direction = m_Controller.forwardTarget.position - animator.transform.position;
            Debug.Log(direction.normalized);

            if (Physics.Raycast(animator.transform.position, direction.normalized, out hitInfo, 5f, LayerMask.GetMask("Ground")))
            {
                float angle = Vector3.Angle(animator.transform.position, hitInfo.point);
                Debug.Log(angle);

                if (angle > 0)
                {
                    animator.transform.rotation = Quaternion.RotateTowards(animator.transform.rotation, animator.transform.rotation * Quaternion.Euler(Vector3.up * 5), Time.deltaTime);
                }
                else
                {
                    animator.transform.rotation = Quaternion.RotateTowards(animator.transform.rotation, animator.transform.rotation * Quaternion.Euler(Vector3.up * -5), Time.deltaTime);
                }
            }
            
                m_Controller.m_Agent.SetDestination(m_Controller.forwardTarget.position);
        }
       
        if (m_Vision.currentTarget != null)
        {
            animator.SetBool("TargetFound?", true);
        }
      
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
