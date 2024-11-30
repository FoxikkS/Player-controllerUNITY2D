using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed; //скорость игрока
    [SerializeField] private float sprintSpeed; //скорость при нажатом шифте
    [SerializeField] private float jumpForce; //сила прыжка
    [SerializeField] private UserInterface userInterface; //пользоватский интерфейс
    
    private bool _isSprinting = false; //флаг проверки на бег персонажа
    private Rigidbody2D _rb; //получаю ригибоди персонажа
    private GroundStatus _checkingGround; //флаг проверки на тег Ground под ногами
    
    public int health = 100;//здоровье персонажа

    
    void Start()
    {
        //получаю ригибоди для управление персонажем
        _rb = GetComponent<Rigidbody2D>();
        _checkingGround = new GroundStatus();
    }

    void Update()
    {
        //получаю ввод по горизонтали
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space) && _checkingGround.isGrounded)
        {
            Jump();
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
        else
        {
            _isSprinting = false;
        }
        
        //если жизнь игрока меньше или = 0, игрок удаляется а за ним выходит панель с кнопками
        if (health <= 0)
        {
            Destroy(gameObject);
            userInterface.ShowPanelMenuOnDie();
        }
        
        Move(horizontalInput);
    }
    
    //управление персонажем
    private void Move(float horizontalInput)
    {
        if (_isSprinting)
        {
            _rb.velocity = new Vector2(horizontalInput * sprintSpeed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(horizontalInput * moveSpeed, _rb.velocity.y);
        }
    }
    
    //бег
    private void Sprint()
    {
        _isSprinting = true;
    }
    
    //прыжок
    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
    }
    
    //проверка находится ли персонаж в воздухе или стоит на блоке с тегом Ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _checkingGround.CheckOnGround(collision.collider);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _checkingGround.NotOnGround();
    }
}

public class GroundStatus
{
    public bool isGrounded;

    public void NotOnGround()
    {
        isGrounded = false;
    }

    public void CheckOnGround(Collider2D collider)
    {
        if (collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
