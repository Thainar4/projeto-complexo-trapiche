using System.Collections;
using UnityEngine;

public class ColetarEquipamento : MonoBehaviour
{
    public GameObject mensagem;
    public float tempoMensagem = 3f;

    private bool coletado;

    private void OnTriggerEnter(Collider other)
    {
        if (coletado)
            return;

        if (!other.CompareTag("Player"))
            return;

        coletado = true;

        gameObject.SetActive(false);

        if (mensagem != null)
            StartCoroutine(MostrarMensagem());
    }

    private IEnumerator MostrarMensagem()
    {
        mensagem.SetActive(true);

        yield return new WaitForSeconds(tempoMensagem);

        mensagem.SetActive(false);
    }
}