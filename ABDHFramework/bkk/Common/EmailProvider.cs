using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Superior.MobileMedics.Common
{
  public class EmailProvider
  {
    internal EmailProvider()
    {
    }
    public bool SendMail(MailMessage message)
    {
      SmtpClient client = new SmtpClient();
      client.Send(message);
      return true;
    }
  }
}
