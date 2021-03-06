    using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class WeaponControl : MonoBehaviour
{
    bool axebool;
    public bool hasScope;
    public bool weaponScoped;
    public int BPM;
    public bool Automatic;
    public int CurrentAmmo;
    public int MaxAmmo;
    public int CurrentReserve;
    public int MaxReserve;
    public GameObject Player;
    public GameObject MainCamera;
    public bool ShootingRay;
    public GameObject BulletFlash;
    public GameObject AmmoText;
    public GameObject fakebullet;
    public GameObject fakebulletspawn;
    public AudioClip Reload_Audio;
    public AudioClip Action1_Audio;
    public AudioClip Action2_Audio;
    public AudioClip Switch_Audio;
    public AudioClip EmptyMagazine_Audio;
    public AnimationClip Reload_Clip;
    public AnimationClip Action1_Clip;
    public AnimationClip Action2_Clip;
    public AnimationClip Switch_Clip;
    public AnimationClip Movement_Clip;
    public AnimationClip Movement_ContClip;
    public AnimationClip MovementToReloadClip;
    public AnimationClip WalkAnim_Clip;
    public AnimationClip WalkAnimCont_Clip;
    public bool ShootingCooldown;
    public bool RPGIcon;
    public bool AmmoIcon;
    public GameObject MeleeIcon;
    public GameObject GrenadeIcon;
    public GameObject RpgImage;
    public GameObject AmmoImage;
    public Vector3 startpos;
    public bool Melee;
    public GameObject MeleeCollider;
    RaycastHit[] Hit;
    public GameObject Inventory;
    public bool InventoryExtended;
    public bool ObeyInventory;
    bool inWater;
    public Quaternion startrot;
    bool flashenabledagain;
    bool flashdisablerunning;
    public GameObject ImpactPrefab;
    bool emptymagaudiosent;
    bool normalization;
    bool blockmovement;
    public float jumpswaydebt;
    bool runanimcooldown;
    bool walkanimcooldown;
    public float movementAnimBaseY;
    public GameObject Cross;
    public bool decoy;
    // Start is called before the first frame update
    void Start()
    {
        if (!decoy)
        {

        
        gameObject.transform.parent.GetComponent<sway>().enabled = false;
        startpos = gameObject.transform.localPosition;
        startrot = gameObject.transform.localRotation;
        gameObject.transform.parent.GetComponent<sway>().enabled = true;
        Player.GetComponent<AudioSource>().PlayOneShot(Switch_Audio);
        gameObject.GetComponent<Animator>().Play(Switch_Clip.name);
        if (BulletFlash != null)
        {
            BulletFlash.active = false;
        }
        Inventory = GameObject.Find("Inventory");
        Cross = GameObject.Find("Crosshair");
        }
    }

    private void OnEnable()
    {
        
            CurrentAmmo = Inventory.GetComponent<InventorySelecter>().CurrentSelected.gameObject.GetComponent<IDHolder>().currentAmmo;
            gameObject.GetComponent<Animator>().Play("M4_SwitchAnim");


    }
    private void OnDisable()
    {
        if (decoy) { gameObject.transform.GetChild(0).transform.gameObject.GetComponent<WeaponControl>().enabled = false; }
        gameObject.GetComponent<Animator>().Play("New State");
        //gameObject.transform.localPosition = startpos;
        //gameObject.transform.localRotation = startrot;
    }

    void NormalizeWeapon()
    {
        if (!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnimCont_Clip.name) && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnim_Clip.name) && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name) && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name))
        {
            gameObject.GetComponent<Animator>().enabled = false;
            Vector3 NewPos;
            NewPos.x = Mathf.Lerp(gameObject.transform.localPosition.x, startpos.x, Time.deltaTime * 10);
            NewPos.y = Mathf.Lerp(gameObject.transform.localPosition.y, startpos.y, Time.deltaTime * 10);
            NewPos.z = Mathf.Lerp(gameObject.transform.localPosition.z, startpos.z, Time.deltaTime * 10);
            gameObject.transform.localPosition = NewPos;
            Quaternion NewRot;
            NewRot.x = Mathf.LerpAngle(gameObject.transform.localRotation.x, startrot.x, Time.deltaTime * 10);
            NewRot.y = Mathf.LerpAngle(gameObject.transform.localRotation.y, startrot.y, Time.deltaTime * 10);
            NewRot.z = Mathf.LerpAngle(gameObject.transform.localRotation.z, startrot.z, Time.deltaTime * 10);
            NewRot.w = Mathf.LerpAngle(gameObject.transform.localRotation.w, startrot.w, Time.deltaTime * 10);
            gameObject.transform.localRotation = NewRot;
            gameObject.GetComponent<Animator>().enabled = true;
        }
        
    }
    void runaniminvoke()
    {
        runanimcooldown = false;
    }
    void walkaniminvoke()
    {
        walkanimcooldown = false;
    }
    void Update()
    {
        if (!decoy)
        {
           
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name) && !Input.GetKey(KeyCode.LeftShift) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name) && !Player.gameObject.GetComponent<MovementReworked>().moving)
            {
                gameObject.GetComponent<Animator>().Play("New State");
                runanimcooldown = true;
                Invoke("runaniminvoke", 0.2f);
                walkanimcooldown = true;
                Invoke("walkaniminvoke", 0.2f);
            }
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name) && !Player.GetComponent<MovementReworked>().moving && Input.GetKey(KeyCode.LeftShift))
            {
                NormalizeWeapon();
                NormalizeWeapon();
                NormalizeWeapon();
                gameObject.GetComponent<Animator>().Play("New State");
                runanimcooldown = true;
                Invoke("runaniminvoke", 0.2f);
                walkanimcooldown = true;
                Invoke("walkaniminvoke", 0.2f);
            }
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnimCont_Clip.name) && !Player.GetComponent<MovementReworked>().moving || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnim_Clip.name) && !Player.GetComponent<MovementReworked>().moving)
            {
                NormalizeWeapon();
                walkanimcooldown = true;
                Invoke("walkaniminvoke", 0.2f);
                runanimcooldown = true;
                Invoke("runaniminvoke", 0.2f);
                gameObject.GetComponent<Animator>().Play("New State");
            }

            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State") && !walkanimcooldown && Player.GetComponent<MovementReworked>().moving && !Input.GetKey(KeyCode.LeftShift))
            {
                NormalizeWeapon();
                gameObject.GetComponent<Animator>().Play(WalkAnim_Clip.name);
            }
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State") || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnim_Clip.name) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnimCont_Clip.name))
            {
                if (!Player.GetComponent<MovementReworked>().IsGrounded)
                {
                    gameObject.GetComponent<Animator>().speed = 0;

                    if (!Player.GetComponent<MovementReworked>().OnLadder && !Player.GetComponent<MovementReworked>().InWater)
                    {
                        if (Player.GetComponent<MovementReworked>().PlayerVel.y > 0)
                        {
                            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(Mathf.Lerp(transform.localPosition.y, transform.localPosition.y - (Player.GetComponent<MovementReworked>().PlayerVel.y / 10), Time.deltaTime), movementAnimBaseY - 0.35f, movementAnimBaseY + 0.35f), transform.localPosition.z);

                        }
                        else
                        {
                            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(Mathf.Lerp(transform.localPosition.y, transform.localPosition.y - (Player.GetComponent<MovementReworked>().PlayerVel.y / 10), Time.deltaTime), movementAnimBaseY - 0.35f, movementAnimBaseY + 0.35f), transform.localPosition.z);

                        }

                    }

                }
                else
                {
                    if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name))
                    {
                        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, movementAnimBaseY, Time.deltaTime * 15), transform.localPosition.z);
                    }

                    gameObject.GetComponent<Animator>().speed = 1;
                }
            }
            else
            {
                gameObject.GetComponent<Animator>().speed = 1;
            }

            if (gameObject.GetComponent<Animator>().IsInTransition(0))
            {
                if (!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name) || !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnim_Clip.name) || !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnimCont_Clip.name))
                {

                    NormalizeWeapon();

                }

            }

            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State"))
            {
                NormalizeWeapon();
            }
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State") || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Reload_Clip.name) && !RPGIcon || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Reload_Clip.name) && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f && !RPGIcon || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(MovementToReloadClip.name) && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Action1_Clip.name) && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnim_Clip.name) && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnimCont_Clip.name) && gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f)
            {
                gameObject.transform.parent.GetComponent<sway>().enabled = true;
            }
            else if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(MovementToReloadClip.name) && RPGIcon)
            {
                gameObject.transform.parent.GetComponent<sway>().enabled = false;
            }
            else
            {
                gameObject.transform.parent.GetComponent<sway>().enabled = false;
            }
            inWater = Player.GetComponent<MovementReworked>().InWater;
            if (ObeyInventory)
            {
                InventoryExtended = Inventory.GetComponent<InventorySelecter>().InventoryExtended;
            }
            if (!Player.GetComponent<MovementReworked>().interacting && !InventoryExtended)
            {
                if (Player.GetComponent<MovementReworked>().moving && Input.GetKey(KeyCode.LeftShift))
                {
                    if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State") && !runanimcooldown && !blockmovement && !Input.GetKey(KeyCode.Mouse0) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnimCont_Clip.name) && !runanimcooldown && !blockmovement && !Input.GetKey(KeyCode.Mouse0) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(WalkAnim_Clip.name) && !runanimcooldown && !blockmovement && !Input.GetKey(KeyCode.Mouse0))
                    {

                        NormalizeWeapon();

                        gameObject.GetComponent<Animator>().Play(Movement_Clip.name);
                    }

                    else
                    {
                        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State"))
                        {
                            NormalizeWeapon();
                        }
                    }

                }

                else
                {
                    if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State"))
                    {
                        NormalizeWeapon();
                    }
                }
                if (Input.GetKeyDown(KeyCode.R) && CurrentAmmo < MaxAmmo && !normalization && !Input.GetKey(KeyCode.Mouse0) && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name))
                {
                    Reloading();
                }
                whenScoped();

                if (RPGIcon)
                {
                    GrenadeIcon.active = false;
                    RpgImage.active = true;
                    AmmoImage.active = false;
                    MeleeIcon.active = false;
                }
                if (AmmoIcon)
                {
                    GrenadeIcon.active = false;
                    RpgImage.active = false;
                    AmmoImage.active = true; MeleeIcon.active = false;
                }
                if (Melee)
                {
                    GrenadeIcon.active = false;
                    RpgImage.active = false;
                    AmmoImage.active = false;
                    MeleeIcon.active = true;
                    AxeHandler();
                    AmmoText.gameObject.GetComponent<Text>().text = "";

                }
                if (Automatic && Input.GetKeyUp(KeyCode.Mouse0) || Automatic && CurrentAmmo <= 0)
                {
                    BulletFlash.active = false;
                }
            }
        }
        
    }
        void FixedUpdate()
        {




        if (decoy) { gameObject.transform.GetChild(0).transform.gameObject.GetComponent<WeaponControl>().enabled = gameObject.GetComponent<WeaponControl>().enabled; }
        else if (!decoy) {
            if (Player.GetComponent<MovementReworked>().InWater != true && !Melee)
            {
                AmmoText.gameObject.GetComponent<Text>().text = CurrentAmmo + "/" + CurrentReserve;

                if (!ShootingCooldown && Input.GetKeyDown(KeyCode.Mouse0) && !Automatic && !hasScope && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Reload_Clip.name) && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(MovementToReloadClip.name))
                {


                    if (CurrentAmmo > 0)
                    {
                        //BulletFlash.transform.Rotate(0, 90, BulletFlash.transform.eulerAngles.z + 10f, Space.World);
                        if (BulletFlash != null)
                        {
                            BulletFlash.transform.localEulerAngles = new Vector3(0, 180, BulletFlash.transform.localEulerAngles.z + 10f);
                        }
                        
                        //Instantiate(fakebullet, fakebulletspawn.transform,true);
                        Shoot();
                        Audio("Action1");
                        Animate("Action1");
                    }
                    else
                    {
                        if (!emptymagaudiosent)
                        {
                            StartCoroutine(EmptyMagSounder());
                        }
                        
                    }


                }
                if (!ShootingCooldown && Input.GetKeyDown(KeyCode.Mouse0) && hasScope && !Automatic && weaponScoped && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Reload_Clip.name) && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(MovementToReloadClip.name))
                {


                    if (CurrentAmmo > 0)
                    {
                        Shoot();
                        Audio("Action1");

                    }
                    else
                    {
                        if (!emptymagaudiosent)
                        {
                            StartCoroutine(EmptyMagSounder());
                        }
                    }


                }
                
                if(!Input.GetKey(KeyCode.Mouse0) && Automatic)
                {
                    
                }
               
                    if (!ShootingCooldown && Input.GetKey(KeyCode.Mouse0) && Automatic && !hasScope && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Reload_Clip.name) && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(MovementToReloadClip.name))
                {


                    if (CurrentAmmo > 0)
                    {
                        Shoot();


                       
                        
                        Audio("Action1");
                        Animate("Action1");
                    }
                    else
                    {
                        if (!emptymagaudiosent)
                        {
                            StartCoroutine(EmptyMagSounder());
                        }
                    }
                }
                
                if (!weaponScoped && Input.GetKeyDown(KeyCode.Mouse1) && hasScope)
                {
                   
                    gameObject.transform.localPosition = startpos;
                    Animate("Action2");
                    weaponScoped = true;
                    Audio("Action2");
                }
                else if (weaponScoped && Input.GetKeyDown(KeyCode.Mouse1) && hasScope)
                {
                    
                    weaponScoped = false;
                    Audio("Action2");
                }
            }
        }
    }

    IEnumerator EmptyMagSounder()
    {
        if (!emptymagaudiosent)
        {
            emptymagaudiosent = true;
            Audio("EmptyMag");
        }
        yield return new WaitForSeconds(0.3f);
        emptymagaudiosent = false;
    }
    void AxeHandler()
    {
        if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State")&&!axebool){
            gameObject.transform.localRotation = startrot;
            gameObject.transform.localPosition = startpos;
            gameObject.transform.parent.GetComponent<sway>().enabled = true;
            axebool = true;
        }
        else if(!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            axebool = false;
        }
        if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State")|| gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Switch_Clip.name)) { MeleeCollider.GetComponent<BoxCollider>().enabled = false; }
        if(!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Action2_Clip.name) && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Action1_Clip.name)) {
            if (!ShootingCooldown && Input.GetKeyDown(KeyCode.Mouse0))
            {
                gameObject.GetComponent<Animator>().Play(Action1_Clip.name);
                Player.GetComponent<AudioSource>().PlayOneShot(Action1_Audio);
                MeleeCollider.GetComponent<BoxCollider>().enabled = true;
            }
            else if (!ShootingCooldown && Input.GetKeyDown(KeyCode.Mouse1))
            {
                
                Player.GetComponent<AudioSource>().PlayOneShot(Action2_Audio);
                gameObject.GetComponent<Animator>().Play(Action2_Clip.name);
                MeleeCollider.GetComponent<BoxCollider>().enabled = true;
            }
        }
        
    }
    void whenScoped()
    {
        if (weaponScoped && hasScope)
        {
            
            if (gameObject.layer != 3)
            {
                gameObject.layer = 3;
                foreach (Transform g in gameObject.transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 3;
                }
                MainCamera.GetComponent<Camera>().fieldOfView = 30;
            }
            
        }
        else if (!weaponScoped && hasScope&!inWater)
        {
            if (gameObject.layer != 7)
            {
                gameObject.layer = 7;
                foreach (Transform g in gameObject.transform.GetComponentsInChildren<Transform>())
                {
                    g.gameObject.layer = 7;
                }
                MainCamera.GetComponent<Camera>().fieldOfView = 60;
            }
                
        }
    }
    void ShootInvoke()
    {
        normalization = false;
        gameObject.GetComponent<Animator>().enabled = true;
    }
    void Shoot ()
    {
        if (CurrentAmmo > 0)
        {
            blockmovement = true;
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name) && !normalization || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name)&&!normalization)
            {
                normalization = true;
                NormalizeWeapon();
                gameObject.GetComponent<Animator>().Play("New State");
                gameObject.GetComponent<Animator>().enabled = false;
                Invoke("ShootInvoke", 0.4f);
            }


            if (!normalization)
            {
               Cross.GetComponent<CrossAligner>().activatebounce = true;
                MainCamera.GetComponent<Rotation>().activatebounce = true;
                Player.GetComponent<Rotation>().activatebounce = true;
                Instantiate(fakebullet, fakebulletspawn.transform);


                StopCoroutine(DisableFlash());


                if (BulletFlash != null && !Automatic)
                {
                    BulletFlash.transform.eulerAngles = new Vector3(BulletFlash.transform.rotation.x, BulletFlash.transform.rotation.y, Random.Range(0f, 360f));
                    BulletFlash.active = true;
                    if (!flashdisablerunning)
                    {
                        StartCoroutine(DisableFlash());

                    }
                }
                if (ShootingRay)
                {
                    bool successhit;
                    RaycastHit Hit;
                    successhit = Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out Hit);
                    Vector3 normal = Hit.normal;
                    GameObject spawn = Instantiate(ImpactPrefab, Hit.point, new Quaternion(ImpactPrefab.transform.rotation.x, 0, ImpactPrefab.transform.rotation.z, ImpactPrefab.transform.rotation.w));

                    if (Mathf.Max(Mathf.Abs(normal.x), Mathf.Abs(normal.y), Mathf.Abs(normal.z)) == Mathf.Abs(normal.x))
                    {
                        spawn.GetComponent<explosionManage>().x = true;
                    }
                    if (Mathf.Max(Mathf.Abs(normal.x), Mathf.Abs(normal.y), Mathf.Abs(normal.z)) == Mathf.Abs(normal.y))
                    {
                        spawn.GetComponent<explosionManage>().y = true;
                    }
                    if (Mathf.Max(Mathf.Abs(normal.x), Mathf.Abs(normal.y), Mathf.Abs(normal.z)) == Mathf.Abs(normal.z))
                    {
                        spawn.GetComponent<explosionManage>().z = true;

                    }
                    if (successhit)
                    {
                        if (Hit.transform.gameObject.GetComponent<GotHit>() != null)
                        {
                            Hit.transform.gameObject.GetComponent<GotHit>().hit = true;
                        }
                        if (Hit.transform.gameObject.GetComponent<HitDetection>() != null)
                        {
                            Hit.transform.gameObject.GetComponent<HitDetection>().hit = true;
                        }
                    }




                }

                CurrentAmmo -= 1;
                if (RPGIcon)
                {
                    ShootingCooldown = true;
                    Invoke("awaitfunc", 0.5f);
                }

                if (AmmoIcon)
                {
                    if (Automatic)
                    {
                        BulletFlash.transform.Rotate(BulletFlash.transform.eulerAngles.x, BulletFlash.transform.eulerAngles.y, BulletFlash.transform.eulerAngles.z + 10f, Space.Self);


                        BulletFlash.active = true;

                        flashenabledagain = true;
                        if (!flashdisablerunning)
                        {
                            StartCoroutine(DisableFlash());

                        }
                        ShootingCooldown = true;
                        Invoke("awaitfunc", (30 * Time.deltaTime) / BPM);
                    }
                    else
                    {
                        ShootingCooldown = true;
                        Invoke("awaitfunc", 0.3f);
                    }

                }
            }
            
        }
        blockmovement = false;
    }
    void Audio (string Action)
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name))
        {
            normalization = true;
            NormalizeWeapon();
            Invoke("ShootInvoke", 0.4f);
        }


        if (!normalization) {if (Action == "Action1")
            {
                Player.GetComponent<AudioSource>().PlayOneShot(Action1_Audio);


            }
        }
            if (Action=="Reload")
        {
            Player.GetComponent<AudioSource>().PlayOneShot(Reload_Audio);
        }
        
        else if (Action == "Action2")
        {
            if (Action2_Audio != null)
            {
                Player.GetComponent<AudioSource>().PlayOneShot(Action2_Audio);
            }
            
        }
        else if (Action == "EmptyMag")
        {
            if (EmptyMagazine_Audio != null)
            {
                Player.GetComponent<AudioSource>().PlayOneShot(EmptyMagazine_Audio);
            }
            
        }
    }
    void Animate(string Action)
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name))
        {
            normalization = true;
            NormalizeWeapon();
            Invoke("ShootInvoke", 0.4f);
        }


        if (!normalization)
        {
            if (Action == "Action1")
            {
                gameObject.GetComponent<Animator>().Play(Action1_Clip.name);
            }
            else if (Action == "Action2")
            {
                gameObject.GetComponent<Animator>().Play(Action2_Clip.name);
            }
        }
    }
    void Reloading()
    {
        if (hasScope)
        {
            if (weaponScoped)
            {
                weaponScoped = false;
            }
        }
        if (MaxAmmo < CurrentReserve)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, startpos.y, Time.deltaTime * 20), transform.localPosition.z);
            ShootingCooldown = true;
            CurrentAmmo = MaxAmmo;
            CurrentReserve -= MaxAmmo;
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name)){
               
                gameObject.transform.parent.GetComponent<sway>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = false;
                
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Animator>().Play(MovementToReloadClip.name); Audio("Reload");
                gameObject.transform.parent.GetComponent<sway>().enabled = true;
            }

            else
            {
                ReloadInvoke();
            }
             
           
        }
        else if (CurrentReserve > 0 && CurrentReserve <= MaxAmmo)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, startpos.y, Time.deltaTime * 20), transform.localPosition.z);
            ShootingCooldown = true;
            CurrentAmmo = CurrentReserve;
            if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_ContClip.name) || gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(Movement_Clip.name))
            {
              
                gameObject.transform.parent.GetComponent<sway>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = false;
                
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Animator>().Play(MovementToReloadClip.name); Audio("Reload");
                gameObject.transform.parent.GetComponent<sway>().enabled = true;
            }

            else
            {
                ReloadInvoke();
            }
            CurrentReserve = 0;
            
        }
        else if (CurrentReserve==0)
        {
            StartCoroutine(NoAmmoFlash());
        }
        
        if (RPGIcon)
        {
            StartCoroutine(AwaitCommand(1f, false));
        }
        if (AmmoIcon)
        {
            StartCoroutine(AwaitCommand(0.5f, false));
        }
        
        

    }
    void ReloadInvoke()
    {
        NormalizeWeapon();
        gameObject.GetComponent<Animator>().Play(Reload_Clip.name); Audio("Reload");
        walkanimcooldown = true;
        Invoke("walkaniminvoke", 2f);
        runanimcooldown = true;
        Invoke("runaniminvoke", 2f);
    }
    void awaitfunc()
    {
        ShootingCooldown = false;
    }
    IEnumerator AwaitCommand(float time,bool DisableRay)
    {
        ShootingCooldown = true;
        //yield return new WaitForSeconds(0.025f);
        
        
            
        if (Automatic)
        {
            yield return new WaitForSeconds((40 * Time.deltaTime) / BPM);
            
        }
        else
        {
            yield return new WaitForSeconds(time);
        }
        ShootingCooldown = false;
        
       
    }
    IEnumerator NoAmmoFlash()
    {
        AmmoText.gameObject.GetComponent<Text>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        AmmoText.gameObject.GetComponent<Text>().color = Color.black;
        yield return new WaitForSeconds(0.1f);
        AmmoText.gameObject.GetComponent<Text>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        AmmoText.gameObject.GetComponent<Text>().color = Color.black;
        yield return new WaitForSeconds(0.1f);
        AmmoText.gameObject.GetComponent<Text>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        AmmoText.gameObject.GetComponent<Text>().color = Color.black;
    }
    IEnumerator DisableFlash()
    {
        flashdisablerunning = true;
           flashenabledagain = false;
        yield return new WaitForSeconds(0.2f);
        if (flashenabledagain == false)
        {
            BulletFlash.active = false;
        }
        flashdisablerunning = false;
    }
    IEnumerator DisableFlashNonAuto()
    {
       
        yield return new WaitForSeconds(0.1f);
        
            BulletFlash.active = false;
       
    }
}
