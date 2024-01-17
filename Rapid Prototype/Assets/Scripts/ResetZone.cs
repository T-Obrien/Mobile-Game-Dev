using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetZone : MonoBehaviour
{
    public MeshCollider PitchCollider;
    public float coolx;
    public float coolz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coolx = PitchCollider.transform.position.x;
        coolz = PitchCollider.transform.position.z;
    }

    private void OnTriggerEnter(UnityEngine.Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit!");
            collision.gameObject.transform.position = new Vector3(coolx, -10.0f, coolz);
        }
    }
}
