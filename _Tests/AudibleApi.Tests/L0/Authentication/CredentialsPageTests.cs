﻿namespace Authentic.CredentialsPageTests
{
    [TestClass]
    public class SubmitAsync
    {
        private CredentialsPage getPage()
            => new CredentialsPage(AuthenticateShared.GetAuthenticate(), "body");

		[TestMethod]
        public async Task null_email_throws()
            => await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => getPage().SubmitAsync(null, "pw"));

        [TestMethod]
        public async Task blank_email_throws()
        {
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => getPage().SubmitAsync("", "pw"));
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => getPage().SubmitAsync("   ", "pw"));
        }

        [TestMethod]
        public async Task null_password_throws()
            => await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => getPage().SubmitAsync("email", null));

        [TestMethod]
        public async Task blank_password_throws()
        {
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => getPage().SubmitAsync("email", ""));
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => getPage().SubmitAsync("email", "    "));
		}

		[TestMethod]
        public async Task valid_param_calls_GetResultsPageAsync()
        {
            var responseToCaptureRequest = new HttpResponseMessage();

            var page = new CredentialsPage(AuthenticateShared.GetAuthenticate(responseToCaptureRequest), "body");
			await Assert.ThrowsExceptionAsync<LoginFailedException>(() => page.SubmitAsync("e", "pw"));

            var content = await responseToCaptureRequest.RequestMessage.Content.ReadAsStringAsync();
            var split = content.Split('&');
            var dic = split.Select(s => s.Split('=')).ToDictionary(key => key[0], value => value[1]);
            dic.Count.ShouldBe(3);
            dic["email"].ShouldBe("e");
            dic["password"].ShouldBe("pw");
            dic["metadata1"].Length.ShouldBeGreaterThan(100);
        }
    }
}
