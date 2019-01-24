using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMoveTest : MonoBehaviour
{

	public float m_sideX;
	public float m_sideY;

	public Transform m_respwanPos;

	private Rigidbody2D m_rb;
	public float m_moveSpeed = 1.0f;

	private CircleCollider2D m_collider;

	private void Awake()
	{
		m_collider = GetComponent<CircleCollider2D>();
		m_rb = GetComponent<Rigidbody2D>();
	}

	//// Use this for initialization
	//void Start()
	//{

	//}

	// Update is called once per frame
	void Update()
	{
		m_rb.velocity = new Vector2(m_moveSpeed, 0.0f);
		CheckPos();
	}


	void CheckPos()
	{
		if (this.transform.position.x < m_sideX)
		{
			this.transform.position = m_respwanPos.position;
			m_collider.enabled = true;
		}
	}

	// class end
}
