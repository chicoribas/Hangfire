﻿using System.Collections.Generic;
using ServiceStack.Redis;

namespace HangFire.Client
{
    /// <summary>
    /// Provides information about the context in which the job
    /// is being created.
    /// </summary>
    public class CreateContext
    {
        internal CreateContext(CreateContext context)
            : this(context.Redis, context.JobDescriptor)
        {
            Items = context.Items;
        }

        internal CreateContext(IRedisClient redis, ClientJobDescriptor jobDescriptor)
        {
            Redis = redis;
            JobDescriptor = jobDescriptor;
            Items = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the Redis connection of the current client.
        /// </summary>
        public IRedisClient Redis { get; private set; }

        /// <summary>
        /// Gets an instance of the key-value storage. You can use it
        /// to pass additional information between different client filters
        /// or just between different methods.
        /// </summary>
        public IDictionary<string, object> Items { get; private set; }

        /// <summary>
        /// Gets the client job descriptor that is associated with the
        /// current <see cref="CreateContext"/> object.
        /// </summary>
        public ClientJobDescriptor JobDescriptor { get; private set; }
    }
}