﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections;
using System.Runtime.Caching;
using NHibernate.Cache;
using System.Collections.Generic;
using NHibernate.Util;

namespace NHibernate.Caches.RtMemoryCache
{
	using System.Threading.Tasks;
	using System.Threading;
	public partial class RtMemoryCache : ICache
	{

		public Task<object> GetAsync(object key, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<object>(cancellationToken);
			}
			try
			{
				return Task.FromResult<object>(Get(key));
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		public Task PutAsync(object key, object value, CancellationToken cancellationToken)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key), "null key not allowed");
			}
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value), "null value not allowed");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<object>(cancellationToken);
			}
			try
			{
				Put(key, value);
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		public Task RemoveAsync(object key, CancellationToken cancellationToken)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<object>(cancellationToken);
			}
			try
			{
				Remove(key);
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		public Task ClearAsync(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<object>(cancellationToken);
			}
			try
			{
				Clear();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		public Task LockAsync(object key, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<object>(cancellationToken);
			}
			try
			{
				Lock(key);
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}

		public Task UnlockAsync(object key, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<object>(cancellationToken);
			}
			try
			{
				Unlock(key);
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				return Task.FromException<object>(ex);
			}
		}
	}
}
