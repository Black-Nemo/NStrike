using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class karakterHareketPC : NetworkBehaviour
{
    [SyncVar]public int Mode;

    public Animator animator;
    public GameObject Player;
    public GameObject playerCamera;




    public bool HareketEt = true;

    public AudioSource walking;

    public merdiveneCikma merdivenecikma;

    public GameObject govde;









    public CharacterController characterController;

    public float playerWalkSpeed;
    public float playerRunSpeed;
    public float jumpHeight;

    public bool useGravity;
    public float gravity = -9.81f;

    public float playerSpeed;

    public Transform graundCheck;
    public float groundDistance = 0.2f;
    public LayerMask mask;

    bool isGrounded;


    Vector3 velocity;

    public float x;
    public float z;

    void Start()
    {
    }

    public void Update()
    {
        if(isLocalPlayer){
            if(HareketEt){
                if(useGravity){
                    gravity = -19.62f;
                }else{
                    gravity = 0f;
                }

                isGrounded = Physics.CheckSphere(graundCheck.position,groundDistance,mask);
                Hareket();
            }
            Rot();

        }
        
    }
    public void Hareket(){

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        KeyCode forward = KeyCode.W;
        KeyCode back = KeyCode.S;
        KeyCode left = KeyCode.A;
        KeyCode right = KeyCode.D;
        KeyCode jump = KeyCode.Space;
        KeyCode run = KeyCode.LeftShift;


        if(Input.GetKey(forward)){
            if(Input.GetKey(run)){
                playerSpeed = playerRunSpeed;
            }else{
                playerSpeed = playerWalkSpeed;
            }
            z = 1;
            
        }
        if(Input.GetKey(back)){
            z = -1;
            playerSpeed = playerWalkSpeed;
        }
        if(Input.GetKey(left)){
            x = -1;
            playerSpeed = playerWalkSpeed;
        }
        if(Input.GetKey(right)){
            x = 1;
            playerSpeed = playerWalkSpeed;
        }

        if(Input.GetKey(forward)||Input.GetKey(back)){
        }else{
            z = 0;
        }

        if(Input.GetKey(right)||Input.GetKey(left)){
        }else{
            x = 0;
        }

        Vector3 move = transform.right * x +transform.forward * z;

        characterController.Move(move * playerSpeed *Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(jump)){
            if(isGrounded){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }








        if(Input.GetKey(forward)||Input.GetKey(back)||Input.GetKey(left)||Input.GetKey(right)){
            if(Input.GetKey(KeyCode.LeftShift)){
                _CmdMode(2);
            }else{
                _CmdMode(1);
            }
        }else{
            _CmdMode(0);
        }
        if(Input.GetKey(KeyCode.LeftControl)){
            govde.transform.localScale = new Vector3(0.7f,0.5f,0.7f);
            govde.transform.localPosition = new Vector3(0,0.2f,0);
            characterController.height = 1f;
        }else{
            govde.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
            govde.transform.localPosition = new Vector3(0,0,0);
            characterController.height = 1.4f;
        }
        
        //transform.Translate(yatayHareket*playerSpeed*Time.deltaTime,0,dikeyHareket*playerSpeed*Time.deltaTime);
        if(merdivenecikma.Merdivendemi == true){
            useGravity = false;
            if(x != 0||z != 0){
                characterController.Move(Vector3.up * 1);
                //transform.Translate(0,1*Time.deltaTime,0);
            }   
        }
        else{
            useGravity = true;
        }
    }

    [Command]
    public void _CmdMode(int _Mode){
        Mode =_Mode;
        _RpcMode();
    }


    float zaman= 3.5f;
    [ClientRpc]
    public void _RpcMode(){
        animator.SetInteger("Hareket",Mode);
        zaman+=1*Time.deltaTime;
        if(Mode == 1){
            if(zaman>=3.5){
                walking.Play();
                zaman =0;
            }
        }else{
            walking.Stop();
            zaman = 3.5f;
        }
        
    }


    public float mouseSensivity = 100f;
    float xRotation = 0f;

    void Rot(){
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//sınırlama getirir.
        playerCamera.transform.localRotation = Quaternion.Euler(0,90,xRotation);
        Player.transform.Rotate(Vector3.up * mouseX);
    }



}
