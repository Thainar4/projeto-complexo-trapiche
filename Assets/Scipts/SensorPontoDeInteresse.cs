using UnityEngine;

public class SensorPontoDeInteresse : MonoBehaviour
{
    [SerializeField] private GameObject painelInformativo;

    private void OnTriggerEnter(Collider other)
    {
        // Agora o código aceita a MainCamera, a tag Player OU qualquer objeto que tenha "XR" no nome!
        if (other.CompareTag("MainCamera") || other.CompareTag("Player") || other.name.Contains("XR"))
        {
            if (painelInformativo != null)
            {
                painelInformativo.SetActive(true); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") || other.CompareTag("Player") || other.name.Contains("XR"))
        {
            if (painelInformativo != null)
            {
                painelInformativo.SetActive(false); 
            }
        }
    }
}