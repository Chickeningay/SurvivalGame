using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementReworked : MonoBehaviour
{
	bool lerpactive;
	public GameObject WalkAudioPlayer;
	public AudioClip LandClip;
	public CharacterController controller;
	public Transform GroundCheck;
	public LayerMask GroundMask;
	public GameObject SecondCamera;
	private float wishspeed2;
	private float gravity = -20f;
	float wishspeed;
	public bool mwhlup;
	public float GroundDistance = 0.4f;
	public float moveSpeed = 7f;  // Ground move speed
	public float startms = 7f;
	public float runAcceleration = 20f;   // Ground accel
	public float runDeacceleration = 10f;   // Deacceleration that occurs when running on the ground
	public float airAcceleration = 2.0f;  // Air accel
	public float airDeacceleration = 2.0f;    // Deacceleration experienced when opposite strafing
	public float airControl = 2f;  // How precise air control is
	public float sideStrafeAcceleration = 50f;   // How fast acceleration occurs to get up to sideStrafeSpeed when side strafing
	public float sideStrafeSpeed = 1f;    // What the max speed to generate when side strafing
	public float jumpSpeed = 8.0f;
	public float friction = 6f;
	private float playerTopVelocity = 0;
	public float playerFriction = 0f;
	float addspeed;
	float accelspeed;
	float currentspeed;
	float zspeed;
	float speed;
	float dot;
	float k;
	float accel;
	float newspeed;
	float control;
	float drop;

	public bool JumpQueue = false;
	public bool wishJump = false;

	//UI
	private Vector3 lastPos;
	private Vector3 moved;
	public Vector3 PlayerVel;
	public float ModulasSpeed;
	public float ZVelocity;
	public float XVelocity;
	//End UI

	public Vector3 moveDirection;
	public Vector3 moveDirectionNorm;
	private Vector3 playerVelocity;
	Vector3 wishdir;
	Vector3 vec;
	public GameObject currentLadder;
	public Transform playerView;

	public float x;
	public float z;
	public bool climbing;
	public bool IsGrounded;
	public float wantedcontrollerheight;
	public float wantedcolliderheight;
	float msmodifier;
	public Transform player;
	Vector3 udp;
	public bool InWater;
	public GameObject Camera;
	public bool IsCameraInWater;
	public GameObject watereffect;
	public bool OnLadder;
	public bool Climbable;
	public bool DO_NOT_ENTER_LADDER;
	public bool jump_forward_when_exiting_ladder;
	public GameObject SecondaryCam;
	bool xishigher;
	bool zishigher;
	bool donedamage;
	public GameObject FlashedView;
	public bool flashed;
	bool secondaryflashed;
	bool secondaryinwater;
	public bool interacting;
	public bool Inventory;
	public bool moving;
	bool receivedcommand;
	Vector3 commandmovepos;
	public GameObject CommandListener;
	public bool jumpsound_ready=true;

	private void Start()
	{
		Cursor.visible = false;
		//This is for UI, feel free to remove the Start() function.
		lastPos = player.position;
		wantedcolliderheight = gameObject.GetComponent<CapsuleCollider>().height;
		wantedcontrollerheight = gameObject.GetComponent<CharacterController>().height;
	}

	// Update is called once per frame
	void Update()
	{
		moveSpeed = startms;
		msmodifier = 0;
        if (SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>() != null)
        {
			if(SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().currentID==0|| SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().currentID == 1)
            {
				msmodifier += 2;
            }
        }
		else if(SecondaryCam.GetComponent<BetterWeaponSwitch>() != null)
        {
			if (SecondaryCam.GetComponent<BetterWeaponSwitch>().currentWeapon == 0 || SecondaryCam.GetComponent<BetterWeaponSwitch>().currentWeapon == 1)
			{
				msmodifier += 2;
			}
		}
        if (Input.GetKey(KeyCode.LeftControl))
        {
			msmodifier -= 4;
        }
		else if (Input.GetKey(KeyCode.LeftShift))
        {
			msmodifier += 2;
        }
		moveSpeed += msmodifier;
        if (flashed)
        {
			foreach (Transform g in SecondaryCam.transform.GetComponentsInChildren<Transform>())
			{
				g.gameObject.layer = 3;
			}
			secondaryflashed = true;
        }
		if(secondaryflashed && !flashed)
        {
			secondaryflashed = false;
			foreach (Transform g in SecondaryCam.transform.GetComponentsInChildren<Transform>())
			{

				if (g.gameObject.GetComponent<WeaponControl>() != null && g.gameObject.GetComponent<WeaponControl>().enabled)
				{
					foreach (Transform gg in g.transform.GetComponentsInChildren<Transform>())
					{
						gg.gameObject.layer = 7;
					}
				}
				else if (g.gameObject.GetComponent<grenadeScript>() != null && g.gameObject.GetComponent<grenadeScript>().enabled)
				{
					foreach (Transform gg in g.transform.GetComponentsInChildren<Transform>())
					{
						gg.gameObject.layer = 7;
					}
				}
			}
		}
        if (Mathf.Abs(playerVelocity.z) >= 0.1f || Mathf.Abs(playerVelocity.x) >= 0.1f)
        {
			
			moving = true;
        }
		else
        {
			moving = false;
		}
		if (IsGrounded && playerVelocity.y < -20)
		{
			if (gameObject.GetComponent<HealthScript>().Armour <= 0)
			{
				gameObject.GetComponent<HealthScript>().Health -= 2;
			}
			else
			{
				gameObject.GetComponent<HealthScript>().Armour -= 1;
			}
			
		}
		Crouch();
		if (OnLadder)
		{
			
			if (currentLadder.transform.eulerAngles.y<45&& currentLadder.transform.eulerAngles.y > -45)
			{

				if (!Climbable)
				{
					if (Input.GetKey(KeyCode.A))
					{

						playerVelocity.z = -5f;
					}
					else if (Input.GetKey(KeyCode.D))
					{

						playerVelocity.z = +5f;
					}
					else
					{

						playerVelocity.x = 0;
						playerVelocity.z = 0;
					}
				}
				else
				{

					playerVelocity.x = 0;
					playerVelocity.z = 0;
				}
			}
			else if (currentLadder.transform.eulerAngles.y>=135&&currentLadder.transform.eulerAngles.y<215)
			{

				if (!Climbable)
				{
					if (Input.GetKey(KeyCode.A))
					{

						playerVelocity.z = +5f;
					}
					else if (Input.GetKey(KeyCode.D))
					{

						playerVelocity.z = -5f;
					}
					else
					{

						playerVelocity.x = 0;
						playerVelocity.z = 0;
					}
				}
				else
				{

					playerVelocity.x = 0;
					playerVelocity.z = 0;
				}
			}
			else if (currentLadder.transform.eulerAngles.y>=225&&currentLadder.transform.eulerAngles.y<315)
			{
				if (!Climbable)
				{
					if (Input.GetKey(KeyCode.A))
					{

						playerVelocity.x = 5f;
					}
					else if (Input.GetKey(KeyCode.D))
					{

						playerVelocity.x = -5f;
					}
					else
					{

						playerVelocity.x = 0;
						playerVelocity.z = 0;
					}
				}
				else
				{

					playerVelocity.x = 0;
					playerVelocity.z = 0;
				}
			}
			else if (currentLadder.transform.eulerAngles.y>=45&&currentLadder.transform.eulerAngles.y<135)
			{
				if (!Climbable) {
					if (Input.GetKey(KeyCode.A))
					{

						playerVelocity.x = -5f;
					}
					else if (Input.GetKey(KeyCode.D))
					{

						playerVelocity.x = 5f;
					}
					else
					{

						playerVelocity.x = 0;
						playerVelocity.z = 0;
					}
				}
					else
					{

						playerVelocity.x = 0;
						playerVelocity.z = 0;
					}
			}
			
			if (Input.GetKeyDown(KeyCode.Space))
			{
				StartCoroutine(ExitLadderSequence());
			}
			gravity = 0;
		
			if (Input.GetKey(KeyCode.W) || Climbable)
			{
				playerVelocity.y = 7.5f;
			}
			else if (Input.GetKey(KeyCode.S) && !Climbable)
			{
				playerVelocity.y = -7.5f;
			}
            else
            {
				playerVelocity.y = 0;

			}
			
		}
			IsCameraInWater = Camera.GetComponent<Underwater>().CameraInWater;
		
		if (IsCameraInWater)
		{
			watereffect.active = true;
		}
		else if(!IsCameraInWater)
		{
			watereffect.active = false;
		}
		if (InWater)
		{
			secondaryinwater = true;
			foreach (Transform g in SecondaryCam.transform.GetComponentsInChildren<Transform>())
			{
				g.gameObject.layer = 3;
			}
			gravity = -3;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				playerVelocity.y+= -4 * Time.deltaTime;
			}
			else if (Input.GetKey(KeyCode.Space))
			{
				playerVelocity.y = 1000* Time.deltaTime;
			}
			//playerVelocity.y = Mathf.Clamp(playerVelocity.y, 3f, -3f);
		}
		if (!InWater&&secondaryinwater)
		{
			
			secondaryinwater = false;
			foreach (Transform g in SecondaryCam.transform.GetComponentsInChildren<Transform>())
			{

				if (g.gameObject.GetComponent<WeaponControl>() != null && g.gameObject.GetComponent<WeaponControl>().enabled)
				{
					foreach (Transform gg in g.transform.GetComponentsInChildren<Transform>())
					{
						gg.gameObject.layer = 7;
					}
				}
				else if (g.gameObject.GetComponent<grenadeScript>() != null && g.gameObject.GetComponent<grenadeScript>().enabled)
				{
					foreach (Transform gg in g.transform.GetComponentsInChildren<Transform>())
					{
						gg.gameObject.layer = 7;
					}
				}
				else if (g.gameObject.GetComponent<ItemScript>() != null && g.gameObject.GetComponent<ItemScript>().enabled)
				{
					foreach (Transform gg in g.transform.GetComponentsInChildren<Transform>())
					{
						gg.gameObject.layer = 7;
					}
				}
			}
			gravity = -20;
		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
		{
			friction = 3;
		}
		else { friction = 8; }
		if (playerFriction <= 3.5f && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) || playerFriction <= 3.5f && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || playerFriction <= 3.5f && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) || playerFriction <= 3.5f && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
		{
			friction = 2;
		}
		#region //UI, Feel free to remove the region.

		moved = player.position - lastPos;
		lastPos = player.position;
		PlayerVel = moved / Time.fixedDeltaTime;

		ZVelocity = Mathf.Abs(PlayerVel.z);
		XVelocity = Mathf.Abs(PlayerVel.x);


		ModulasSpeed = Mathf.Sqrt(PlayerVel.z * PlayerVel.z + PlayerVel.x * PlayerVel.x);

		#endregion

		 IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

		QueueJump();

		/* Movement, here's the important part */
		if (controller.isGrounded) { 
            
				GroundMove();
			
		}
		else if (!controller.isGrounded)
			AirMove();

       
        if (!receivedcommand)
        {
            if (InWater)
            {
				playerVelocity = new Vector3(Mathf.Clamp(playerVelocity.x, -20, 20), Mathf.Clamp(playerVelocity.y, -20, 20), Mathf.Clamp(playerVelocity.z, -20, 20));
			}
            else
            {
				playerVelocity = new Vector3(Mathf.Clamp(playerVelocity.x, -20, 20), playerVelocity.y, Mathf.Clamp(playerVelocity.z, -20, 20));
			}
			controller.Move(playerVelocity * Time.deltaTime);

			
			udp = playerVelocity;
			udp.y = 0;
			if (udp.magnitude > playerTopVelocity)
				playerTopVelocity = udp.magnitude;
		}
        else if(receivedcommand)
        {
			gameObject.GetComponent<CharacterController>().enabled = false;
			PlayerVel = new Vector3(0, 0, 0);
			gameObject.transform.position = commandmovepos;
			receivedcommand = false;
			commandmovepos= new Vector3(0, 0, 0);
			gameObject.GetComponent<CharacterController>().enabled = true;
			
		}
		else if (climbing)
        {
			gameObject.GetComponent<CharacterController>().enabled = false;
			gameObject.GetComponent<CapsuleCollider>().enabled = false;
			PlayerVel = new Vector3(0, 0, 0);
			gravity = 0;
		}
        if (moving && IsGrounded)
        {
			StartCoroutine(WalkAudioWait());
        }
		else if (!moving || !IsGrounded)
        {
			StopCoroutine(WalkAudioWait());
			WalkAudioPlayer.GetComponent<AudioSource>().enabled=false;
		}
        if (IsGrounded &&jumpsound_ready&& playerVelocity.y < -5)
        {
			StopCoroutine(LandSoundCooldown());
			StartCoroutine(LandSoundCooldown());
			
			
			
        }
		
	}
	IEnumerator WalkAudioWait()
    {
		yield return new WaitForSeconds(1f);
        if (IsGrounded)
        {
			WalkAudioPlayer.GetComponent<AudioSource>().enabled = true;
		}
		
	}
	IEnumerator LandSoundCooldown()
    {
		
		jumpsound_ready = false;
		gameObject.GetComponent<AudioSource>().PlayOneShot(LandClip);
		yield return new WaitForSeconds(0.1f);
		
		jumpsound_ready = true;
    }
	public void Crouch()
	{
		if (!CommandListener.active)
		{
			if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			gameObject.GetComponent<CapsuleCollider>().height = 1;
			gameObject.GetComponent<CharacterController>().height = 1;
			gameObject.GetComponent<CharacterController>().radius = 0.8f;
			gameObject.GetComponent<CapsuleCollider>().radius = 0.8f;
		}
		
		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			gameObject.GetComponent<CapsuleCollider>().height = 3;
			gameObject.GetComponent<CharacterController>().height = 3;
			gameObject.GetComponent<CharacterController>().radius = 0.5f;
			gameObject.GetComponent<CapsuleCollider>().radius = 0.5f;
		}
		}
        if (CommandListener.active)
        {
			gameObject.GetComponent<CapsuleCollider>().height = 3;
			gameObject.GetComponent<CharacterController>().height = 3;
			gameObject.GetComponent<CharacterController>().radius = 0.5f;
			gameObject.GetComponent<CapsuleCollider>().radius = 0.5f;
		}
	}
	public void SetMovementDir()
	{
		x = Input.GetAxis("Horizontal");
		z = Input.GetAxis("Vertical");
	}

	//Queues the next jump
	void QueueJump()
	{
        if (!CommandListener.active)
        {
			
			
				if (!InWater && !wishJump && Input.GetButtonDown("Jump") && IsGrounded)
				{
					wishJump = true;
				}

				/*if (!wishJump && !IsGrounded && Input.GetButtonDown("Jump"))
				{
					JumpQueue = true;
				}
				if (!wishJump && IsGrounded && JumpQueue)
				{
					wishJump = true;
					JumpQueue = false;
				}*/
			
			if (mwhlup) { 
				if (!InWater && !wishJump && Input.GetAxisRaw("Mouse ScrollWheel") > 0 && IsGrounded)
			{
				wishJump = true;
			}
			/*if (!wishJump && !IsGrounded && Input.GetAxisRaw("Mouse ScrollWheel") > 0)
			{
				JumpQueue = true;
			}
			if (!wishJump && IsGrounded && JumpQueue)
			{
				wishJump = true;
				JumpQueue = false;
			}*/
		}
		}



	}

	//Calculates wish acceleration
	public void Accelerate(Vector3 wishdir, float wishspeed, float accel)
	{
		currentspeed = Vector3.Dot(playerVelocity, wishdir);
		addspeed = wishspeed - currentspeed;
		if (addspeed <= 0)
			return;
		accelspeed = accel * Time.deltaTime * wishspeed;
		if (accelspeed > addspeed)
			accelspeed = addspeed;

        
		playerVelocity.x += accelspeed * wishdir.x;
		playerVelocity.z += accelspeed * wishdir.z;
	}

	//Execs when the player is in the air
	public void AirMove()
	{
		SetMovementDir();

		wishdir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		wishdir = transform.TransformDirection(wishdir);

		wishspeed = wishdir.magnitude;

		wishspeed *= 7f;

		wishdir.Normalize();
		moveDirectionNorm = wishdir;

		// Aircontrol
		wishspeed2 = wishspeed;
		if (Vector3.Dot(playerVelocity, wishdir) < 0)
			accel = airDeacceleration;
		else
			accel = airAcceleration;

		// If the player is ONLY strafing left or right
		if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") != 0)
		{
			if (wishspeed > sideStrafeSpeed)
				wishspeed = sideStrafeSpeed;
			accel = sideStrafeAcceleration;
		}

		Accelerate(wishdir, wishspeed, accel);

		AirControl(wishdir, wishspeed2);

		// !Aircontrol

		// Apply gravity
		if (!OnLadder)
		{
			playerVelocity.y += gravity * Time.deltaTime;

		}
		

		/**
			* Air control occurs when the player is in the air, it allows
			* players to move side to side much faster rather than being
			* 'sluggish' when it comes to cornering.
			*/

		void AirControl(Vector3 wishdir, float wishspeed)
		{
			// Can't control movement if not moving forward or backward
			if (Input.GetAxis("Horizontal") == 0 || wishspeed == 0)
				return;

			zspeed = playerVelocity.y;
			playerVelocity.y = 0;
			/* Next two lines are equivalent to idTech's VectorNormalize() */
			speed = playerVelocity.magnitude;
			playerVelocity.Normalize();

			dot = Vector3.Dot(playerVelocity, wishdir);
			k = 32;
			k *= airControl * dot * dot * Time.deltaTime;

			// Change direction while slowing down
			if (dot > 0)
			{
				playerVelocity.x = playerVelocity.x * speed + wishdir.x * k;
				playerVelocity.y = playerVelocity.y * speed + wishdir.y * k;
				playerVelocity.z = playerVelocity.z * speed + wishdir.z * k;

				playerVelocity.Normalize();
				moveDirectionNorm = playerVelocity;
			}

			playerVelocity.x *= speed;
			playerVelocity.y = zspeed; // Note this line
			playerVelocity.z *= speed;

		}
	}
	/**
		* Called every frame when the engine detects that the player is on the ground
		*/
	public void GroundMove()
	{
		// Do not apply friction if the player is queueing up the next jump
		if (!wishJump)
			ApplyFriction(1.0f);
		else
			ApplyFriction(0);

		SetMovementDir();

		if (!CommandListener.active)
		{
			wishdir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		}
		if (CommandListener.active)
		{
			wishdir = new Vector3(0, 0, 0);
		}
			wishdir = transform.TransformDirection(wishdir);
		wishdir.Normalize();
		moveDirectionNorm = wishdir;

		wishspeed = wishdir.magnitude;
		wishspeed *= moveSpeed;
       
		Accelerate(wishdir, wishspeed, runAcceleration);

		// Reset the gravity velocity
		playerVelocity.y = 0;

		if (wishJump)
		{
			playerVelocity.y = jumpSpeed;
			
			playerVelocity.x += 1f * wishdir.x;
			playerVelocity.z += 1f * wishdir.z;
			wishJump = false;
		}

		/**
			* Applies friction to the player, called in both the air and on the ground
			*/
		void ApplyFriction(float t)
		{
			vec = playerVelocity;
			vec.y = 0f;
			speed = vec.magnitude;
			drop = 0f;


			if (controller.isGrounded)
			{
				control = speed < runDeacceleration ? runDeacceleration : speed;
				drop = control * friction * Time.deltaTime * t;
			}

			newspeed = speed - drop;
			playerFriction = newspeed;
			if (newspeed < 0)
				newspeed = 0;
			if (speed > 0)
				newspeed /= speed;

			playerVelocity.x *= newspeed;
			// playerVelocity.y *= newspeed;
			playerVelocity.z *= newspeed;
		}
	}
	
	public void MoveIntoPosition(Vector3 DesiredPos)
    {
		receivedcommand = true;
		commandmovepos = DesiredPos;
    }
	IEnumerator FlashEffect()
    {
		
		
		yield return new WaitForSeconds(2f);
		
		FlashedView.active = false;

		flashed = false;

		


	}
	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Flash")
        {
			FlashedView.active = true;
			flashed = true;
			StartCoroutine(FlashEffect());
        }
		if (other.gameObject.tag == "Explosion")
		{
			if (other.gameObject.transform.position.x < gameObject.transform.position.x)
			{
				if (gameObject.transform.position.x - other.gameObject.transform.position.x > 0.5f)
				{
					playerVelocity.x += 5f / Mathf.Clamp((gameObject.transform.position.x - other.gameObject.transform.position.x), 2f, 100f);
				}
			}
			else if (other.gameObject.transform.position.x > gameObject.transform.position.x)
			{
				if (other.gameObject.transform.position.x - gameObject.transform.position.x > 0.5f)
				{
					playerVelocity.x -= 5f / Mathf.Clamp((other.gameObject.transform.position.x - gameObject.transform.position.x), 2f, 100f);
				}

			}
			if (other.gameObject.transform.position.y < gameObject.transform.position.y)
			{
				if(gameObject.transform.position.y - other.gameObject.transform.position.y > 1f)
				{
					playerVelocity.y += 10f / Mathf.Clamp(gameObject.transform.position.y - other.gameObject.transform.position.y, 2f, 100f);
				}
				
			}
			
			if (other.gameObject.transform.position.z < gameObject.transform.position.z)
			{
				if (gameObject.transform.position.z - other.gameObject.transform.position.z > 0.5f)
				{
					playerVelocity.z += 5f / Mathf.Clamp(gameObject.transform.position.z - other.gameObject.transform.position.z, 2f, 100f);
				}
			}
			else if (other.gameObject.transform.position.z > gameObject.transform.position.z)
			{
				if (gameObject.transform.position.z - other.gameObject.transform.position.z > 0.5f)
				{
					playerVelocity.z -= 5f / Mathf.Clamp((other.gameObject.transform.position.z - gameObject.transform.position.z), 2f, 100f); ;
				}
			}
		}
	}
	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "AmmoBox")
		{
			Destroy(col.gameObject);
            if (SecondaryCam.GetComponent<BetterWeaponSwitch>() != null)
            {
				SecondaryCam.GetComponent<BetterWeaponSwitch>().RenewAmmo = true;
			}
			else if (SecondaryCam.GetComponent<BetterWeaponSwitch>() == null)
            {
				SecondaryCam.GetComponent<BetterWeaponSwitchForInventory>().RenewAmmo = true;
			}
		}
		
			if (col.gameObject.layer == 6)
		{
			InWater = true;
		}
		else if (!DO_NOT_ENTER_LADDER && col.gameObject.tag == "Ladder") { 
			
			OnLadder = true;
			wishJump = false;
			currentLadder = col.gameObject;
			
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.layer == 6)
		{
			InWater = false;

		}
		else if (col.gameObject.tag == "Ladder")
		{
			OnLadder = false;
			Climbable = false;
			gravity = -20f;
		}
		else if (col.gameObject.tag == "Climbable")
        {
			OnLadder = false;
			Climbable = false;
			gravity = -20f;
		}
	}
	
	
    private void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.layer == 8 && other.gameObject.GetComponent<Renderer>().bounds.max.y > gameObject.GetComponent<Renderer>().bounds.min.y+0.1f&&other.gameObject.GetComponent<Renderer>().bounds.max.y-gameObject.GetComponent<Renderer>().bounds.max.y<1.5f)
		{

			playerVelocity = new Vector3(playerVelocity.x, playerVelocity.y + 1f, playerVelocity.z);
		}
	}
    private void OnCollisionStay(Collision other)
    {
		
	
		foreach (ContactPoint point in other.contacts)
        {


			if (Mathf.Abs(gameObject.transform.position.y - point.point.y) < 0.5f)
			{
			if (point.point.x < gameObject.transform.position.x)
			{
					if (playerVelocity.x > 20f)
					{
						playerVelocity.x += 20f;

					}
					else if (playerVelocity.x > 0f && playerVelocity.x < 0f)
					{
						playerVelocity.x = 0f;

					}
					if (playerVelocity.x < 0f)
					{

					}
				}
			else if (point.point.x > gameObject.transform.position.x)
			{
				if (point.point.x - gameObject.transform.position.x > 0.5f)
				{
                        if (playerVelocity.x > 20f)
                        {
							playerVelocity.x -= 20f;

						}
						else if (playerVelocity.x>0f&& playerVelocity.x < 0f)
                        {
							playerVelocity.x = 0f;

						}
                        if (playerVelocity.x < 0f)
                        {

                        }
				}

			}
			if (point.point.y < gameObject.transform.position.y)
			{
				if (gameObject.transform.position.y - point.point.y > 0.5f)
				{
						if (playerVelocity.y > 20f)
						{
							playerVelocity.y += 20f;

						}
						else if (playerVelocity.y > 0f && playerVelocity.y < 0f)
						{
							playerVelocity.y = 0f;

						}
						if (playerVelocity.y < 0f)
						{

						}
					}

			}
			else if (point.point.y > gameObject.transform.position.y)
			{
					if (gameObject.transform.position.y - point.point.y > 0.5f)
					{
						if (playerVelocity.y > 20f)
						{
							playerVelocity.y -= 20f;

						}
						else if (playerVelocity.y > 0f && playerVelocity.y < 0f)
						{
							playerVelocity.y = 0f;

						}
						if (playerVelocity.y < 0f)
						{

						}
					}
				}
			if (point.point.z < gameObject.transform.position.z)
			{
				if (gameObject.transform.position.z - point.point.z > 0.5f)
				{
						if (playerVelocity.z > 20f)
						{
							playerVelocity.z += 20f;

						}
						else if (playerVelocity.z > 0f && playerVelocity.z < 0f)
						{
							playerVelocity.z = 0f;

						}
						if (playerVelocity.z < 0f)
						{

						}
					}
			}
			else if (point.point.z > gameObject.transform.position.z)
			{
				if (gameObject.transform.position.z - point.point.z > 0.5f)
				{
						if (playerVelocity.z > 20f)
						{
							playerVelocity.z -= 20f;

						}
						else if (playerVelocity.z > 0f && playerVelocity.z < 0f)
						{
							playerVelocity.z = 0f;

						}
						if (playerVelocity.z < 0f)
						{

						}
					}
			}
		}
	}
	}
	IEnumerator ExitLadderSequence()
	{
		xishigher = false;
		zishigher = false;
		DO_NOT_ENTER_LADDER = true;
		OnLadder = false;
		yield return new WaitForSeconds(0.1f);
		gravity = -20f;
		if (Mathf.Abs(currentLadder.transform.position.x - gameObject.transform.position.x)> Mathf.Abs(currentLadder.transform.position.z - gameObject.transform.position.z))
		{
			xishigher = true;
			zishigher = false;
		}
		else
		{
			zishigher = true;
			xishigher = false;
		}
		if (currentLadder.transform.position.x < gameObject.transform.position.x)
		{
			if (xishigher)
			{
				playerVelocity.x += 7.5f;
			}
			
				
			
		}
		else if (currentLadder.gameObject.transform.position.x > gameObject.transform.position.x)
		{
			if (xishigher)
			{
				playerVelocity.x -= 7.5f;
			}
			
		}
		if (currentLadder.gameObject.transform.position.z < gameObject.transform.position.z)
		{
			if (zishigher)
			{
				playerVelocity.z += 7.5f;
			}
			
		}
		else if (currentLadder.gameObject.transform.position.z > gameObject.transform.position.z)
		{
			if (zishigher)
			{
				playerVelocity.z -= 7.5f;
			}
			
		}
		xishigher = false;
		zishigher = false;
		yield return new WaitForSeconds(3f);
		DO_NOT_ENTER_LADDER = false;
		
	}
}
