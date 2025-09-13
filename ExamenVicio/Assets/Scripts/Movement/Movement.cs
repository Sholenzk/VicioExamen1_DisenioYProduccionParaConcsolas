using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Movement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    
    public LookDirection lookDirection;
    public Shooting shooting;
    public RectTransform joysticArea;
    
    public Button ShotButton;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ShotButton.onClick.AddListener(ShotingButton);
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void GetInput()
    {
        
        moveDir = Vector2.zero;
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (RectTransformUtility.RectangleContainsScreenPoint(joysticArea, touch.position))
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved ||
                    touch.phase == TouchPhase.Stationary)
                {
                    Vector2 localPoint;
                    
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(joysticArea, touch.position, null, out localPoint);
                        
                    Vector2 pivotAdjustment = new Vector2(localPoint.x /(joysticArea.rect.width / 2f),
                        localPoint.y /(joysticArea.rect.height / 2f));
                    
                    moveDir = Vector2.ClampMagnitude(pivotAdjustment, 1f);
                }
            }
            
        }
        
        /*
         
      //  Movimiento de teclado
    
         float xAxis = Input.GetAxisRaw("Horizontal");
         float yAxis = Input.GetAxisRaw("Vertical");
         moveDir = new Vector2(xAxis, yAxis).normalized;
        
        if (Input.GetMouseButtonDown(0))
        {
            shooting.Shoot();
        } 
        */
    }

    public void ShotingButton()
    {
        shooting.Shoot();
    }

    public void Move()
    {
        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }
}

