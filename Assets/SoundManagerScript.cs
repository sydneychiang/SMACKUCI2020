using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManagerScript : MonoBehaviour
{
    public static AudioClip playerDeathSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerDeathSound = Resources.Load<AudioClip>("Minecraft-death-sound.mp3");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Minecraft-death-sound":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
        }
    }
}
