using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalDestroyer : MonoBehaviour {

	public float lifeTime = 5.0f;
	public bool yapisti;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(lifeTime);
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		/*
		if(yapisti == false){
			gameObject.transform.SetParent(other.transform);
			gameObject.GetComponent<Collider>().enabled = false;
			yapisti = true;
		}
		*/
		
	}
}
