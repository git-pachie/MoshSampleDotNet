using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMosh.Dto
{
    public class CodeFavoriteFoodDTO
    {
        public int SelectedId { get; set; }

        public string FavoriteFoodName { get; set; }

        public bool  IsSelected { get; set; }
    }
}