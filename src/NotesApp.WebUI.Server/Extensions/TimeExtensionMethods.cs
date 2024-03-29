namespace NotesApp.WebUI.Server.Extensions;

public static class TimeExtensionMethods
{
  public static string FormatDifferenceFromNow(this DateTime dateTime)
  {
    var timeDifference = DateTime.Now - dateTime;

    if (timeDifference.TotalMinutes < 1)
    {
      return "less than a minute ago";
    }
    if (timeDifference.TotalMinutes < 60)
    {
      var minutes = (int)timeDifference.TotalMinutes;
      return $"{minutes} minute{(minutes > 1 ? "s" : "")} ago";
    }
    if (timeDifference.TotalHours < 24)
    {
      var hours = (int)timeDifference.TotalHours;
      return $"{hours} hour{(hours > 1 ? "s" : "")} ago";
    }
    return dateTime.ToString("MM.dd HH:mm");
  }
}
