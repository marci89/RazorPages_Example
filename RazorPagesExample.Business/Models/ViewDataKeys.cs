namespace RazorPagesExample.Business.Models
{
    /// <summary>
    /// Identifiers of the data placed by the system in ViewData
    /// </summary>
    public static class ViewDataKeys
    {
        /// <summary>
        /// Script to run
        /// </summary>
        public const string RunScript = "__SYSTEM_RUN_SCRIPT";

        /// <summary>
        /// Succes message
        /// </summary>
        public const string SuccessMessage = "__SYSTEM_MESSAGE_SUCCESS";

        /// <summary>
        /// Error message title
        /// </summary>
        public const string ErrorMessage = "__SYSTEM_MESSAGE_ERROR";

        /// <summary>
        /// Error message text
        /// </summary>
        public const string ErrorMessageText = "__SYSTEM_MESSAGE_ERROR_TEXT";
    }
}
