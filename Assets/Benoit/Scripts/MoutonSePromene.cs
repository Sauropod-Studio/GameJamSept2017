using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoutonSePromene : MonoBehaviour
{
    [HideInInspector]
    public Planete Planete;

    [HideInInspector]
    public ResteSurTerre ResteSurTerre;

    public float AttenteMoyenne = 1f;
    public float DeplacementMoyen = 3f;
    public float VitesseMax = 1f;
    public float VitesseDeRotation = 180f;

    private Vector3 _positionDebut;
    private float _attente;
    private Vector3 _destination;
    private Quaternion _rotationVoulue;

    void Start()
    {
        Planete = FindObjectOfType<Planete>();
        ResteSurTerre = GetComponent<ResteSurTerre>();
        InitPositionDeReference();
        RandomDestination();
    }

	void Update()
	{
	    if (IsSuspended() || IsFalling())
	    {
	        InitPositionDeReference();
            return;
	    }

        if (WantToMove())
        {
            Move();
        }
        else if (_attente <= Time.deltaTime)
        {
            RandomDestination();
        }
        else
        {
            _attente -= Time.deltaTime;
        }

	    if (WantToRotate())
	    {
	        Rotate();
	    }
    }

    void InitPositionDeReference()
    {
        _positionDebut = Planete.GetPointSurTerre(transform.position);
    }

    public bool IsSuspended()
    {
        return transform.parent != Planete.Objets;
    }

    public bool IsFalling()
    {
        return !ResteSurTerre.ToucheAuSol();
    }

    public bool WantToMove()
    {
        var delta = _destination - transform.position;
        const float dMax = 0.1f;
        return delta.sqrMagnitude >= dMax*dMax;
    }

    bool WantToRotate()
    {
        return Quaternion.Dot(transform.rotation, _rotationVoulue) < 0.999f;
    }

    void Move()
    {
        var delta = _destination - transform.position;
        float dist = delta.magnitude;
        float tRequis = dist / VitesseMax;
        if (tRequis < Time.deltaTime)
        {
            transform.position = _destination;
        }
        else
        {
            transform.position += delta / dist * Time.deltaTime * VitesseMax;
        }

        ResteSurTerre.Ajuster();
        
        if (tRequis < Time.deltaTime)
            _destination = transform.position;
    }

    void Rotate()
    {
        var dist = Quaternion.Angle(transform.rotation, _rotationVoulue);
        var tRequis = dist/VitesseDeRotation;
        if (tRequis < Time.deltaTime)
        {
            transform.rotation = _rotationVoulue;
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _rotationVoulue, Time.deltaTime / tRequis);
        }
    }

    void RandomDestination()
    {
        _attente = Random.Range(AttenteMoyenne * 0.5f, AttenteMoyenne * 1.5f);
        _destination = _positionDebut + Random.insideUnitSphere * Random.Range(DeplacementMoyen * 0.5f, DeplacementMoyen * 1.5f);
        Vector3 up;
        _destination = Planete.GetPointSurTerre(_destination, out up, -ResteSurTerre.Profondeur);
        _rotationVoulue = Quaternion.LookRotation(_destination - transform.position, up);
    }
}
