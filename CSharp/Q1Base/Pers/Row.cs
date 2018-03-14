using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Base.Pers {
   public class Row {
      Dictionary<String, Object> data = new Dictionary<String, Object>();

      public void Add(String key, Object value) {
         data.Add(key, value);
      }

      public Object get(String key) {
         return data[key];
      }
   }

}
