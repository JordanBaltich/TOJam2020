using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRaycastScriptTest : MonoBehaviour
{

    int layerMask = 1 << 8; //[8] is the index of player-unit index

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log(hit.collider.gameObject.layer);

            }
        }
    }

}
