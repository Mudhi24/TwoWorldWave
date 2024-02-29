using System;
using System.Collections.Generic;
using UnityEngine;
using MimeKit;
using System.IO;
using System.Text.RegularExpressions; // Added for email validation

using ContentDisposition = MimeKit.ContentDisposition;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using UnityEngine.UI;

public class email : MonoBehaviour
{
    // UI elements
    public InputField emailInput;
    public InputField subjectInput;

    // Variables
    private string recipientEmail;
    private string emailSubject;

    public void SendEmailButton_Click()
    {
        // Validate user input
        if (!ValidateEmail(emailInput.text))
        {
            Debug.LogError("Invalid email address provided.");
            return;
        }

        recipientEmail = emailInput.text;
        emailSubject = subjectInput.text == string.Empty ? "Default Subject" : subjectInput.text;

        SendEmail();
    }

    private bool ValidateEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
        return Regex.IsMatch(email, emailPattern);
    }

    private void SendEmail()
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HH - Email Sender", "world.wave@outlook.com")); // Replace with your sender info
            message.To.Add(new MailboxAddress("Recipient", recipientEmail));

            // Handle potential empty subject
            message.Subject = string.IsNullOrEmpty(emailSubject) ? "Default Subject" : emailSubject;

            // ... (rest of `SendEmail` code from previous responses)

            using (var client = new SmtpClient())
            {
                // Configure email server settings (replace with your actual values)
                client.Connect("smtp-mail.outlook.com", 587, false); // Use secure connection (TLS)
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("your_username", "your_password");
                client.Send(message);
                client.Disconnect(true);
                Debug.Log("Sent email");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error sending email: {ex.Message}");
            // Handle error gracefully, e.g., display a user-friendly message
        }
    }
}
