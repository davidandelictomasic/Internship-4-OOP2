using System.Net.Mail;
using System.Text.RegularExpressions;

namespace UserManagement.Domain.Common.Validation
{
    public static class EmailValidator
    {
        public static bool IsValidEmail(string email)
        {
            Regex emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
;

                if (string.IsNullOrEmpty(email))
                    return false;
                

                if (!emailRegex.IsMatch(email))
                    return false;
            

                return true;
            
        }
    }
}
