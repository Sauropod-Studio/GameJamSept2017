using UnityEngine;

public class Allo : MonoBehaviour
{
    public Renderer Renderer;

	void Start()
	{
	    Renderer = GetComponent<Renderer>();
	}
	
	void Update()
	{
	    Renderer.material.color = Random.ColorHSV();
	}
}
