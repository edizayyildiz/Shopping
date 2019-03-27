using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{

    public class Slider : BaseEntity
    {
        public Slider()
        {
            Slides = new HashSet<Slide>();
        }
        public string Name { get; set; }
        public ICollection<Slide> Slides { get; set; }
    }
}
