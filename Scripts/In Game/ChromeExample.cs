using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromeExample : MonoBehaviour
{
     public float max_Speed;
     public float Jump_power;
     Rigidbody2D rigid;
     SpriteRenderer spriteRenderer;
     Animator animator;

     public string move_Chrome;
     public string Jump_Chrome;
     //public int chrome_Num;

    //Chrome;


    // Start is called before the first frame update
    void Awake()
    { 
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

       
        //Jump
        //Sword : space
        //Shield : up

        if (Input.GetButtonDown(Jump_Chrome) && !animator.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * Jump_power, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            Debug.Log("isJumping");
        }


        //stop speed
        if (Input.GetButtonUp(move_Chrome))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.4f, rigid.velocity.y);
        }

        //방향 전환
        if (Input.GetButtonDown(move_Chrome))
        {
            spriteRenderer.flipX = (Input.GetAxisRaw(move_Chrome) == -1);
        }

        //walk 애니메이션 전환
        if (rigid.velocity.normalized.x == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move by Key
        //Horizontal=좌우 또는 ad
        //Sword : a,d
        //Shield : right, left
        float horizontal = Input.GetAxisRaw(move_Chrome);
        rigid.AddForce(Vector2.right * horizontal, ForceMode2D.Impulse);

        //Max Speed
       if(rigid.velocity.x > max_Speed) //right max speed 
        {
            rigid.velocity = new Vector2(max_Speed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < max_Speed * (-1)) //left max speed 
        {
            rigid.velocity = new Vector2(max_Speed * (-1), rigid.velocity.y);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //착륙
        if (rigid.velocity.y < 0)
        {
            animator.SetBool("isJumping", false);
        }


        //맞았을 때
        if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);
        }

        
    }
    

    //피격
    void OnDamaged(Vector2 targetPos)
    {
        //피격 애니메이션
        animator.SetTrigger("getDamaged");

        //반작용
        int dirc = (transform.position.x - targetPos.x) > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 4.3f, ForceMode2D.Impulse);
        //Invoke("OffDameged", 2);

    }

    void OffDamaged()
    {

    }
}
