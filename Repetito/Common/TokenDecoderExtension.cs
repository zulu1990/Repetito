namespace Repetito.Common;

public static class TokenDecoderExtrension
{
    public static Guid GetUserId(this HttpContext context)
    {
        var idAsString = context.User.Claims.ToList().FirstOrDefault(x => x.Type.Contains("nameidentifier"))?.Value;

        return string.IsNullOrEmpty(idAsString) ? Guid.Empty : Guid.Parse(idAsString);
    }
}

