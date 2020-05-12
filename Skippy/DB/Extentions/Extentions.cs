using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DB.Extentions
{
    public static class Extentions
    {
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
        /// <summary>
        /// Retruns int. If not found retruns -1
        /// </summary>
        public static int SafeGetInt(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return -1;
        }
    }
}
