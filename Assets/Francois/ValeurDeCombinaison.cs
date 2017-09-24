using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValeurDeCombinaison : MonoBehaviour {
    public Identite identite;
    public enum Identite
    {
        Mouton, Arbre, Nuage, Feu, Eau, Loup, Desert, Herbe, Oiseau, Vache, Carotte
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == null)
            return;
        var autre = collision.collider.GetComponentInParent<ValeurDeCombinaison>();
        if (autre == null)
            return;

        switch (identite)
        {
            case Identite.Mouton:
                switch (autre.identite)
                {
                    case Identite.Carotte:
                        break;
                    case Identite.Feu:
                        break;
                    case Identite.Loup:
                        break;
                }
                break;
            case Identite.Arbre:
                switch (autre.identite)
                {
                    case Identite.Feu:
                        break;
                    case Identite.Eau:
                        break;
                }
                break;
            case Identite.Nuage:
                switch (autre.identite)
                {
                    case Identite.Eau:
                        break;
                }
                break;
            case Identite.Feu:
                switch (autre.identite)
                {
                    case Identite.Eau:
                        break;
                }
                break;
            case Identite.Loup:
                switch (autre.identite)
                {
                    case Identite.Eau:
                        break;
                }
                break;
        }
    }
}
