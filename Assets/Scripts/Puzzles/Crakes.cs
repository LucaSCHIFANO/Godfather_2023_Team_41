using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crakes : MonoBehaviour
{
    [SerializeField] GameObject crake1;
    [SerializeField] GameObject crake2;
    [SerializeField] float speed;

    private float value1;
    private float value2;

    private void Update()
    {

        if (value1 < 0) crake1.transform.Translate(0, -1 * speed, 0);
        else if (value1 > 0) crake1.transform.Translate(0, 1 * speed, 0);

        if (value2 < 0) crake2.transform.Translate(0, -1 * speed, 0);
        else if (value2 > 0) crake2.transform.Translate(0, 1 * speed, 0);
        
    }

    public void LeverLeftInput(InputAction.CallbackContext context)
    {
        if (crake1 == null) return;

        value1 = context.ReadValue<float>();
    }

    public void LeverRightInput(InputAction.CallbackContext context)
    {
        if (crake2 == null) return;

        value2 = context.ReadValue<float>();

    }
}
