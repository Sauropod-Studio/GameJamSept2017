using UnityEngine;

public class MouteuxFeuilles : MonoBehaviour {
    public Animator animator;
    public Rigidbody rb;

    public float woopThreshold;
    public float killThreshold;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > killThreshold)
        {
            animator.SetTrigger("Kill");
            deathTime = Time.time + 0.2f;
        }
        else if (collision.relativeVelocity.magnitude > woopThreshold)
        {
            animator.SetTrigger("Wooump");
        }
            
    }

    float deathTime = float.MaxValue;
    private void Update()
    {
        if (Time.time >= deathTime)
            GameObject.Destroy(gameObject);
    }
}


