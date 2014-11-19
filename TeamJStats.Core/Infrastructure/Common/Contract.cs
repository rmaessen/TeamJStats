﻿using System;

namespace TeamJStats.DataAccess.Infrastructure.Common
{
    public class Contract
    {
        public static void Requires<TException>(Func<bool> predicate, string message = null) where TException : Exception
        {
            Requires<TException>(predicate.Invoke());
        }

        public static void Requires<TException>(bool result, string message = null) where TException : Exception
        {
            if (!result)
            {
                if (message == null)
                    throw Activator.CreateInstance<TException>();
                throw Activator.CreateInstance(typeof(TException), message) as TException;
            }
        }
    }
}