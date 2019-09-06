﻿//// uncomment to run these tests
//#define L1_ENABLED

using System;
using System.Threading.Tasks;
using AudibleApi;
using AudibleApi.Authentication;
using Dinah.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoginTests_L1
{
#if !L1_ENABLED
    [Ignore]
#endif
    [TestClass]
    public class LoadSessionCookiesAsync
    {
        [TestMethod]
        public async Task has_session_token()
        {
            // live HttpClientHandler
            var login = new Authenticate(ApiClient.Create(), new SystemDateTime());

            await LoginTests_L0.LoadSessionCookiesAsync.has_session_token(login);
        }
    }
}