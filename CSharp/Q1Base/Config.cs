using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1Base {
    public static class Config {
        public static String getDataBase() {
         return getKeyString("Database");
        }
        public static void setDatabase(String valor) {
         setKeyString("Database", valor);
        }

        private static String getKeyString(String clave) {
           String res = null;
         RegistryKey key = getRoot();

         //if it does exist, retrieve the stored values  
         if (key != null) {
              res = (String) key.GetValue(clave, "");
              key.Close();
           }
           return res;
        }

      private static void setKeyString(String name, String value) {
         RegistryKey root = getRoot();
         Registry.SetValue(name, value, RegistryValueKind.String);
      }

      private static RegistryKey getRoot() {
         RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Q1", true);
         if (key == null) {
            Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Q1");
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Q1", true);
         }
         return key;
      }
    }
}
