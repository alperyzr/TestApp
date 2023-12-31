﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Core.Application.UrlShorts.ViewModels
{
    public class UrlShortDto : _BaseDto
    {
        public int Id { get; set; }       
        public int UserId { get; set; }       
        public string Url { get; set; }   
        public string ShortUrl { get; set; }
        public string Description { get; set; }
        public string ToRedirectUrl { get; set; }
        public DateTime RedirectUrlDate { get; set; }
        public string UserName { get; set; }
    }
}
