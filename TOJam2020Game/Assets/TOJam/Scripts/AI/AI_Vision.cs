using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Vision : MonoBehaviour
{
    [SerializeField] Transform ControlPointsHolder;
    [SerializeField] string controlPointHolderName = "ControlsPointsHolder";
    [SerializeField] LayerMask playerUnitsMask;
    public string aIControlTag = "AIControl";
    public string playerControlTag = "PlayerControl";

    public List<Transform> controlPoints;

    [SerializeField] bool noPlayerMinionInSight = true;
    float controlPointDistance;

    public GameObject currentTarget;

    private void Awake()
    {
        if (ControlPointsHolder == null)
        {
            ControlPointsHolder = GameObject.Find(controlPointHolderName).transform;
        }
        else
        {
            foreach (Transform t in ControlPointsHolder.GetComponentInChildren<Transform>())
            {
                controlPoints.Add(t);
            }
        }
    }

    public Vector3 FindNextDestination(Vector3 Origin)
    {
        Vector3 destination = Origin;

        if (noPlayerMinionInSight)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                if (i == 0)
                {
                    if (controlPoints[i].gameObject.tag == playerControlTag)
                    {
                        controlPointDistance = Vector3.Distance(Origin, controlPoints[i].position);
                        destination = controlPoints[i].position;
                        currentTarget = controlPoints[i].gameObject;
                    }
                }
                else
                {
                    if (controlPoints[i].gameObject.tag == playerControlTag)
                    {
                        if (Vector3.Distance(Origin, controlPoints[i].position) < controlPointDistance)
                        {
                            controlPointDistance = Vector3.Distance(Origin, controlPoints[i].position);
                            destination = controlPoints[i].position;
                            currentTarget = controlPoints[i].gameObject;
                        }
                    }
                       
                }
            }
        }

        return destination;
    }


    public Vector3 CheckForPlayerUnits()
    {
        if (!noPlayerMinionInSight)
        {
            return currentTarget.transform.position;
        }
        else return Vector3.zero;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((playerUnitsMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            if (noPlayerMinionInSight)
            {
                currentTarget = other.gameObject;
                noPlayerMinionInSight = false;
            }
        }
    }
}
