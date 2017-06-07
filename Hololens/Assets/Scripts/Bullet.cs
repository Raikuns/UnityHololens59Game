using UnityEngine;

public class Bullet : MonoBehaviour {

	#region Variables
	private Transform target;

	public float speed = 70f;
	//public GameObject particleEffect;
	#endregion


	#region Unity Methods
	public void Seek (Transform _target)
	{
		target = _target;
	}

	void Update ()
	{
		if(target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);

	}

	void HitTarget()
	{
		//Particle system for a hit
		//GameObject effectIns = (GameObject)Instantiate(particleEffect, transform.position, transform.rotation);
		//Destroy(effectIns, 2f);

		Destroy(gameObject);
	}
	#endregion
}

