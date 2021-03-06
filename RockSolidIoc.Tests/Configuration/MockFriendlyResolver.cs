﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Moq;

namespace RockSolidIoc.Tests
{

    class MockFriendlyResolver : MockContainer<IResolver>, IResolver
  {
    public object ResolveDependency(Type type, IIocContainer context)
    {
      return Mock.Object.ResolveDependency(type, context);
    }
  }

}