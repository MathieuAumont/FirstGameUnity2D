using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundEffect;

    public AudioSource bgm, levelEndMusic;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySFX(int soundToPlay)
    {
        soundEffect[soundToPlay].Stop();

        soundEffect[soundToPlay].pitch = Random.Range(0.9f, 1.1f);
        soundEffect[soundToPlay].Play();

    }
}
