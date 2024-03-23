using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    private LineRenderer LR;
    private Vector3 Grapplepoint;
    [SerializeField] private LayerMask CanGrapple; //เช็คว่าเกาะได้
    [SerializeField] Transform gunter,camera, player; 
    [SerializeField] private float MaxiDis; //ความยาวของเลือก
    private SpringJoint joint;

    void Start() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; //Lock cursor
    }
    private void Awake()
    {
        LR = GetComponent<LineRenderer>(); //โหลดเส้น
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Startgrapple(); //ยิงเชือก
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Stopgrapple();  //เก็บเชือก
        }
    }

    void LateUpdate()
    {
        Drawrope(); //โหลดเชือก
    }

    void Startgrapple() //ยิงเชือก
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

            joint.spring = 3f;  //ความแข็งแรง
            joint.damper = 3f;  //ความยืดหยุ่น
            joint.massScale = 3f; //ความคุมค่าน้ำหนักที่มีต่อ joint

            LR.positionCount = 2;

            Currentgrappleposition = gunter.position;
        }


    }

    
    void Stopgrapple() //เก็บเชือก
    {
        LR.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 Currentgrappleposition;

    void Drawrope() //โหลดเชือก
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
