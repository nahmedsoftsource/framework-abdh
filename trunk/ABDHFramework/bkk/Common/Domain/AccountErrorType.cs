using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  [Flags]
  public enum AccountErrorType
  {
    Success,
    ExistedAccount,
    NotExitstedAccount,
    WrongPassword,
    DifferentPassword,
    NotExistedEmail,
    WrongID,
    Error = -1
  };
  //public class AccountErrorType
  //{
  //  private static AccountErrorType _instance;
  //  public static AccountErrorType Instance
  //  {
  //    get
  //    {
  //      if (_instance == null)
  //        _instance = new AccountErrorType();
  //      return _instance;
  //    }
  //  }
  //  public static const int Success = 0;
  //  public static const int AccountExisted = 1;
  //  public static const int AccountNotExitsted = 2;
  //  public static const int WrongPassword = 3;
  //}
}
