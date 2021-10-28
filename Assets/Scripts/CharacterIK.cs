using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIK : MonoBehaviour
{
    [SerializeField] Transform leftPedal;
    [SerializeField] Transform rightPedal;
    [SerializeField] Transform leftGrip;
    [SerializeField] Transform rightGrip;
    [SerializeField] Transform seatingPosition;

    public Vector3 rightLegoffset;
    public Vector3 leftLegoffset;
    Animator anim;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
   

    private void OnAnimatorIK(int layerIndex)
    {
      

        anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot,1);
        anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);



        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftPedal.transform.position);
        anim.SetIKPosition(AvatarIKGoal.RightHand, rightPedal.transform.position);

        anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftPedal.transform.position + leftLegoffset);
        anim.SetIKPosition(AvatarIKGoal.RightFoot, rightPedal.transform.position + rightLegoffset);
    }
}
