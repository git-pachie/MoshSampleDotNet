using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMosh.Dto
{
    public class FavoriteFoodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}