using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectifTroupeauDeMoutons : MonoBehaviour
{
    [HideInInspector]
    public Transform[] MoutonsARegrouper;

    public float DistanceVoulue = 10f;
    
    void Start()
    {
        MoutonsARegrouper = FindObjectsOfType<MoutonSePromene>().Select(m => m.transform).ToArray();
    }

	void Update()
    {
	    if (Gagne())
	    {
	        Debug.Log("Objectif Atteint : ObjectifTroupeauDeMoutons");
	        Destroy(this);
	    }
	}

    bool Gagne()
    {
        foreach (Transform mouton in MoutonsARegrouper)
        {
            foreach (Transform mouton2 in MoutonsARegrouper)
            {
                if ((mouton.position - mouton2.position).sqrMagnitude > DistanceVoulue*DistanceVoulue)
                    return false;
            }
        }
        return true;
    }
}
