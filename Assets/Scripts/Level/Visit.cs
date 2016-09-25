using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Customer;

namespace Level {
    public partial class CustomerScheduler {
        public sealed class Visit {
            public float time;
            public IRequirement[] requirements;

            public Visit(float time, IRequirement[] requirements = null) {
                this.time = time;
                this.requirements = requirements;
            }
        }
    }
}
