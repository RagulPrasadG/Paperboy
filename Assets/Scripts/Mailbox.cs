
using UnityEngine;
using DG.Tweening;
public class Mailbox : MonoBehaviour
{
    [SerializeField] ParticleSystem paperBurst;
    [SerializeField] GameObject pointerArrow;
    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Paper")
        {
            this.gameObject.tag = "Untagged";
            pointerArrow.SetActive(false);
            paperBurst.Play();
            AudioManager.instance.PaperCrashSound();
            Destroy(other.gameObject);         
            transform.DOPunchRotation(transform.forward * 25f, 2f, 10, 1);
        }     
    }

}
