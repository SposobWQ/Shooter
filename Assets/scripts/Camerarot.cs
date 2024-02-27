using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerarot : MonoBehaviour
{
    [SerializeField] private float maxangle;
    [SerializeField] private float minangle;
    [SerializeField] private Transform CamRotAxisTrans;
    [SerializeField] private float RotSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y+Time.deltaTime*RotSpeed*Input.GetAxis("Mouse X"), 0);
        var newAxisX = CamRotAxisTrans.localEulerAngles.x - Time.deltaTime * RotSpeed * Input.GetAxis("Mouse Y");
        if (newAxisX>180) 
        {
            newAxisX -= 360;
        }
        newAxisX = Mathf.Clamp(newAxisX, minangle, maxangle);

        CamRotAxisTrans.localEulerAngles = new Vector3(newAxisX, 0, 0);
    }
}
