using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressurePlateScript : MonoBehaviour
{

    [SerializeField] Material idleMaterial;
    [SerializeField] Material activatedMaterial;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] float pressurePlateHeight = 0.1f;
    [SerializeField] GameObject cube;
    float timePassed = 0;
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            timePassed += Time.deltaTime;
            if (timePassed > 7)
            {
                activated = false;

                Vector3 vec = transform.position;
                vec.y += (pressurePlateHeight - 0.02f);
                transform.position = vec;

                meshRenderer.material = idleMaterial;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!activated) {
            timePassed = 0;
            activated = true;

            Vector3 vec = transform.position;
            vec.y -= (pressurePlateHeight - 0.02f);
            transform.position = vec;

            meshRenderer.material = activatedMaterial;


            vec = transform.position;
            vec.y += 2;
            GameObject g = Instantiate(cube, vec , Quaternion.identity);
        }

    }

}
