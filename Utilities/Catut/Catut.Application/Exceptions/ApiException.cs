// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable UseStringInterpolation
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
// ReSharper disable ReplaceSubstringWithRangeIndexer
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable RedundantNameQualifier
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
// ReSharper disable PartialTypeWithSinglePart

using System.Text.Json;
using Catut.Application.Dtos;

#pragma warning disable CS8601
#pragma warning disable CS8618
#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 612 // Disable "CS0612 '...' is obsolete"
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"

namespace Catut.Application.Exceptions;

[System.CodeDom.Compiler.GeneratedCode("NSwag", "13.19.0.0 (NJsonSchema v10.9.0.0 (Newtonsoft.Json v11.0.0.0))")]
public partial class ApiException : Exception
{
    public int StatusCode { get; private set; }
    public ErrorResponse? Response { get; protected set; }
    public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }

    public ApiException(
        string message,
        int statusCode,
        string response,
        IReadOnlyDictionary<string, IEnumerable<string>> headers,
        Exception innerException)
        : base(
            $"{message}\n\nStatus: {statusCode}\nResponse: \n{(response == null ? "(null)" : response.Substring(0, Math.Min(response.Length, 512)))}",
            innerException)
    {
        StatusCode = statusCode;
        Headers = headers;
        
        if (!string.IsNullOrEmpty(response))
        {
            Response = JsonSerializer.Deserialize<ErrorResponse>(response);
        }
    }

    public override string ToString()
    {
        return $"HTTP Response: \n\n{Response}\n\n{base.ToString()}";
    }
}

[System.CodeDom.Compiler.GeneratedCode("NSwag", "13.19.0.0 (NJsonSchema v10.9.0.0 (Newtonsoft.Json v11.0.0.0))")]
public partial class ApiException<TResult> : ApiException
{
    public TResult Result { get; private set; }

    public ApiException(
        string message,
        int statusCode,
        string response,
        IReadOnlyDictionary<string, IEnumerable<string>> headers,
        TResult result,
        Exception innerException)
        : base(message, statusCode, response, headers, innerException)
    {
        Result = result;

        //TODO fix this HACK: This code needs to be refactored -- this will hit performance!
        var resultJson = JsonSerializer.Serialize(result);
        Response = JsonSerializer.Deserialize<ErrorResponse>(resultJson);
    }
}