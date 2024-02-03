using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine, GrabDrop }
    public enum ItemType { Static, Consumables }
    [Header("Attributes")]
    public InteractionType InteractType;
    public ItemType Type;
    [Header("Examine")]
    public string DesciprtionText;
    [Header("Custom EVents")]
    public UnityEvent CustomEvent;
    public UnityEvent ConsumeEvent;
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }
    public void Interact()
    {
        switch(InteractType)
        {
            case InteractionType.PickUp:
                FindObjectOfType<InventorySystem>().PickUp(gameObject);
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;
            case InteractionType.GrabDrop:
                FindObjectOfType<InteractionSystem>().GrabDrop();
                break;
            default:
                Debug.Log("NO ITEM");
                break;
                
        }
        CustomEvent.Invoke();
    }
}