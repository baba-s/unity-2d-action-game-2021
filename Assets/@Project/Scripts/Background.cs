using UnityEngine;

// �w�i�𐧌䂷��X�N���v�g
public class Background : MonoBehaviour
{
    // �w�i���X�N���[�����鑬��
    public Vector2 m_speed;

    // ���t���[���Ăяo�����֐�
    private void Update()
    {
        // �w�i�̃X�v���C�g��\������@�\���擾����
        var spriteRenderer = GetComponent<SpriteRenderer>();

        // �w�i�̃e�N�X�`����\������}�e���A�����擾����
        var material = spriteRenderer.material;

        // �w�i�̃e�N�X�`�����X�N���[������
        material.mainTextureOffset += m_speed * Time.deltaTime;
    }
}