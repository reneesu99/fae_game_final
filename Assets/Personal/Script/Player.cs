using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public Inventory inventory;
    // public Inventory toolbar;
    public InventoryManager inventory;

    public float speed;
    public Animator animator;
    public Quest quest;
    public int gold;
    private void Awake()
    {
        // inventory = new Inventory(27);
        // toolbar = new Inventory(9);
        inventory = GetComponent<InventoryManager>();
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

        Debug.Log("Dropping item");
        Item droppedItem = Instantiate(item, spawnLocation+spawnOffset, Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
        
    }
    private void Update()
    {
        if (!Dialogue.isOpen)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");


            Vector3 direction = new Vector3(horizontal, vertical);
            direction.Normalize();
            AnimateMovement(direction);

            transform.position += direction * speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);
            if(GameManager.instance.tileManager.IsInteractable(position))
            {
                GameManager.instance.tileManager.SetInteracted(position);
            }

        }
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
            Item item = other.GetComponent<Item>();
            inventory.Add("Backpack",item);
            if (quest.goal.itemName == item.data.itemName)
            {
                quest.goal.currentAmount ++;
            }
            Destroy(other.gameObject);
        }

    }
}
