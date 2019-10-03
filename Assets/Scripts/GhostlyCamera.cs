using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostlyCamera : MonoBehaviour
{
    [SerializeField] GameObject m_trackee = null;

    void LateUpdate()
    {
        transform.position = m_trackee.transform.position + Vector3.back * 10.0f;
    }
}
