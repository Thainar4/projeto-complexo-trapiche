using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    [Header("Painel de Créditos")]
    public GameObject painelCreditos;

    [Header("Cena Principal")]
    public string nomeDaCenaPrincipal = "Praça";
    public string nomeDoSpawnDestino = "SpawnPlayer";

    [Header("Input VR")]
    public Key teclaTeste = Key.Enter;

    private bool estaCarregando;
    private bool botaoAEstavaPressionado;

    private void Update()
    {
        if (estaCarregando || painelCreditos != null && painelCreditos.activeSelf)
            return;

        if (ApertouConfirmar())
            IniciarTour();
    }

    public void IniciarTour()
    {
        if (estaCarregando)
            return;

        estaCarregando = true;

        Debug.Log("Botão INICIAR TOUR foi clicado!");

        if (SceneTransitionManager.Instance != null)
        {
            SceneTransitionManager.Instance.LoadScene(nomeDaCenaPrincipal, nomeDoSpawnDestino);
            return;
        }

        PlayerSpawnManager.spawnDestino = nomeDoSpawnDestino;
        SceneManager.LoadScene(nomeDaCenaPrincipal);
    }

    public void AbrirCreditos()
    {
        Debug.Log("Botão CRÉDITOS foi clicado!");

        painelCreditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        Debug.Log("Botão VOLTAR foi clicado!");

        painelCreditos.SetActive(false);
    }

    public void Sair()
    {
        Debug.Log("Botão SAIR foi clicado!");

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    private bool ApertouConfirmar()
    {
        bool apertouTeclado = Keyboard.current != null &&
                              Keyboard.current[teclaTeste].wasPressedThisFrame;

        bool apertouGamepad = Gamepad.current != null &&
                              Gamepad.current.buttonSouth.wasPressedThisFrame;

        bool botaoAAtual = false;

        UnityEngine.XR.InputDevice controleDireito =
            UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand);

        if (controleDireito.isValid)
        {
            controleDireito.TryGetFeatureValue(
                UnityEngine.XR.CommonUsages.primaryButton,
                out botaoAAtual
            );
        }

        bool apertouBotaoAQuest = botaoAAtual && !botaoAEstavaPressionado;
        botaoAEstavaPressionado = botaoAAtual;

        return apertouTeclado || apertouGamepad || apertouBotaoAQuest;
    }
}
