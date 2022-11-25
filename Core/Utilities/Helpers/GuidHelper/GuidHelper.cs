using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.GuidHelper
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
        /*
          Guid.NewGuid() bu ifade  eşsiz bir değer oluşturur. 
          Amaç: Aynı isimden dosyalar olursa çakışmasın.
         */
    }
}
