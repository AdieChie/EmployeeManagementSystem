using EmployeeManagementSystem.Debugging;

namespace EmployeeManagementSystem
{
    public class EmployeeManagementSystemConsts
    {
        public const string LocalizationSourceName = "EmployeeManagementSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "46281cdbb6cc48a9ad5a12f48e608b66";
    }
}
