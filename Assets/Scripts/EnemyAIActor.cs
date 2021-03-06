using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIActor : MonoBehaviour {

	public GameObject laser;
	public GameObject player;
	public GameObject laserSpawnPoint;

	private NavMeshAgent agent;
	private WeaponActor weaponActor;
	private float AttackTimer = 0.0f;
	private int kills;

	[SerializeField]private float pursueRange = 40.0f;
	[SerializeField]private float attackRange = 20.0f;
	[SerializeField]private float agentSpeed = 30.0f;
	[SerializeField]private float AttackTime = 2.0f;
	[SerializeField]private float laserSpeed = 2.0f;
	[SerializeField]private float enemyHealth = 100.0f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		weaponActor = GameObject.FindObjectOfType<WeaponActor> ();
		agent.speed = agentSpeed;
		kills = 0;
	}

	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (agent.transform.position, player.transform.position) < pursueRange) {
			agent.SetDestination (player.transform.position);
		}

		if(Vector3.Distance (agent.transform.position, player.transform.position) > pursueRange) {
			agent.velocity = Vector3.zero;
		}

		if (Vector3.Distance (agent.transform.position, player.transform.position) < attackRange) {
			agent.velocity = Vector3.zero;
			Attack ();
		}

		if (enemyHealth <= 0f) {
			weaponActor.KillCountAddOne ();
			Destroy (this.gameObject);
		}
			
 	}


	void Attack() {

		AttackTimer -= Time.deltaTime;

		if (AttackTimer <= 0.0f) {

			GameObject theLaser = Instantiate (laser);

			AttackTimer = AttackTime;

			theLaser.transform.position = laserSpawnPoint.transform.position;

			Rigidbody rb = theLaser.GetComponent<Rigidbody> ();

			Vector3 direction = player.transform.position - theLaser.transform.position;

			rb.velocity = direction * laserSpeed;

			AttackTimer = AttackTime;

			Destroy (theLaser, 3.0f);
		}
	}


	public void EnemyTakeDamage(float damageAmount) {

		enemyHealth -= damageAmount;
	}

	public int getKillCount() {
		return kills;
	}
}
