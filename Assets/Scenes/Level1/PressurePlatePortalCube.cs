using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatePortalCube : MonoBehaviour
{
    [SerializeField] Material idleMaterial;
    [SerializeField] Material activatedMaterial;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] float pressurePlateHeight = 0.1f;
    [SerializeField] GameObject cube;
    bool activated = false;
    float timePassed = 0;
    public GameObject currentCube;

    private void Update()
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

                timePassed = 0;
                meshRenderer.material = idleMaterial;
            }
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (!activated)
        {
            Destroy(currentCube);
            activated = true;

            Vector3 vec = transform.position;
            vec.y -= (pressurePlateHeight - 0.02f);
            transform.position = vec;

            meshRenderer.material = activatedMaterial;


            vec = transform.position;
            vec.y += 4;
            currentCube = Instantiate(cube, vec, Quaternion.identity);
        }

    }
}

