﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoutonSePromene : MonoBehaviour
{
    [HideInInspector]
    public Transform Planete;

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
        Planete = GameObject.Find("Planete").transform;
        InitPositionDeReference();
        RandomDestination();
    }

	void Update()
	{
	    if (transform.parent != Planete)
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
        _positionDebut = GetComponent<ResteSurTerre>().GetPointSurTerre(transform.position);
    }

    bool WantToMove()
    {
        var delta = _destination - transform.position;
        return delta.sqrMagnitude >= 1E-6;
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
        _destination = GetComponent<ResteSurTerre>().GetPointSurTerre(_destination, out up);
        _rotationVoulue = Quaternion.LookRotation(_destination - transform.position, up);
    }
}