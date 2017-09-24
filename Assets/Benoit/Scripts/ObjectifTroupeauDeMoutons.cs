using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifTroupeauDeMoutons : MonoBehaviour
{
    public Transform[] MoutonsARegrouper;
    public float DistanceVoulue = 3f;
    
    //private Dictionary<Transform, int> _connected = new Dictionary<Transform, int>(); 

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
        /*if (MoutonsARegrouper.Length == 0) return false;
        
        _connected.Clear();
        foreach (Transform mouton in MoutonsARegrouper)
            _connected.Add(mouton, _connected.Count);

        foreach (Transform mouton in MoutonsARegrouper)
        {
            foreach (Transform mouton2 in MoutonsARegrouper)
            {
                if (_connected[mouton] != _connected[mouton2] &&
                    (mouton.position - mouton2.position).sqrMagnitude < DistanceVoulue*DistanceVoulue)
                {
                }
            }
            if (connected)
            {
                _connected.Add(mouton);
                break;
            }
        }
        return !alone;*/
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
