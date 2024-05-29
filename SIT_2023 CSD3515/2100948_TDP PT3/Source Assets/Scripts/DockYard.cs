using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockYard : MonoBehaviour
{
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UI.GetComponent<BuyShopController>().isActive = true;
    }
}
