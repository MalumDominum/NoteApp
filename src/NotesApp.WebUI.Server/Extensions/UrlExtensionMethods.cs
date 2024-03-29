using Microsoft.AspNetCore.Components;

namespace NotesApp.WebUI.Server.Extensions;

public static class UrlExtensionMethods
{
  public static string? GetParameterFromUrl(
    this NavigationManager navigation, string parameterName)
  {
    var query = new Uri(navigation.Uri).Query;

    if (string.IsNullOrEmpty(query)) return null;

    var queryParams = System.Web.HttpUtility.ParseQueryString(query);
    return queryParams[parameterName];
  }
}
