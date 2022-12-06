using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Followorld : MonoBehaviour
{
    [SerializeField]
    private Transform lookAt;

    [SerializeField]
    private Vector3 offSet;

    // Update is called once per frame
    void Update()
    {
        if(lookAt != null)
        {
            Vector3 pos = lookAt.position + offSet;
            if (transform.position != pos)
                transform.position = pos;
        }
    }

}
