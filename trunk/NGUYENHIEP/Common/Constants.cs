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
    public class CategoryTypes
    {
        public static byte News = 1;
        public static byte Contruction = 2;
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
