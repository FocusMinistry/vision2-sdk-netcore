using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision2.Model {
    public class Vision2Response<T> : Vision2ResponseData where T : new() {
        public T Result { get; set; }
    }
}
