using System.Globalization;

namespace TorneoTenis.Helpers
{
    public static class HelperString
    {
        /// <summary>
        /// Simplificacion del String Format
        /// </summary>
        /// <param name="value"></param>
        /// <param name="arg0"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Concentramos los String.Format y aseguramos usar el CultureInfo.InvariantCulture
        /// </remarks>
        public static string? Format(this string value, params object[] arg0)
        {
            if (value == null) return null;
            if (arg0 is null)
            {
                throw new ArgumentNullException(nameof(arg0));
            }

            return string.Format(CultureInfo.InvariantCulture, value, arg0);
        }
    }
}
