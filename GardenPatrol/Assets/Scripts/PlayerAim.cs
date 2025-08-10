using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerAim : MonoBehaviour
{
    public event EventHandler<onShootEventArgs> OnShoot;
    public class onShootEventArgs : EventArgs{
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }

    public Transform aimTransform;
    public Transform aimGunPoint;
    

    private void Update()
    {
        Aiming();
        Shooting();
    }

    private void Aiming(){
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
    }

    public void Shooting(){
        Vector3 mousePosition = GetMouseWorldPosition();

        if(Input.GetMouseButtonDown(0)){
            OnShoot?.Invoke(this, new onShootEventArgs{
                gunEndPointPosition=aimGunPoint.position,
                shootPosition=mousePosition,
                
            });

            

        }

    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
