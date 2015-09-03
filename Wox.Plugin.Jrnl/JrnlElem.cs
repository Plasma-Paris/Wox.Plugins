using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wox.Plugin.Jrnl
{
    public class JrnlElem
    {
        private const string K_IDFORMAT = "ID_JRNL_# @";
        private const int K_DATELENGTH = 16;

        public JrnlElem(string data)
        {
            try
            {
                Date = data.Substring(0, K_DATELENGTH);
                int idIndex = data.IndexOf(K_IDFORMAT);
                if (idIndex != -1)
                    Id = data.Substring(idIndex + K_IDFORMAT.Length, 36);
                Text = data.Remove(0, Id == null ? K_DATELENGTH + 1 : (K_DATELENGTH + 1 + CreateId().Length));
            }
            catch (Exception ex)
            {
                Text = "Log: " + ex;
            }
        }
        public JrnlElem()
        {
            
        }

        public static string CreateId()
        {
            return String.Format("{0}{1} #", K_IDFORMAT, Guid.NewGuid()); 
        }

        public string Id { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
    }
}
