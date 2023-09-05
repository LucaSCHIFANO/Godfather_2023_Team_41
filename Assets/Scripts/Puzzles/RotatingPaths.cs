using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotatingPaths : MonoBehaviour
{
    [SerializeField] GameObject wheel1;
    [SerializeField] GameObject wheel2;
    [SerializeField] float speed;
    [SerializeField] Vector2 randomStartPosition;

    private void Awake()
    {
        float value = Random.Range(randomStartPosition.x, randomStartPosition.y);
        wheel1.transform.Rotate(0, -value * speed, 0);
        wheel2.transform.Rotate(0, value * speed, 0);
    }

    public void MovementInput(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
          
        if (value < 0)
        {
            wheel1.transform.Rotate(0, -value * speed, 0);
            wheel2.transform.Rotate(0, value * speed, 0);
        }
        else if(value > 0)
        {
            wheel1.transform.Rotate(0, -value * speed, 0);
            wheel2.transform.Rotate(0, value * speed, 0);
        }
    }
}
