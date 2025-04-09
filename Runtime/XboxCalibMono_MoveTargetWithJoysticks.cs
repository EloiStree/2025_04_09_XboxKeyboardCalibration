using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class XboxCalibMono_MoveTargetWithJoysticks : MonoBehaviour
{
    public XboxCalibMono_MoveTarget m_toAffect;

    public InputActionReference m_joystickLeft;
    public InputActionReference m_joystickRight;
    public InputActionReference m_joystickAddSpeed;
    public InputActionReference m_joystickRemoveSpeed;
    public InputActionReference m_saveRequest;
    public InputActionReference m_loadRequest;
    public float m_speedIncrementation = 0.05f;

    public bool m_addingPress;
    public bool m_removePress;

    public void OnEnable()
    {
        m_joystickLeft.action.Enable();
        m_joystickRight.action.Enable();
        m_joystickAddSpeed.action.Enable();
        m_joystickRemoveSpeed.action.Enable();
        m_saveRequest.action.Enable();
        m_loadRequest.action.Enable();
        m_joystickAddSpeed.action.performed += OnAddSpeed;
        m_joystickAddSpeed.action.canceled += OnAddSpeed;
        m_joystickRemoveSpeed.action.performed += OnRemoveSpeed;
        m_joystickRemoveSpeed.action.canceled += OnRemoveSpeed;
        m_joystickLeft.action.performed += OnJoystickLeft;
        m_joystickLeft.action.canceled += OnJoystickLeft;
        m_joystickRight.action.performed += OnJoystickRight;
        m_joystickRight.action.canceled += OnJoystickRight;

        m_loadRequest.action.performed += OnSaveRequest;
        m_loadRequest.action.canceled += OnSaveRequest;
        m_saveRequest.action.performed += OnLoadRequest;
        m_saveRequest.action.canceled += OnLoadRequest;
    }

    private void OnLoadRequest(InputAction.CallbackContext context)
    {
        bool isPressed = context.ReadValue<float>() > 0.5f;
        if (isPressed != m_addingPress)
        {
            if (isPressed)
                m_toAffect.LoadRequest();
        }
    }

    private void OnSaveRequest(InputAction.CallbackContext context)
    {

        bool isPressed = context.ReadValue<float>() > 0.5f;
        if (isPressed != m_addingPress)
        {
            if (isPressed)
                m_toAffect.SaveRequest();
        }
    }

    public void OnDisable()
    {

        m_joystickAddSpeed.action.performed -= OnAddSpeed;
        m_joystickAddSpeed.action.canceled -= OnAddSpeed;
        m_joystickRemoveSpeed.action.performed -= OnRemoveSpeed;
        m_joystickRemoveSpeed.action.canceled -= OnRemoveSpeed;
        m_joystickLeft.action.performed -= OnJoystickLeft;
        m_joystickLeft.action.canceled -= OnJoystickLeft;
        m_joystickRight.action.performed -= OnJoystickRight;
        m_joystickRight.action.canceled -= OnJoystickRight;
        m_saveRequest.action.performed -= OnSaveRequest;
        m_saveRequest.action.canceled -= OnSaveRequest;
        m_loadRequest.action.performed -= OnLoadRequest;
        m_loadRequest.action.canceled -= OnLoadRequest;
    }
    private void OnJoystickRight(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        m_toAffect.m_moveLeftToRight = value.x;
        m_toAffect.m_moveBackToFront = value.y;
    }

    private void OnJoystickLeft(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        m_toAffect.m_rotateLeftToRight = value.x;
        m_toAffect.m_moveDownToUp = value.y;
    }

    private void OnRemoveSpeed(InputAction.CallbackContext context)
    {
        bool isPressed = context.ReadValue<float>() > 0.5f;
        if(isPressed != m_removePress)
        {
            if(isPressed)
        m_toAffect.m_moveSpeed -= m_speedIncrementation;
        }
    }

    private void OnAddSpeed(InputAction.CallbackContext context)
    {
        bool isPressed = context.ReadValue<float>() > 0.5f;
        if (isPressed != m_addingPress)
        {
            if (isPressed)
                m_toAffect.m_moveSpeed += m_speedIncrementation;
        }
    }
}
