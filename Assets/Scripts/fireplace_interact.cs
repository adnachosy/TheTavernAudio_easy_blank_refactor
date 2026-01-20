using UnityEngine;
using FMODUnity;

public class fireplace_interact : MonoBehaviour, IInteractable
{
    [Header("Ognisko")]  
    [SerializeField] GameObject ognisko;

    [Header("DŸwiêki")]
    [SerializeField] private EventReference fireplaceStart;
    [SerializeField] private EventReference fireplaceStop;

    [Header("Stan")]
    [SerializeField] private bool isActive = true;

 public void Interact()
    {
        isActive = !isActive;

        if (ognisko != null)
        {
            ognisko.SetActive(isActive);
            PlayInteractSound();
        }
    }

    private void PlayInteractSound()
    {
        if (isActive)
        {
            RuntimeManager.PlayOneShot(fireplaceStart);
            
        }
        else
        {
            RuntimeManager.PlayOneShot(fireplaceStop);
        }
    }
}
