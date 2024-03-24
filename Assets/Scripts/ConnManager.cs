using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//��Ʈ��ũ ó�� Ŭ����
public class ConnManager : MonoBehaviourPunCallbacks
{
    // �����Ҷ� ������ �����ϰ� �ʹ�.
    void Start()
    {
        PhotonNetwork.GameVersion = "0.1";

        //���ӿ��� ����� ������� �̸��� �������� ���Ѵ�.
        int num = Random.Range(0, 1000);
        PhotonNetwork.NickName = "Player" + num;

        //���ӿ� �����ϸ� ������ Ŭ���̾�Ʈ�� ������ ���� �ڵ����� ����ȭ
        PhotonNetwork.AutomaticallySyncScene = true;

        //��������
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���� �Ϸ�!");
        RoomOptions room = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 8
        };

        PhotonNetwork.JoinOrCreateRoom("NetTest", room, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("�� ����!");

        //�ݰ� 2m �̳��� Player ������ ����
        Vector2 originPos = Random.insideUnitCircle * 2.0f;
        PhotonNetwork.Instantiate("Player", new Vector3(originPos.x, 0, originPos.y), Quaternion.identity);

    }
}
