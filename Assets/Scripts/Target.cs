using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static bool spawned;

    List<Arrow> _arrows = new List<Arrow>();

    public GameObject damageText;

    public int damage;

    private void OnEnable()
    {
        Debug.Log("Target enabled");

        spawned = true;

        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + 33);

        foreach (Arrow arrow in _arrows)
            arrow.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        spawned = false;

        Debug.Log("Target disable");

        foreach (Arrow arrow in _arrows)
            arrow.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("arrow"))
        {
            Arrow arrow = collision.GetComponent<Arrow>();
            _arrows.Add(arrow);
            arrow.DesactivateRb();
            SpawnAndDestroyText();
            arrow.transform.SetParent(transform);
            gameObject.SetActive(false);

            Debug.Log("Target was damaged - " + damage + ". by " + arrow.gameObject.name);
        }
    }

    void SpawnAndDestroyText()
    {
        GameObject text = Instantiate(damageText, transform.position, Quaternion.identity);
        text.GetComponentInChildren<TextMeshPro>().text = damage.ToString();
        Destroy(text, 1);
    }
}
