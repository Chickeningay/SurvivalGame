﻿using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class Rotation : MonoBehaviour
{
    public float currentDirection;
    public float currentWeaponBounce;
    public float currentWeaponBounce2;
    public bool stopgoingdown;
    public bool activatebounce; bool clock = false;
    bool firstshot = false;
    public bool weaponbounce;
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;
    public bool syncX;
    public bool syncY;

    public GameObject CommandTaker;

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            if (CommandTaker.active)
            {
                rotationX = 0;
            }
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            if (CommandTaker.active)
            {
                rotationY = 0;
            }
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            float X = Input.GetAxis("Mouse X") * sensitivityX;
            if (CommandTaker.active)
            {
                X = 0;
            }
            transform.Rotate(0,X , 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            if (CommandTaker.active)
            {
                rotationY = 0;
            }
            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
        if (!CommandTaker.active)
        {
            if (Input.GetKey(KeyCode.A))
            {
                currentDirection = 5;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                currentDirection = -5;
            }
            else
            {
                currentDirection = 0;
            }
        }
        else if (CommandTaker.active)
        { currentDirection = 0; }
       
        if (activatebounce) { increaseBounce();
         activatebounce = false;
     }


        if (!syncX)
        {
            if (!stopgoingdown && weaponbounce)
            {

                float savedangle = gameObject.transform.eulerAngles.x;


                gameObject.transform.eulerAngles = new Vector3((Mathf.LerpAngle(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.x - currentWeaponBounce, Time.deltaTime)), gameObject.transform.eulerAngles.y, Mathf.LerpAngle(transform.eulerAngles.z, currentDirection, Time.deltaTime));

                currentWeaponBounce = Mathf.Lerp(currentWeaponBounce, 0, Time.deltaTime);




            }
            else if (!stopgoingdown && !weaponbounce)
            {
                float savedangle2 = gameObject.transform.eulerAngles.y;

                gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, (Mathf.LerpAngle(gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.y - currentWeaponBounce2, Time.deltaTime)), Mathf.LerpAngle(transform.eulerAngles.z, currentDirection, Time.deltaTime));

                currentWeaponBounce2 = Mathf.Lerp(currentWeaponBounce2, 0, Time.deltaTime);

            }
        }
     
     if (stopgoingdown)
     {

     }

     stopgoingdown = false;
        if (syncX)
        {
            gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, 0, gameObject.transform.localEulerAngles.z);
        }
      
    }
    public void increaseBounce()
    {


        currentWeaponBounce += 20   ;
        if (firstshot)
        {
            currentWeaponBounce2 += 5;

            firstshot = false;
        }
        else if (clock)
        {
            currentWeaponBounce2 += 10;
            clock = !clock;
        }
        else if (!clock)
        {
            currentWeaponBounce2 -= 10;
            clock = !clock;
        }
       if (!weaponbounce)
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, Mathf.LerpAngle(gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.y + 10, Time.deltaTime), transform.eulerAngles.z);
        }
        if (weaponbounce)
        {
            gameObject.transform.eulerAngles = new Vector3(Mathf.LerpAngle(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.x + 100, Time.deltaTime), Mathf.LerpAngle(gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.y + 10, Time.deltaTime), transform.eulerAngles.z);
        }
    
    
       
        stopgoingdown = true;
    }
    void Start()
    {
        Cursor.visible = false;
        //if(!networkView.isMine)
        //enabled = false;

        // Make the rigid body not change rotation
        //if (rigidbody)
        //rigidbody.freezeRotation = true;
    }
}