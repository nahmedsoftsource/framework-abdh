using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Diagnostics;
using Superior.Framework.Exception;
using Superior.Framework.DesignByContract;
using System.Web;

namespace Superior.Framework
{
  public class Logger
  {
    private readonly ILog _logger;

    public Logger(string name)
    {
      _logger = LogManager.GetLogger(name);
    }

    public Logger(Type type)
    {
      _logger = LogManager.GetLogger(type);
    }

    /// <summary>
    /// Log the specified message in Debug level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    [Conditional("DEBUG")]
    public void Debug(object message)
    {
      _logger.Debug(message);
    }

    /// <summary>
    /// Log the specified message in Debug level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="ex">The ex.</param>
    /// <returns></returns>
    [Conditional("DEBUG")]
    public void Debug(object message, System.Exception ex)
    {
      _logger.Debug(message, ex);
    }

    /// <summary>
    /// Logs general information.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public void Info(object message)
    {
      _logger.Info(message);
    }

    /// <summary>
    /// Logs general information.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="ex">The ex.</param>
    /// <returns></returns>
    public void Info(object message, System.Exception ex)
    {
      _logger.Info(message, ex);
    }

    /// <summary>
    /// Logs in warning level if you think that some thing is incorrect.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public void Warn(object message)
    {
      _logger.Warn(message);
    }

    /// <summary>
    /// Logs in warning level if you think that some thing is incorrect.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="ex">The ex.</param>
    /// <returns></returns>
    public void Warn(object message, System.Exception ex)
    {
      _logger.Warn(message, ex);
    }

    /// <summary>
    /// Log in error level if there is an error occurs.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public void Error(object message)
    {
      _logger.Error(message);
    }

    /// <summary>
    /// Log in error level if there is an error occurs.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="ex">The ex.</param>
    /// <returns></returns>
    public void Error(object message, System.Exception ex)
    {
      _logger.Error(message, ex);
    }

    /// <summary>
    /// Log in fatal level only if the system cannot continue to work.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public void Fatal(object message)
    {
      _logger.Fatal(message);
    }

    /// <summary>
    /// Log in fatal level only if the system cannot continue to work.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="ex">The ex.</param>
    /// <returns></returns>
    public void Fatal(object message, System.Exception ex)
    {
      _logger.Fatal(message, ex);
    }

    #region Static methods
    private static Logger _default;
    private static Logger Default
    {
      get
      {
        if (_default == null)
        {
          _default = new Logger("Superior");
        }
        return _default;
      }
    }
    private static Logger _watch;
    /// <summary>
    ///   Use for watching intermittent bugs only, it must be removed after resolving bugs.
    /// </summary>
    public static Logger Watch
    {
      get
      {
        if (_watch == null)
        {
          _watch = new Logger("Watch");
        }
        return _watch;
      }
    }

    public static Logger Current
    {
      get
      {
        if (Scope<Logger>.Current != null)
        {
          return Scope<Logger>.Current.Context;
        }
        return Default;
      }
    }

    public static void Initialize()
    {
      log4net.Config.XmlConfigurator.Configure();
      log4net.GlobalContext.Properties["MachineName"] = Environment.MachineName;
      log4net.GlobalContext.Properties["GCAllocated"] = new LoggingPropertyAction(() => GC.GetTotalMemory(false).ToString());
      log4net.GlobalContext.Properties["RequestURL"] = new LoggingPropertyAction(() => (HttpContext.Current != null && HttpContext.Current.Request != null)? HttpContext.Current.Request.RawUrl : "(none)");
      log4net.GlobalContext.Properties["ClientIP"] = new LoggingPropertyAction(() => (HttpContext.Current != null && HttpContext.Current.Request != null) ? HttpContext.Current.Request.UserHostAddress : "(none)");
      log4net.GlobalContext.Properties["ClientName"] = new LoggingPropertyAction(() => (HttpContext.Current != null && HttpContext.Current.Request != null) ? HttpContext.Current.Request.UserHostName : "(none)");
    }

    public static Scope<Logger> Enter(Logger logger)
    {
      return new Scope<Logger>(logger);
    }

    public static void Leave()
    {
      if (Scope<Logger>.Current != null)
      {
        Scope<Logger>.Current.Leave();
      }
    }
    #endregion

    #region Private helper

    private class LoggingPropertyAction
    {
      private Func<string> _action;
      public LoggingPropertyAction(Func<string> action)
      {
        Check.Require(action != null);
        _action = action;
      }

      public override string ToString()
      {
        return _action();
      }
    }

    #endregion
  }
}
