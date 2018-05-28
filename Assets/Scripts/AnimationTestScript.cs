using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTestScript : MonoBehaviour 
{

	public Animator m_GenieAnimator;
	public Animator m_BirdAnimator;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			Debug.Log("Part l'animation");
			m_GenieAnimator.SetTrigger("GenieAttack");
			m_BirdAnimator.SetTrigger("BirdGetHit");
		}

			if(Input.GetKeyDown(KeyCode.W))
		{
			Debug.Log("Part l'animation");
			m_BirdAnimator.SetTrigger("BirdAttack");
			m_GenieAnimator.SetTrigger("GenieGetHit");
		}
	}
}
