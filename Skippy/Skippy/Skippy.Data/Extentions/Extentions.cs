using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.Extentions
{
    public static class Extentions
    {
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public static bool GetBool(this SqlDataReader reader, int colIndex)
        {
            return reader.GetByte(colIndex) == 1 ? true : false;
        }
    }
}
