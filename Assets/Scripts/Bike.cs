using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bike : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    [SerializeField] Animator anim;
    private Rigidbody rb;
    [SerializeField] Slider movementSlider;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        anim.SetFloat("Blend", movementSlider.value);
        MoveCycle();
        TurnCycle();
    }
    void MoveCycle()
    {
        rb.velocity = new Vector3(movementSlider.value,0,0) + this.transform.forward  * speed;
    }
    void TurnCycle()
    {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, movementSlider.value);
    }

}
