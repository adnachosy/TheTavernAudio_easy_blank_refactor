using System;
using UnityEngine;
using UnityEngine.UI;

public class VCAControlDecibelToLinear : MonoBehaviour
{
    private FMOD.Studio.VCA vca;
    private Slider slider; 

    [Header("Ustawienia FMOD")] 
    [SerializeField] private string vcaPath;
    [Header("Zapisanie ustawień")]
    [SerializeField] private string saveKey;
    private void Start()
    {
        slider = GetComponent<Slider>();
        vca = FMODUnity.RuntimeManager.GetVCA(vcaPath); 
        
        float savedVolume = PlayerPrefs.GetFloat(saveKey, 0f);
        
        vca.setVolume(DecibelsToLinear(savedVolume)); 
        slider.value = savedVolume; 
    }
    public void SetVolume(float volume)
    {
        
        float linearVolume = DecibelsToLinear(volume); //przeliczenie db na float i zapisanie wyniku w zmiennej
        vca.setVolume(linearVolume); //używamy wyniku tych obliczeń do ustawienia głośności 
        
        PlayerPrefs.SetFloat(saveKey, volume);
    }
    
    // Konwerter dB na wartości float/dziesiętne
    private float DecibelsToLinear(float db)
    {
        if (db <= -40f) //jeżeli dB/value slidera spadnie do -40 to ustawiamy głośność na 0 / żeby zapobiec możliwości usłyszenia dźwięku nawet gdy slider jest na minimalnej wartości
        {
            return 0f;
        }
        
        // Wzór: 10 do potęgi (dB/20) - to już wynika typowo z fizyki/akustyki: 20 to stały mnożnik dla wartości amplitudy
        return Mathf.Pow(10f, db / 20f);
    }
}
