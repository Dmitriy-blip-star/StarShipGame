using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BackgroundLoader : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Loaded backgrounds.")]
    [SerializeField] private List<GameObject> loadedBackgrounds; // ������������(�����������) �������

    [Tooltip("Backgrounds folder name in resources.")]
    [SerializeField] private string backgroundsFolderName; // �������� ����� � ������� �� ������ �������

    [Tooltip("Background name prefix.")]
    [SerializeField] private string backgroundPrefix; // ������� ����� �������

    [Tooltip("Background count in resources folder.")] // ���������� ��������, ������� ����� ��������� � ����� ��������
    [SerializeField] private int backgroundsCount;

    public GameObject GetRandomBackground() // ����� ���������� ������, ������� �� ����� �������� �� �����
    {
        int backgroundId = Random.Range(1, this.backgroundsCount);
        string backgroundName = this.backgroundPrefix + backgroundId; // ��� ������� 
        if (this.loadedBackgrounds.Exists(t => t.name == backgroundName)) // �������� ����� ������ ������ � ������ ����������� ��������
        {
            GameObject background = this.loadedBackgrounds.Find(t => t.name == backgroundName); // � ���������� template ������ ��������� ������ ����� �����, ������� ��� ������������ �����
            return background; // ���������� ��������� �� ���� ����������� �������� ������
        }

        string backgroundResourcePath = Path.Combine(this.backgroundsFolderName, backgroundName); // ��������� ��������� ������ ������ � ������
        GameObject loadedEnemy = Resources.Load<GameObject>(backgroundResourcePath); // ������� ������ � ������� ������ �� �����. � ����� ������ ��� ����� � �������. �� ���������� ��� ������
        this.loadedBackgrounds.Add(loadedEnemy); // ������ ��������� ������ ������(������ ������) � ���� ��� ����������� ��������(����� �� ����������� ��������� �� ������ ��� ������)
       
        return loadedEnemy; // ���������� ���������� ������. �� �����(���� �� ��� �� ��� �������� ��� �� ����������� ����, ���� �� ����������� ��� �� ������ ���)
    }
}
