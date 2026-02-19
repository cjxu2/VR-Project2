using TMPro;
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
    public GameObject door_wall;

    public GameObject todo_ui;

    TMP_Text todo_list_text;

    string default_text = "\nRemember to put items\nin bag before you go!\n\n(Activate bag to put\nstuff in)\n\n";

    Animator door_ani;

    void Start()
    {
        door_ani = door.GetComponent<Animator>();
        todo_list_text = todo_ui.GetComponent<TMP_Text>();
        UpdateText();
    }

    void UpdateText()
    {
        string text1 = default_text;

        for (int i = 0; i < order_tag.Length; i++)
        {
            text1 += (i+1) + ") " + order_tag[i] + "[";
            if (idx > i)
            {
                text1 += "X";
            }
            else
            {
                text1 += " ";
            }

            text1 += "]\n";
        }
        todo_list_text.text = text1;
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
            UpdateText();
        }
        if (idx >= order_tag.Length)
        {
            door_ani.SetTrigger("Open");
            door_wall.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
