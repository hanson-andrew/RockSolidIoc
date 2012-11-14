﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockSolidIoc
{
  public interface IChain<T>
  {
    T NextStep { get; set; }
  }
}