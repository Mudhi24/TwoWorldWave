using System;
using UnityEngine;
using MimeKit;
using System.IO;
using TMPro;

using ContentDisposition = MimeKit.ContentDisposition;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

public static class Emailer
{
   
    public static void SendEmail(string email)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("World Wave", "world.wave@outlook.com"));
        message.To.Add(new MailboxAddress("World Wave", email));
        message.Subject = "World Wave";

        var multipartBody = new Multipart("mixed");
        {
            var textPart = new TextPart("plain")
            {
                Text = @"World Wave"
            };
            multipartBody.Add(textPart);

            string attachmentPath = @"D:\Workshop Projects\Reviewing the Unity Essentials\My project (6)\CameraView.png";
            var attachmentPart = new MimePart("image/png")
            {
                Content = new MimeContent(File.OpenRead(attachmentPath), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(attachmentPath)
            };
            multipartBody.Add(attachmentPart);

            string logPath = @"C:\Users\shomo\Downloads\testsendemail\testtext.txt";
            var logPart = new MimePart("text/plain")
            {
                Content = new MimeContent(File.OpenRead(logPath), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(logPath)
            };
            multipartBody.Add(logPart);
        }
        message.Body = multipartBody;

        using (var client = new SmtpClient())
        {
            // This section must be changed based on your sender's email host
            // Do not use Gmail
            client.Connect("smtp-mail.outlook.com", 587, false);

            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate("world.wave@outlook.com", "World@Wave");
            client.Send(message);
            client.Disconnect(true);
            Debug.Log("Sent email");
        }
    }
}

