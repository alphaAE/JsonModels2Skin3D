using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonModels2Skin3D.model {
    public class McGeometryJson {

        public int visible_bounds_width { get; set; }
        public int visible_bounds_height { get; set; }
        public float[] visible_bounds_offset { get; set; }
        public int texturewidth { get; set; }
        public int textureheight { get; set; }
        public Bone[] bones { get; set; }

        public class Bone {
            public string name { get; set; }
            public Cube[] cubes { get; set; }
            public string parent { get; set; }
            public float[] pivot { get; set; }
            public float[] rotation { get; set; }
            public bool mirror { get; set; }
        }

        public class Cube {
            public float[] origin { get; set; }
            public float[] size { get; set; }
            public float[] uv { get; set; }
            public bool mirror { get; set; }
            public float inflate { get; set; }
        }



    }




}
