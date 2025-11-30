namespace UserManagement.Domain.Common.Validation
{
    public static class UrlValidator
    {
        public static bool IsValidUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            
            if (Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                return true;

            
            var domainPattern = @"^([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(url, domainPattern);
        }
    }
}
