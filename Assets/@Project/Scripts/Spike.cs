using UnityEngine;

// �j�𐧌䂷��X�N���v�g
public class Spike : MonoBehaviour
{
	// ���̃I�u�W�F�N�g�Ɠ����������ɌĂяo�����֐�
	private void OnTriggerEnter2D( Collider2D other )
	{
		// ���O�ɁuPlayer�v���܂܂��I�u�W�F�N�g�Ɠ���������
		if ( other.name.Contains( "Player" ) )
		{
			// �v���C���[���� Player �X�N���v�g���擾����
			var player = other.GetComponent<Player>();

			// �v���C���[�����ꂽ���ɌĂяo���֐������s����
			player.Dead();
		}
	}
}