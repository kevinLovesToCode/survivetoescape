using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CharcterControllerMovement : MonoBehaviour
{
    private Vector3 Velo;
    private Vector3 PlayerMovementInput;
    private float xRot;
    private Vector2 PlayerMouseInput;
    // Start is called before the first frame update
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController controller;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Jumpforce;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Gravity = 9.81f;
    public PhotonView view;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {

            PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            MovePlayer();
            MoveCamera();
        }else if (!view.IsMine)
        {
            PlayerCamera.gameObject.SetActive(false);

        }else
        {
            PlayerCamera.gameObject.SetActive(false);

        }
    }
        void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);
 
        if(controller.isGrounded)
        {
            Velo.y = -1f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Velo.y = Jumpforce;
            }

        }
        else
        {
            Velo.y -= Gravity * -2f * Time.deltaTime;
        }
        //y -= gravity * -2f 8 time.deltaTime
        controller.Move(MoveVector * Speed * Time.deltaTime);
        controller.Move(Velo * Time.deltaTime);
    }
    void MoveCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
