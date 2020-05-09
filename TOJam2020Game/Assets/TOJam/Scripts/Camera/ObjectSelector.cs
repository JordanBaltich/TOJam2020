using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public LayerMask SelectableObjects;
    public Transform Pointer;
    [SerializeField] int GroundLayerID,pUnitLayerID;

    [SerializeField]List<GameObject> SelectedUnits;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (CheckIfSelectable(hitInfo.collider.gameObject.layer))
                {
                    Debug.Log("It's working!");
                    if (hitInfo.collider.gameObject.layer == GroundLayerID)
                    {
                        Pointer.position = hitInfo.point;
                    }
                    if (hitInfo.collider.gameObject.layer == pUnitLayerID)
                    {
                        if (!hitInfo.collider.GetComponent<MinionController>().m_Data.isSelected)
                        {
                            hitInfo.collider.GetComponent<MinionController>().m_Data.isSelected = true;
                            SelectedUnits.Add(hitInfo.collider.gameObject);
                            Pointer.position = hitInfo.point;
                        }
                    }
                }
                else
                {
                    Debug.Log("nopz");
                }
            }
            else
            {
                Debug.Log("No hit");
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            foreach (GameObject obj in SelectedUnits)
            {
                obj.GetComponent<MinionController>().m_Data.isSelected = false;
                SelectedUnits.Remove(obj);
            }
        }
    }

    bool CheckIfSelectable(int layer)
    {

        if ((SelectableObjects & 1 << layer) == 1 << layer)
        {
            return true;
        }
        else return false;

    }
}
