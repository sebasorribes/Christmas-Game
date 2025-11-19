using UnityEngine;
using UnityEngine.InputSystem;


public class CameraManager : MonoBehaviour
{
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag = false;
    void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }
    void LateUpdate()
    {

        if (Mouse.current.leftButton.isPressed)
        {
            Diference = (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue())) - Camera.main.transform.position;
            if (Drag == false)
            {
                Drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            }
        }
        else
        {
            Drag = false;
        }
        if (Drag == true)
        {
            Camera.main.transform.position = Origin - Diference;
        }
        if (Mouse.current.rightButton.isPressed)
        {
            Camera.main.transform.position = ResetCamera;
        }
    }
}
