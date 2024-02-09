using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{

    public KartAgent kartAgent;
    public RaycastHit raycastHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast under the cart
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit))
        {
            if (raycastHit.collider.gameObject.CompareTag("Gras"))
            {
                kartAgent.AddReward(-0.001f);
            }
            if (raycastHit.collider.gameObject.CompareTag("Road"))
            {
                kartAgent.AddReward(0.001f);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Kollision mit einer Wand: Reward -0.3");
            kartAgent.AddReward(-0.3f);
        }

        if (collision.gameObject.CompareTag("Gras"))
        {
            Debug.Log("Kollision mit Gras: Reward -0.3");
            kartAgent.AddReward(-0.3f);
        }
    }
}
