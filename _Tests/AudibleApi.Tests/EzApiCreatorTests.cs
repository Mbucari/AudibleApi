﻿namespace EzApiCreatorTests_L0
{
    [TestClass]
	public class GetApiAsync
	{
		[TestMethod]
		public async Task access_from_L0_throws()
			=> await Assert.ThrowsExceptionAsync<MethodAccessException>(() => EzApiCreator.GetApiAsync(Locale.Empty, null));
	}
}
