using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Diagnostics;
using NHibernate;
using Superior.Framework;
using Superior.Framework.Exception;

namespace Superior.Data.NHibernateClient
{
  public class NHibernateHttpModule : IHttpModule
  {
    public void Init(HttpApplication context)
    {
      context.BeginRequest += new EventHandler(Application_BeginRequest);
      context.EndRequest += new EventHandler(Application_EndRequest);
    }

    public void Dispose()
    {
    }

    private void Application_BeginRequest(object sender, EventArgs e)
    {
      HttpApplication context = sender as HttpApplication;
      if (!context.Request.AppRelativeCurrentExecutionFilePath.StartsWith("~/Content"))
      {
        try
        {
          ConnectionScope.Enter();
        }
        catch (Exception ex)
        {
          var exHandler = ExceptionHandler.Handle(ex);
          throw ex;
        }
      }
    }

    private void Application_EndRequest(object sender, EventArgs e)
    {
      HttpApplication context = sender as HttpApplication;
      if (ConnectionScope.Current != null)
      {
        ConnectionScope.Current.Leave();
        if (ConnectionScope.Current != null)
        {
          Logger.Current.Warn("Some connection is not closed well. Please check.");
        }
      }
      else if (!context.Request.AppRelativeCurrentExecutionFilePath.StartsWith("~/Content"))
      {
        Logger.Current.Warn("A connection is missing for this request. Please check.");
      }
    }
  }
}
