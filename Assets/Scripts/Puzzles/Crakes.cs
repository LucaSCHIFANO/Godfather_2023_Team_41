using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crakes : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject crake1;
    [SerializeField] GameObject crake2;

    [Header("Values")]
    [SerializeField] float speed;
    [SerializeField] Vector2 randomStartPosition;
    [SerializeField] Vector2 limits;

    private float value1;
    private float value2;

    private void Awake()
    {
        crake1.transform.Translate(0, Random.Range(randomStartPosition.x, randomStartPosition.y), 0);
        crake2.transform.Translate(0, Random.Range(randomStartPosition.x, randomStartPosition.y), 0);
    }

    private void Update()
    {

        if (value1 < 0)
        {
            crake1.transform.Translate(0, -1 * speed, 0);
            ClampY(crake1);
        }
        else if(value1 > 0) 
        {
            crake1.transform.Translate(0, 1 * speed, 0);
            ClampY(crake1);
        }

        if (value2 < 0)
        { 
            crake2.transform.Translate(0, -1 * speed, 0); 
            ClampY(crake2);
        }
        else if (value2 > 0) 
        {
            crake2.transform.Translate(0, 1 * speed, 0); 
            ClampY(crake2);
        }


    }

    void ClampY(GameObject crake)
    {
        Vector3 pos = crake.transform.position;
        float crakeClamp = Mathf.Clamp(pos.y, limits.x, limits.y);
        crake.transform.position = new Vector3(pos.x, crakeClamp, pos.z);
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
