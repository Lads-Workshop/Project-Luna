using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public int spd;
    public int runSpeed;
    public int rollSpeed;

    private Rigidbody2D charRigid;

    public Animator animEnemy;

    private Vector3 change;

    private Animator anim;

    public BoxCollider2D attackTrigger;

    public UI_Engine uiScript;


    // Start is called before the first frame update
    void Start()
    {
        uiScript = uiScript.GetComponent<UI_Engine>();

        anim = GetComponent<Animator>();

        charRigid = GetComponent<Rigidbody2D>();

        attackTrigger.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        change = Vector2.zero;
        change.x = Input.GetAxis("Horizontal");
        change.y = Input.GetAxis("Vertical");

        KeyboardMovement(); //Handles Player movement
        MouseEvents();

    }
    void KeyboardMovement()
    {

        //Character Animation Control

        anim.SetFloat("isWalkingVertical", change.y);
        anim.SetFloat("isWalkingHorizontal", change.x);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) //Handle Running
        {
            charRigid.MovePosition(transform.position + change.normalized * runSpeed * Time.deltaTime);
        }
        else if(Input.GetMouseButton(1))
        {
            
            StartCoroutine("Roll");
            
        }
        else
        {
            charRigid.MovePosition(transform.position + change.normalized * spd * Time.deltaTime);
        }

        


    }
    void MouseEvents() //Attack 
    {
        if(Input.GetMouseButton(0))
        {
            anim.SetBool("isAttack", true);
            attackTrigger.enabled = true;
        }
        else
        {
            anim.SetBool("isAttack", false);
            attackTrigger.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            animEnemy.SetBool("isDead", true);
        }
        else if (other.gameObject.CompareTag("Death_Shop"))
        {
            uiScript.check = true;
            uiScript.EnterDeathShop("Press E To Enter Death Shop");
            Debug.Log("true");
        }
        else
        {
            animEnemy.SetBool("isDead", false);
        }
 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        uiScript.EnterDeathShop("");
    }
    IEnumerator Roll()
    {
        charRigid.MovePosition(transform.position + change.normalized * rollSpeed * Time.deltaTime);
        anim.SetBool("isRoll", true);
        Debug.Log("true");
        yield return new WaitForSeconds(.2f);
        charRigid.MovePosition(transform.position + change.normalized * spd * Time.deltaTime);
        anim.SetBool("isRoll", false);

    }
}

