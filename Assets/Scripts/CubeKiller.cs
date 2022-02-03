using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKiller : MonoBehaviour
{
    [SerializeField] private Camera camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            return;
        }

        var ray = camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray,out var hit))
        {
            return;
        }

        var rigedbody = hit.transform.GetComponent<Rigidbody>();
        if (rigedbody != null)
        {
            rigedbody.AddForceAtPosition((hit.point-transform.position).normalized*10f,hit.point,ForceMode.Impulse);
        }

        var tnt = rigedbody.GetComponent<TNT>();
        if (tnt != null)
        {
            tnt.Badabum();
        }
        
    }
}
