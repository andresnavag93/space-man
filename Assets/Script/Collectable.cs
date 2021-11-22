using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CollectableType {
    healthPotion,
    manaPotion,
    money
}

public class Collectable : MonoBehaviour
{
    public CollectableType type = CollectableType.money;
    private SpriteRenderer sprite;
    private CircleCollider2D itemCollider;
    bool hasBeenCollected = false;

    public int value = 1;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CircleCollider2D>();
    }

    void Show(){
        sprite.enabled = true;
        itemCollider.enabled = true;
        hasBeenCollected = false;
    }

    void Hide() {
        sprite.enabled = false;
        itemCollider.enabled = false;
    }

    void Collect() {
        Hide();
        hasBeenCollected = true;

        switch (this.type)
        {
            case CollectableType.money:
                GameManager.sharedInstance.CollectObject(this);
                break;
            case CollectableType.healthPotion:
                break;
            case CollectableType.manaPotion:
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag == "Player") {
            Collect();   
        }
    }
}
