using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepUltimeDriver : MonoBehaviour
{
    public Animator Animator;

    [HideInInspector]
    public MoutonSePromene MoutonSePromene;

    [HideInInspector]
    public int StateParam;
    [HideInInspector]
    public int SplatParam;

    private bool _falling;

    void Start()
    {
        MoutonSePromene = GetComponent<MoutonSePromene>();
        StateParam = Animator.StringToHash("State");
        SplatParam = Animator.StringToHash("Splat");
    }

    void Update()
    {
        if (MoutonSePromene.IsSuspended())
        {
            Animator.SetInteger(StateParam, 2);
        }
        else if (MoutonSePromene.IsFalling())
        {
            Animator.SetInteger(StateParam, 3);
        }
        else if (MoutonSePromene.WantToMove())
        {
            Animator.SetInteger(StateParam, 1);
        }
        else
        {
            Animator.SetInteger(StateParam, 0);
        }

        var falling = MoutonSePromene.IsFalling();
        if (falling != _falling)
        {
            Animator.SetBool(SplatParam, !falling);
            _falling = falling;
        }
    }
}
