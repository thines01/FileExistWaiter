using System;
using System.IO;

namespace FileExistWaiter
{
   using Delay;

   public class CFileExistWaiter
   {
      public static bool WaitForFile(string strFileName, uint uintSecondsToWait, uint numDelaySeconds, ref string strError)
      {
         bool blnRetVal = false;
         uint uintMaxSeconds = 0;
         try
         {
            while (uintMaxSeconds < uintSecondsToWait)
            {
               if (File.Exists(strFileName))
               {
                  blnRetVal = true;
                  break;
               }

               CDelay.Delay(numDelaySeconds);
               uintMaxSeconds += numDelaySeconds;
            }
         }
         catch (Exception exc)
         {
            blnRetVal = false;
            strError = exc.Message;
         }

         return blnRetVal;
      }
   }
}
