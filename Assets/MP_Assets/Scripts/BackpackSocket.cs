using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BackpackSocket : MonoBehaviour, IXRSelectFilter, IXRHoverFilter
{
    
    public bool canProcess => isActiveAndEnabled;

    string[] order_tag = {"Pokedex", "Phone", "Berry", "Pokeball"};
    int idx = 0;

    public GameObject door;

    Animator door_ani;
    void Start()
    {
        door_ani = door.GetComponent<Animator>();
    }


    bool IXRSelectFilter.Process(IXRSelectInteractor interactor, IXRSelectInteractable interactable)
    {
        if (idx >= order_tag.Length)
        {
            return false;
        }
        return interactable.transform.CompareTag(order_tag[idx]);
    }

    public bool Process(IXRHoverInteractor interactor, IXRHoverInteractable interactable)
    {
        if (idx >= order_tag.Length)
        {
            return false;
        }
        return interactable.transform.CompareTag(order_tag[idx]);
    }

    public void DropItem(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag(order_tag[idx]))
        {
            Debug.Log("FOUND ITEM: " + order_tag[idx]);
            Destroy(args.interactableObject.transform.gameObject);
            idx++; 
        }
        if (idx >= order_tag.Length)
        {
            door_ani.SetTrigger("Open");
        }
    }
}
