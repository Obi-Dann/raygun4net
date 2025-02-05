﻿using System.Net.Http;

namespace Mindscape.Raygun4Net
{
    public class RaygunClient : RaygunClientBase
    {
        public RaygunClient(string apiKey)
            : this(new RaygunSettings { ApiKey = apiKey })
        {
        }
        
        public RaygunClient(RaygunSettings settings) : base(settings)
        {
        }
        
        public RaygunClient(string apiKey, HttpClient httpClient)
            : this(new RaygunSettings { ApiKey = apiKey }, httpClient)
        {
        }
        
        public RaygunClient(RaygunSettings settings, HttpClient httpClient) : base(settings, httpClient)
        {
        }
    }
}