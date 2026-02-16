using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketFunc : MonoBehaviour
{
    public Animator ani;
    float delay = 0;
    float delay_time = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && delay <= 0)
        {
            ani.SetTrigger("Use");
            delay = delay_time;
        }

        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
    }

    public void TestIn(SelectEnterEventArgs args)
    {
        GameObject socketedObject = args.interactableObject.transform.gameObject;

        Debug.Log("IN: " + socketedObject);
    }

    public void TestOut(SelectExitEventArgs args)
    {
        GameObject socketedObject = args.interactableObject.transform.gameObject;

        Debug.Log("OUT: " + socketedObject);
    }

    public void TestActivate(ActivateEventArgs args)
    {
        GameObject socketedObject = args.interactableObject.transform.gameObject;

        Debug.Log("ACT: " + socketedObject);
    }    
    
    public void TestDeactivate(DeactivateEventArgs args)
    {
        GameObject socketedObject = args.interactableObject.transform.gameObject;

        Debug.Log("DEACT: " + socketedObject);
    }
}
