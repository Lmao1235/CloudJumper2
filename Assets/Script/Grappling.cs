using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    private LineRenderer LR;
    private Vector3 Grapplepoint;
    [SerializeField] private LayerMask CanGrapple; //����������
    [SerializeField] Transform gunter,camera, player; 
    [SerializeField] private float MaxiDis; //������Ǣͧ���͡
    private SpringJoint joint;

    void Start() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; //Lock cursor
    }
    private void Awake()
    {
        LR = GetComponent<LineRenderer>(); //��Ŵ���
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Startgrapple(); //�ԧ��͡
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Stopgrapple();  //����͡
        }
    }

    void LateUpdate()
    {
        Drawrope(); //��Ŵ��͡
    }

    void Startgrapple() //�ԧ��͡
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

            joint.spring = 3f;  //�������ç
            joint.damper = 3f;  //�����״����
            joint.massScale = 3f; //���������ҹ��˹ѡ����յ�� joint

            LR.positionCount = 2;

            Currentgrappleposition = gunter.position;
        }


    }

    
    void Stopgrapple() //����͡
    {
        LR.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 Currentgrappleposition;

    void Drawrope() //��Ŵ��͡
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
