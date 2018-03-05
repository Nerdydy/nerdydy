using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using nerdydy.Models;

namespace nerdydy.ViewModels
{
    public class MediaTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}