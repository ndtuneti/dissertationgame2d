using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float speed;
	public float lifeTime;
	public GameObject explosion;
	public int damage;
	// Use this for initialization
	private void Start()
	{
		Invoke("DestroyProjectile", lifeTime);

	}

    // Update is called once per frame
    private void Update()
    {
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
	void DestroyProjectile()
	{
		Destroy(gameObject);
		Instantiate(explosion, transform.position, Quaternion.identity);
		
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			other.GetComponent<Enemy>().TakeDamage(damage);
			DestroyProjectile();
		}

		

	}
}
