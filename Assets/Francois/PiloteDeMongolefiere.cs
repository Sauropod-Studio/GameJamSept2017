using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiloteDeMongolefiere : MonoBehaviour {
    public float acceleration;
    public GameObject PivotDeCamera;
    public GameObject Crochet;
    public Animator Animateur;
    private RegarderAvecLesPieds _pieds;
    private Rigidbody _rigidbody;
    private float _decentTime;
    private bool _sauteCetteDessente;

    private void Start()
    {
        _pieds = GetComponent<RegarderAvecLesPieds>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity += transform.forward * acceleration;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity += transform.forward * -acceleration;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.velocity += transform.right * -acceleration;
            _rigidbody.angularVelocity += transform.up * -0.015f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.velocity += transform.right * acceleration;
            _rigidbody.angularVelocity += transform.up * 0.015f;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(Crochet.transform.childCount != 0 || _sauteCetteDessente)
            {
                _sauteCetteDessente = true;
            }
            else
            {
                if (_decentTime < Time.time)
                    _decentTime = Time.time + 0.4f;
                else
                    _decentTime = Mathf.Max(Time.time + 0.1f, _decentTime);
            }
        }
        else
        {
            _sauteCetteDessente = false;
        }
        if (_decentTime > Time.time)
        {
            _rigidbody.velocity += transform.up * -acceleration * 3;
        }

            RaycastHit hit;
        var gravite = (_pieds.Referent - transform.position).normalized;
        if (Physics.Raycast(transform.position, gravite, out hit, _pieds.hauteurVoulue, _pieds.masque))
        {
            PivotDeCamera.transform.position = transform.position + gravite * hit.distance;
        }

        var velocity = transform.InverseTransformPoint(_rigidbody.velocity);
        Animateur.SetFloat("X", Mathf.Clamp(velocity.z * 0.2f ,-1,1));
        Animateur.SetFloat("Y", Mathf.Clamp(-velocity.x * 0.2f, -1, 1));
    }
}
