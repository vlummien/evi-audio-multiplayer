using QuickStart;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{
    public GameLogic gameLogic;
        
    [FormerlySerializedAs("playerPointsText")]
    public TextMesh playerPointsTextMesh;

    [FormerlySerializedAs("playerNameText")]
    public TextMesh playerNameTextMesh;

    public GameObject floatingInfo;

    private Material playerMaterialClone;
        
    public int playerPoints;

    private int selectedWeaponLocal = 1;
    public GameObject[] weaponArray;

    private Weapon activeWeapon;
    private float weaponCooldownTime;
        
        
        
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;

    public bool canMove = true;
        
    CharacterController characterController;

    void Awake()
    {
        GameObject gameLogicObject = GameObject.FindGameObjectWithTag("GameLogic");
        if (gameLogicObject != null)
        {
            GameLogic gameLogicScript = gameLogicObject.GetComponent<GameLogic>();
            if (gameLogicScript != null)
            {
                gameLogic = gameLogicScript;
            }
            else
            {
                Debug.Log("gameLogicScript not found");
            }
        }
        else
        {
            Debug.Log("gameLogicObject not found");
        }

        // disable all weapons
        foreach (var item in weaponArray)
        {
            if (item != null)
                item.SetActive(false);
        }


        if (selectedWeaponLocal < weaponArray.Length && weaponArray[selectedWeaponLocal] != null)
        {
            activeWeapon = weaponArray[selectedWeaponLocal].GetComponent<Weapon>();
        }
    }

    private void Start()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 0, 0);

        floatingInfo.transform.localPosition = new Vector3(0, -0.3f, 0.6f);
        floatingInfo.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            
        playerPoints = 0;
            
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 110.0f;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 4f;

        transform.Rotate(0, moveX, 0);
        transform.Translate(0, 0, moveZ);
        playerCamera.transform.localRotation = Quaternion.Euler(moveX, 0, 0);

        if (Input.GetMouseButtonDown(0))            {
            if (activeWeapon && Time.time > weaponCooldownTime && activeWeapon.weaponAmmo > 0)
            {
                weaponCooldownTime = Time.time + activeWeapon.weaponCooldown;
                RpcFireWeapon();
            }
        }
            
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion
    }

    void RpcFireWeapon()
    {
        //bulletAudio.Play(); muzzleflash  etc
        GameObject bullet = Instantiate(activeWeapon.weaponBullet, activeWeapon.weaponFirePosition.position,
            activeWeapon.weaponFirePosition.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * activeWeapon.weaponSpeed;
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.setPlayerScript(this);

        Destroy(bullet, activeWeapon.weaponLife);
    }


    public void RpcBulletHitTarget()
    {
        ScorePoint();
        playerPointsTextMesh.text = playerPoints.ToString();
        Debug.Log("hit");
    }
        
    void ScorePoint()
    {
        playerPoints += 1;
        if (playerPoints >= 3)
        {
            Debug.Log("win");
            EndGame();
        }
    }
        
    private void EndGame()
    {
        gameLogic.EndGame();
    }
}