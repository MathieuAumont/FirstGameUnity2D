using UnityEngine;

public class DestroyOverTi : MonoBehaviour
{
    public float lifetime;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        Destroy(gameObject, lifetime); 
    }
}
