using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressurePlatePortalCube : MonoBehaviour
{
    [SerializeField] Material idleMaterial;
    [SerializeField] Material activatedMaterial;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] float pressurePlateHeight = 0.1f;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject objective;
    bool activated = false;
    bool usedFirstTime = false;
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
        if (!usedFirstTime) {
            usedFirstTime = true;
            TextMeshProUGUI objectiveText = objective.GetComponent<TextMeshProUGUI>();
            objectiveText.SetText("Tip: you can place portals on the rainbow cube");
        }

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

