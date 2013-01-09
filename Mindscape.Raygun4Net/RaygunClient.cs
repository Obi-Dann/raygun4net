﻿using System;
using System.Net;
using System.Web;

using Mindscape.Raygun4Net.Messages;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mindscape.Raygun4Net
{
  public class RaygunClient
  {
    public void Send(Exception exception)
    {
      var message = RaygunMessageBuilder.New
        .SetMachineName(Environment.MachineName)
        .SetExceptionDetails(exception)
        .SetHttpDetails(HttpContext.Current)
        .SetClientDetails()
        .Build();

      Send(message);
    }

    public void Send(RaygunMessage raygunMessage)
    {
      using (var client = new WebClient())
      {
        client.Headers.Add("X-ApiKey", RaygunSettings.Settings.ApiKey);

        try
        {
          client.UploadString(RaygunSettings.Settings.ApiEndpoint, JObject.FromObject(raygunMessage, new JsonSerializer { MissingMemberHandling = MissingMemberHandling.Ignore }).ToString());
        }
        catch (Exception ex)
        {
          System.Diagnostics.Trace.WriteLine(string.Format("Error Logging Exception to Raygun.io {0}", ex.Message));
        }
      }
    }
  }
}