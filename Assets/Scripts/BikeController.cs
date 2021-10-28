using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BikeController : MonoBehaviour
{
    [SerializeField] WheelCollider frontWheelColldier;
    [SerializeField] WheelCollider backWheelCollider;

    [SerializeField] Transform frontWheelTransform;
    [SerializeField] Transform backWheelTransform;

    [SerializeField] Transform pedalTransform;


    [SerializeField] float maxTorque;
    [SerializeField] float turnRadius;
    [SerializeField] float maxRpm;
    [SerializeField] Slider movementSlider;

    [SerializeField] Animator anim;
    private void Start()
    {
        maxRpm = GameManager.speed;
        turnRadius = GameManager.turn;
        this.GetComponent<Rigidbody>().centerOfMass = Vector2.zero;
    }
    private void Update()
    {
       SetBikeSteering();
      
       SetWheelTransform(frontWheelColldier, frontWheelTransform);
       SetWheelTransform(backWheelCollider, backWheelTransform);
    }


    private void SetBikeSteering()
    {
        anim.SetFloat("Blend", movementSlider.value);
        backWheelCollider.motorTorque = maxTorque;
        frontWheelColldier.steerAngle = movementSlider.value * turnRadius;
      
        if (backWheelCollider.rpm > maxRpm)
        {
            backWheelCollider.motorTorque = 0;
        }

       
    }
    private void SetWheelTransform(WheelCollider wheelCollider,Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
        pedalTransform.rotation = rot;
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bounds")
        {
            GameManager.instance.GameOver();
        }

    }


}
