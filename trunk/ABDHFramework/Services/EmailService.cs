using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace ABDHFramework.Utility
{
  public class EmailService 
  {
    
    private static EmailService _instance;

    public static EmailService Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new EmailService();
        }
        return _instance;
      }
    }

    private MailMessage CreateMailMessage(string toList, string ccList, string subject, string body)
    {
      MailMessage message = new MailMessage("", toList, subject, body);
      if (!string.IsNullOrEmpty(ccList))
      {
        message.CC.Add(ccList);
      }
      return message;
    }

    public bool SendEmail(MailMessage message)
    {
      try
      {
        SmtpClient client = new SmtpClient();
        client.Send(message);
        return true;
      }
      catch (SmtpException smtpEx)
      {
        return false;
      }
    }
  }
}
