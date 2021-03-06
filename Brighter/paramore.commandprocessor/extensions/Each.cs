﻿using System;
using System.Collections.Generic;

namespace paramore.commandprocessor.extensions
{
    public static class EnumerationExtensions
    {
        public static void Each<T>(this IEnumerable<T> collection, Action<T> doThis)
        {
            foreach(var item in collection)
            {
                doThis(item);
            }
        }
    }
}
