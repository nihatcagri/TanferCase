using UnityEngine;
public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem flashParticle, circleParticle;
    
    #region Singleton
    public static ParticleManager Instance { get; set; }
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
    }
    #endregion
    public void FlashParticle()
    {
        flashParticle.Play();
        circleParticle.Play();
    }
    
}
