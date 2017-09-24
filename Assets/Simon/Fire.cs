using UnityEngine;

public class Fire : MonoBehaviour {

    public float popChance;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Random.value > ( 1 -popChance))
        {
            animator.SetTrigger("Pop");
            animator.SetFloat("Popage", Random.value);
            
        }
        animator.SetFloat("Crepitage", Random.value*2);

    }
}
