using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource buttonClick;
    public AudioSource push;
    public AudioSource socket;

    public void Click()
    {
        buttonClick.Play();
    }

    public void ButtonPuzzle()
    {
        push.Play();
    }

    public void Socket()
    {
        socket.Play();
    }
}
