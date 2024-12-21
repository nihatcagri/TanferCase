using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips; 
    private AudioSource audioSource;

    #region Sinleton
    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
    
    #endregion
    public void PlaySound(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play(); 
        }
    }
}