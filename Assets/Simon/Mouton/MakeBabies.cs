using UnityEngine;

public class MakeBabies : MonoBehaviour {
    public bool testIt;

    public float scaleReduction;
    public AnimationCurve movement;
    public float splitDuration;
    public float splitDistance;

    public void Spawn()
    {
        splitDirection = Random.insideUnitSphere;
        splitPosition = transform.position;
        timeAtSplit = Time.time;
        clone = GameObject.Instantiate(gameObject).transform;

        this.transform.localScale = this.transform.localScale * scaleReduction;
        clone.transform.localScale = clone.transform.localScale * scaleReduction;
        this.enabled = true;
    }

    private float timeAtSplit;
    private Vector3 splitPosition;
    private Vector3 splitDirection;
    private Transform clone;

    private void Update()
    {
        if (Time.time - timeAtSplit > splitDuration)
        {
            this.enabled = false;
            return;
        }

        Vector3 d = (movement.Evaluate(Time.time - timeAtSplit) * splitDistance * transform.localScale.magnitude) * splitDirection;
        transform.position = splitPosition + d;
        clone.position = splitPosition - d;
    }

    private void OnValidate()
    {
        if(testIt)
        {
            testIt = false;
            Spawn();
        }
    }

}
