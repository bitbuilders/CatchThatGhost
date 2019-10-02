using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skipp : MonoBehaviour
{
    [SerializeField] GhostlyController m_controller = null;

    void Update()
    {
        m_controller.AddInput(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
}
