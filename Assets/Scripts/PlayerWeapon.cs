using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] ParticleSystem[] Lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        ProcessFiring();
        MoveCrossHair();
        MoveTargetPoint();
        AimLasers();
        if(Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    void ProcessFiring()
    {
        foreach (ParticleSystem Laser in Lasers)
        {
            var emmissionModule = Laser.emission;
            emmissionModule.enabled = isFiring; 
        }
        
    }
    void MoveCrossHair()
    {
        crosshair.position = Input.mousePosition;
        Camera.main.ScreenToWorldPoint(crosshair.position);
    }
    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLasers()
    {
        foreach (ParticleSystem laser in Lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position; // b - a - return Vector between
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);//Return the rotation calculated from the Vector to our target point
            laser.transform.rotation = rotationToTarget;
        }
    }
}
