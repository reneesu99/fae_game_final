using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public float speed;
    public Animator animator;
    public Quest quest;
    public int gold;
    private void Awake()
    {
        inventory = new Inventory(12);
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(horizontal, vertical);
        direction.Normalize();
        AnimateMovement(direction);

        transform.position += direction * speed * Time.deltaTime;
    }
    
    void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Collectible")) 
        {
            Collectible collectible = other.GetComponent<Collectible>();
            inventory.Add(collectible);
            if (quest.goal.type == collectible.type)
            {
                quest.goal.currentAmount ++;
            }
            Destroy(other.gameObject);
        }

    }
}
