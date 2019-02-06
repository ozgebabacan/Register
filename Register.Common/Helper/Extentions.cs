using System;

namespace Register.Common
{
    public static class Extentions
    {
        #region FullErrorMessage
        /// <summary>
        /// Gets Exception's message and inner exception's message in one string 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns> Full exception message </returns>
        public static string FullErrorMessage(this Exception exception)
        {
            return exception?.Message + (exception?.InnerException != null ? (" : " + exception?.InnerException.Message) : string.Empty);
        } 
        #endregion
    }
}
