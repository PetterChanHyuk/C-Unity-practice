using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);

    [SerializeField]
    GameObject _player = null;

    public void SetPlayer(GameObject player) { _player = player; }
    void Start()
    {

    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            
            if(_player.IsValid()==false)
            {
                return;
            }

            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Block")))  //LayerMask.GetMask("Block")�� 1<< (int)Define.Layer.Block�� �����ϴ�.
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;  //���� �÷��̾��� ������ �Ÿ��� ���Ѵ����� 0.8�� ���ؼ� ���ݴ� �տ� �ְ� ������
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + _delta;   //transform.position�� �÷��̾� ��ġ ���� vector���� �־��ݴϴ�.
                transform.LookAt(_player.transform);
            }

            
        }
    }
    public void SetQuarterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }   

}
