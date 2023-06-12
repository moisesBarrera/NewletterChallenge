using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterChallenge.Entities.Settings.Endpoints
{
   public abstract class BaseEndpoint<T>
   {
      public string BaseAddress { get; set; }

      public int Timeout { get; set; }

      public T Actions { get; set; }
   }
}
