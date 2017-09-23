using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifTroupeauDeMoutons : MonoBehaviour
{
    public Transform[] MoutonsARegrouper;
    public float DistanceVoulue = 3f;

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
                if ((mouton.position - mouton2.position).sqrMagnitude > DistanceVoulue * DistanceVoulue)
                    return false;
            }
        }
        return true;
    }
}
