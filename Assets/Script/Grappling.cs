using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    private LineRenderer LR;
    private Vector3 Grapplepoint;
    [SerializeField] private LayerMask CanGrapple;
    [SerializeField] Transform gunter,camera, player;
    [SerializeField] private float MaxiDis;
    private SpringJoint joint;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Awake()
    {
        LR = GetComponent<LineRenderer>();
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Startgrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Stopgrapple();
        }
    }

    void LateUpdate()
    {
        Drawrope();
    }

    void Startgrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, MaxiDis, CanGrapple))
        {
            Grapplepoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = Grapplepoint;

            float disfrompoint = Vector3.Distance(player.position, Grapplepoint);

            joint.maxDistance = disfrompoint * 0.8f;

            joint.minDistance = disfrompoint * 0.25f;

            joint.spring = 4.5f;
            joint.spring = 7f;
            joint.massScale = 5f;

            LR.positionCount = 2;

            Currentgrappleposition = gunter.position;
        }


    }

    
    void Stopgrapple()
    {
        LR.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 Currentgrappleposition;

    void Drawrope()
    {
        if (!joint) return;

        Currentgrappleposition = Vector3.Lerp(Currentgrappleposition, Grapplepoint, Time.deltaTime * 8f);

        LR.SetPosition(0, gunter.position);
        LR.SetPosition(1, Currentgrappleposition);


    }

    public bool IsGrappling()
    {
        return joint != null;
    }
}
