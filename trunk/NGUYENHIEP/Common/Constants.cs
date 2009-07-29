using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenHiep.Common
{
    public  class Constants
  {
        public static int DefautPagingSize = 4;
        public static int NumberImagesInRow = 4;
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
    public class StoreStatuses
    {
        public static int Exhausted = 1;
        public static int NotExhausted = 2;
    }
    public class Promoted
    {
        public static int Has = 1;
        public static int NotHas = 2;
    }
}
