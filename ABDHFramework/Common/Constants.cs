using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDHFramework.Common
{
    public  class Constants
  {
        public static int DefautPagingSize = 4;
        public static int NumberImagesInRow = 4;
        public static int DefautPagingSizeForCategory = 9;
        public static int DefautPagingSizeForHotNew = 4;
        public static int DefautPagingSizeForContructionImages = 8;
        public static int DefautPagingSizeForNews = 6;
        public static int DefautPagingSizeForProduct = 12;
        public static int DefautSizeSuggestion = 3;

  }
    public class NewsTypes
    {
        public static byte MIN = 1;
        public static byte News = 1;
        public static byte Contruction = 2;
        public static byte HotNew = 3;
        public static byte PromotionNew = 4;
        public static byte Recruitment = 5;
        public static byte Introduction = 6;
        public static byte NormalProduct = 7;
        public static byte MAX = 7;

    }
    public class Languages
    {
        public static byte VN = 1;
        public static byte EN = 2;
    }
    public class StoreStatuses
    {
        public static bool Exhausted = true;
        public static bool NotExhausted = false;
    }
    public class Promoted
    {
        public static bool Has = true;
        public static bool NotHas = false;
    }

    public class Department
    {
        public static int Managers = 1;
        public static int Techonology = 2;
        public static int Marketing = 3;
        public static int Sales = 4;
        public static int Accounts = 5;
    }

    // Summary:
    //     Describes the result of a System.Web.Security.Membership.CreateUser(System.String,System.String)
    //     operation.
    public class CreateUserStatus
    {
        // Summary:
        //     The user was successfully created.
        public static byte Success = 0;
        // Summary:
        //     The user name was not found in the database.
        public static byte InvalidUserName = 1;
        //
        // Summary:
        //     The password is not formatted correctly.
        public static byte InvalidPassword = 2;
    
        // Summary:
        //     The e-mail address is not formatted correctly.
        public static byte InvalidEmail = 3;
        //
        // Summary:
        //     The user name already exists in the database for the application.
        public static byte DuplicateUserName =4;
        //
        // Summary:
        //     The e-mail address already exists in the database for the application.
        public static byte  DuplicateEmail = 5;
    }
}
