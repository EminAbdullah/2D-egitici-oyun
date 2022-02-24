using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Health1,Health2,Health3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HealtController(int Health)
    {
        switch (Health)
        {
            case 3:
                Health1.SetActive(true);
                Health2.SetActive(true);
                Health3.SetActive(true);
                break;
            case 2:
                Health1.SetActive(true);
                Health2.SetActive(true);
                Health3.SetActive(false);
                break;
            case 1:
                Health1.SetActive(true);
                Health2.SetActive(false);
                Health3.SetActive(false);
                break;
            case 0:
                Health1.SetActive(false);
                Health2.SetActive(false);
                Health3.SetActive(false);
                break;
        }



    }
}
