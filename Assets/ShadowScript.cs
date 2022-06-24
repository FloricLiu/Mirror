
using UnityEngine;

class ShadowScript : MonoBehaviour
{
    [SerializeField] private float memberSpeed = 0.0f;
	[SerializeField] private float memberJumpSpeed = 5.0f;
	private Rigidbody2D memberRigidBody = null;
	private bool memberIsJump = false;
    protected void Start()
    {
		memberRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected void Update()
    {
		//movement
		Vector3 localWhichDirection = Vector3.zero;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			localWhichDirection += Vector3.left;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			localWhichDirection += Vector3.right;
		}
		Vector3 localVelocity = memberSpeed * localWhichDirection;
		// Preserve gravity!

		localVelocity.y = memberRigidBody.velocity.y;
		if (Input.GetKeyDown(KeyCode.Space) && memberIsJump == false)
		{
			// If the hero is on a platform, their y-velocity is 0, so they can jump.

			if ((-0.1f < localVelocity.y) && (localVelocity.y < 0.01f))
			{
				localVelocity += memberJumpSpeed * Vector3.down;
				memberIsJump = true;
			}
		}
		if (localVelocity.y == 0)
		{
			memberIsJump = false;
		}
		memberRigidBody.velocity = localVelocity;
	}
	protected void OnTriggerEnter2D(Collider2D localCollider)
	{

		GameObject localOtherObject = localCollider.gameObject;
		if (localOtherObject.name.StartsWith("Dead"))
		{
			this.gameObject.SetActive(false);
			Application.LoadLevel(Application.loadedLevel);
		}

	}
}
