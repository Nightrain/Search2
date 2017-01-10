using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularSearch
{


   public class IniFiles
   {
      List<IniFile> myFiles;

      public List<IniFile> MyFiles
      {
         get { return myFiles; }
         set { myFiles = value; }
      }
      public IniFiles()
      {
         myFiles = new List<IniFile>();
      }

      //public bool LoadInitialationFiles(string inPath)
      //{
         
      //}

   }

   public class IniFile
   {
       public  enum FileTypes
   {
      Simulation,
      Animal
   }
      string type;

      public string Type
      {
         get { return type; }
         set { type = value; }
      }
      string fileName;

      public string FileName
      {
         get { return fileName; }
         set { fileName = value; }
      }
   }
}

