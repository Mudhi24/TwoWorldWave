using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenEmailer : MonoBehaviour
{
    public TMP_InputField toEmail;
    public void SendEmailRequest()
    {
       Emailer.SendEmail(toEmail.text);
    }

}
