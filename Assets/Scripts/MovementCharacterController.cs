using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpForce = 3.0f;
    [SerializeField]
    private float moveDistanceZ = 3.0f;
    private bool isGrounded = false;
    private Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    private Transform mainCamera;
    private CharacterController characterController;
    private Animator animator;

    //애니메이션
    [SerializeField]
    private float walkSpeed = 2.0f;
    [SerializeField]
    private float runSpeed = 5.0f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        animator.SetFloat("horizontal", x * offset);
        animator.SetFloat("vertical", z * offset);

        moveSpeed = Mathf.Lerp(walkSpeed, runSpeed, Input.GetAxis("Sprint"));

        Vector3 dir = mainCamera.rotation * new Vector3(x, 0, z);
        moveDirection = new Vector3(dir.x, moveDirection.y, dir.z);

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded == true)
        {
            animator.SetTrigger("onJump");
            moveDirection.y = jumpForce;
        }

        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }



        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log($"{hit.gameObject.name} 오브젝트와 충돌");
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object") && !isGrounded)
        {
            Debug.Log("충돌");
            isGrounded = true;
            MoveBack();
        }
    }

    private void MoveBack()
    {
        moveDirection.y = jumpForce;
        Vector3 moveBack = transform.forward * -moveDistanceZ;
        Debug.Log("이동 거리: " + moveBack.magnitude);
        characterController.Move(moveBack);

        isGrounded = false;
    }
}
