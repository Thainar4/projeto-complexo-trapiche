using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public Transform camera;
    public Rigidbody corpo;
    public float velocidade = 60.0f;

    public Vector2 movimentacao;
    public Vector2 olhar;

    float rotacaoVertical = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 arrumandoMov = new Vector3(movimentacao.x, 0, movimentacao.y);
        transform.Translate(arrumandoMov * velocidade * Time.deltaTime);

        float rotacaoHorizontal = olhar.x * 10.0f * Time.deltaTime;
        transform.Rotate(0, rotacaoHorizontal, 0);

        rotacaoVertical -= olhar.y * 10.0f * Time.deltaTime;
        rotacaoVertical = Mathf.Clamp(rotacaoVertical, -90.0f, 90.0f);
        camera.localRotation = Quaternion.Euler(rotacaoVertical, 0, 0);


    }

    void OnMove(InputValue value)
    {
        movimentacao = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        olhar = value.Get<Vector2>();
        // Debug.Log("olhando -- " + olhar);
    }
}