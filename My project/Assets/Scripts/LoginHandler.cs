using TMPro;
using UnityEngine;

public class LoginHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text playerNickname;
    public void Start()
    {
        playerNickname.text = Login.nickname;
    }
}
