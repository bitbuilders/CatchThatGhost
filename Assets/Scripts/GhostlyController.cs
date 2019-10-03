using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostlyController : MonoBehaviour
{
    [SerializeField] Rigidbody2D m_rigidbody = null;

    [SerializeField] Animator m_animator = null;

    [Tooltip("How much force can be applied to the Rigidbody when at top speed")]
    [SerializeField, Range(0.0f, 200.0f)] float m_maxForce = 100.0f;

    [Tooltip("How fast will you reach top speed? (1.0 = 1 second, 2.0 = 0.5 seconds)")]
    [SerializeField, Range(0.0f, 20.0f)] float m_acceleration = 3.0f;

    [Tooltip("How fast is considered walking at regular speed?")]
    [SerializeField, Range(0.0f, 20.0f)] float m_walkThreshold = 5.1f;

    Vector2 m_force = Vector2.zero;
    Vector2 m_input = Vector2.zero;

    public void AddInput(Vector2 input)
    {
        m_input = input;
    }

    void Update()
    {
        bool walking = m_force.sqrMagnitude > 5.0f;
        m_animator.SetBool("Walking", walking);
        m_animator.SetFloat("WalkSpeed", m_rigidbody.velocity.sqrMagnitude / (m_walkThreshold * m_walkThreshold));

        if (walking)
        {
            Vector2 dir = m_force.normalized;
            m_animator.SetFloat("xDir", dir.x);
            m_animator.SetFloat("yDir", dir.y);
        }
    }

    private void FixedUpdate()
    {
        if (m_input.sqrMagnitude > 0.0f)
        {
            m_force += m_input * (m_maxForce * m_acceleration) * Time.deltaTime;
        }
        else
        {
            m_force = m_rigidbody.velocity;
        }

        if (m_force.sqrMagnitude > m_maxForce * m_maxForce)
        {
            m_force = m_force.normalized * m_maxForce;
        }

        m_rigidbody.AddForce(m_force, ForceMode2D.Force);
    }
}
