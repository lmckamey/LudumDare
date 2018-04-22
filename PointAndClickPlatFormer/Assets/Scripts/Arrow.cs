using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float m_Speed;
    void Update()
    {
        Vector3 velocty = Vector3.left;
        velocty = velocty * m_Speed * 0.1f;
        transform.position += velocty;
    }
}
