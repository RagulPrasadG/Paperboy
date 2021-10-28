using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperThrow : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] GameObject paperPrefab;
    [SerializeField] float speed;
    [SerializeField] Transform parent;

     Transform target;

    Animator anim;
    private void Start()
    {
        this.transform.parent = parent;
        anim = GetComponent<Animator>();
    }

    public void Throw()
    {
        if (target != null)
        {
            hand.transform.LookAt(target);
            GameObject paper = Instantiate(paperPrefab, hand.transform.position, Quaternion.identity);
            paper.GetComponent<Rigidbody>().AddForce(speed * hand.transform.forward, ForceMode.Impulse);
            target = null;
        }
    }
    public void ThrowAnimation()
    {
       if(target !=  null) anim.Play("Throw");
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mailbox")
        {
            target = other.transform.GetChild(0);
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if (other.gameObject.tag == "Mailbox")
        {
            target = null;
        }
    }

}
