using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 _moveInput;
    public Rigidbody2D rb2d;
    public Transform gunArm;
    private Camera _cam;
    public Animator anim;
    // reference to the bullet that we want to fire
    public GameObject bullet;
    //from where we are fireing the bullet (position on the world)
    public Transform fireStartPoint;
    // Start is called before the first frame update
    public float timeBetweenBullets;
    private float bulletCounter;
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        _moveInput.Normalize();
        
        // transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed,
        //     moveInput.y * Time.deltaTime * moveSpeed, 0f);
        rb2d.velocity = _moveInput * moveSpeed;
        // position of mouse
        Vector3 mousePos = Input.mousePosition;
        // position of main camera
        Vector3 screenPoint = _cam.WorldToScreenPoint(transform.localPosition);
        
        //rotating player
        if (mousePos.x < screenPoint.x) // to the left of the player
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            gunArm.localScale = new Vector3(1f, 1f, 1f);
        }

        // ratate gun
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        // angle that gun should point to
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0)) // if lpm  is clicked
        {
            // create a copy of specific object
            Instantiate(bullet, fireStartPoint.position, fireStartPoint.rotation);
            bulletCounter = timeBetweenBullets;
        }

        if (Input.GetMouseButton(0))
        {
            bulletCounter -= Time.deltaTime;
            if (bulletCounter <= 0)
            {
                Instantiate(bullet, fireStartPoint.position, fireStartPoint.rotation);
                bulletCounter = timeBetweenBullets;
            }
                
        }
        
        // animation of walking
        if (_moveInput != Vector2.zero)
        {
            anim.SetBool("isPlayerMoving", true);
        }
        else
        {
            anim.SetBool("isPlayerMoving", false);
        }
    }
}
