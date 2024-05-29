using System.Text.RegularExpressions;

namespace PhonebookApp.UseCases;

public partial class CommonHelper
{
    //we use regular expression based on RFC 5322 Official Standard (see https://emailregex.com/)
    private const string EmailExpression = @"^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$";

    [GeneratedRegex(EmailExpression, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture, "en-US")]
    public static partial Regex GetEmailRegex();
    
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        email = email.Trim();

        return GetEmailRegex().IsMatch(email);
    }
}