using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BackgroundLoader : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Loaded backgrounds.")]
    [SerializeField] private List<GameObject> loadedBackgrounds; // Используемые(загруженные) шаблоны

    [Tooltip("Backgrounds folder name in resources.")]
    [SerializeField] private string backgroundsFolderName; // Название папки в которой мы храним шаблоны

    [Tooltip("Background name prefix.")]
    [SerializeField] private string backgroundPrefix; // Префикс имени шаблона

    [Tooltip("Background count in resources folder.")] // Количество шаблонов, которое будет храниться в папке ресурсов
    [SerializeField] private int backgroundsCount;

    public GameObject GetRandomBackground() // Метод возвращает шаблон, который мы будем спавнить на сцене
    {
        int backgroundId = Random.Range(1, this.backgroundsCount);
        string backgroundName = this.backgroundPrefix + backgroundId; // Имя шаблона 
        if (this.loadedBackgrounds.Exists(t => t.name == backgroundName)) // Пытаемся найти нужный шаблон в списке загруженных шаблонов
        {
            GameObject background = this.loadedBackgrounds.Find(t => t.name == backgroundName); // в переменную template кладем результат поиска имени файла, который был сгенерирован ранее
            return background; // Возвращаем полученый из пула загруженных шаблонов шаблон
        }

        string backgroundResourcePath = Path.Combine(this.backgroundsFolderName, backgroundName); // Загружаем результат работы метода в строку
        GameObject loadedEnemy = Resources.Load<GameObject>(backgroundResourcePath); // создаем объект с помощью поиска по имени. в метод кладем имя папки и шаблона. он возвращает сам шаблон
        this.loadedBackgrounds.Add(loadedEnemy); // кладем результат работы метода(объект шаблон) в лист уже загруженных шаблонов(чтобы не приходилось выгружать их каждый раз заново)
       
        return loadedEnemy; // возвращаем полученный шаблон. из папки(если он еще не был загружен или из внутреннего пула, если он встречается уже не первый раз)
    }
}
