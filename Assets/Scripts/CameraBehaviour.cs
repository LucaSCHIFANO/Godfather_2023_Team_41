using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public static CameraBehaviour _instance;

    [SerializeField] private float _cameraSpeed;
    public float _cameraSpeedModifier;
    [SerializeField] private float _cameraSlowModifier;
    [SerializeField] private float _cameraMinSpeed;
    [SerializeField] private float _cameraMaxSpeed;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Update()
    {
        _cameraSpeed += Time.deltaTime / 40;
        _cameraSpeed = Mathf.Clamp(_cameraSpeed, _cameraMinSpeed, _cameraMaxSpeed);

        transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 4 * _cameraSpeed / _cameraSlowModifier * _cameraSpeedModifier;
    }
}
