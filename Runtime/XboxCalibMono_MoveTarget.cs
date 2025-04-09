using System;
using UnityEngine;
using UnityEngine.Events;

public class XboxCalibMono_MoveTarget : MonoBehaviour
{
    public Transform m_whatToMove;
    [Range(-1,1)]
    public float m_moveLeftToRight;
    [Range(-1, 1)]
    public float m_moveBackToFront;
    [Range(-1, 1)]
    public float m_rotateLeftToRight;
    [Range(-1, 1)]
    public float m_moveDownToUp;

    public float m_rotationSpeed = 20;
    public float m_moveSpeed = 0.5f;
    public float m_multiplicator=1;

    public UnityEvent m_onSaveRequest;
    public UnityEvent m_onLoadRequest;

    public void Update()
    {       
        m_whatToMove.Translate(new Vector3(m_moveLeftToRight,m_moveDownToUp, m_moveBackToFront)* m_multiplicator * m_moveSpeed * Time.deltaTime);
        m_whatToMove.Rotate(new Vector3(0, m_rotateLeftToRight, 0) * m_multiplicator * m_rotationSpeed * Time.deltaTime);
    }

    [ContextMenu("Load Request")]
    public void LoadRequest()
    {
        m_onLoadRequest.Invoke();
    }

    [ContextMenu("Save Request")]
    public void SaveRequest()
    {
        m_onSaveRequest.Invoke();
    }
}
