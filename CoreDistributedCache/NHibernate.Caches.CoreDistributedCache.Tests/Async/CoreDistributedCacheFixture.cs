﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


#region License

//
//  CoreDistributedCache - A cache provider for NHibernate using Microsoft.Extensions.Caching.Distributed.IDistributedCache.
//
//  This library is free software; you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation; either
//  version 2.1 of the License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//

#endregion

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Distributed;
using NHibernate.Cache;
using NHibernate.Caches.Common.Tests;
using NUnit.Framework;
using NSubstitute;

namespace NHibernate.Caches.CoreDistributedCache.Tests
{
	using System.Threading.Tasks;
	using System.Threading;
	public partial class CoreDistributedCacheFixture : CacheFixture
	{

		[Test]
		public async Task MaxKeySizeAsync()
		{
			var distribCache = Substitute.For<IDistributedCache>();
			const int maxLength = 20;
			var cache = new CoreDistributedCache(distribCache, new CacheConstraints { MaxKeySize = maxLength }, "foo",
				new Dictionary<string, string>());
			await (cache.PutAsync(new string('k', maxLength * 2), "test", CancellationToken.None));
			await (distribCache.Received().SetAsync(Arg.Is<string>(k => k.Length <= maxLength), Arg.Any<byte[]>(),
				Arg.Any<DistributedCacheEntryOptions>()));
		}

		[Test]
		public async Task KeySanitizerAsync()
		{
			var distribCache = Substitute.For<IDistributedCache>();
			Func<string, string> keySanitizer = s => s.Replace('a', 'b');
			var cache = new CoreDistributedCache(distribCache, new CacheConstraints { KeySanitizer = keySanitizer }, "foo",
				new Dictionary<string, string>());
			await (cache.PutAsync("-abc-", "test", CancellationToken.None));
			await (distribCache.Received().SetAsync(Arg.Is<string>(k => k.Contains(keySanitizer("-abc-"))), Arg.Any<byte[]>(),
				Arg.Any<DistributedCacheEntryOptions>()));
		}
	}
}
