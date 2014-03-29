﻿using System;

namespace com.tinylabproductions.TLPLib.Extensions {
  public static class AnyExts {
    public class RequirementFailedError : Exception {
      public RequirementFailedError(string message) : base(message) {}
    }

    public static void require<T>(
      this T any, bool requirement, string message, params object[] args
      ) {
      if (! requirement)
        throw new RequirementFailedError(string.Format(message, args));
    }

    public static T locally<T>(this object any, Fn<T> local) {
      return local();
    }
}
}
