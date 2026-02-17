using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Backpack : MonoBehaviour
{
    public Animator ani;
    public GameObject socket;
    float delay = 0;
    float delay_time = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
    }

    public void OpenBag(ActivateEventArgs args)
    {
        if (delay <= 0)
        {
            ani.SetTrigger("Use");
            delay = delay_time;
            socket.SetActive(!socket.activeSelf);
        }
    }    
}
