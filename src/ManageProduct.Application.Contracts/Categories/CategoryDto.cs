﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ManageProduct.Categories
{
    public class CategoryDto : AuditedEntityDto<Guid>
    {
        public int STT { get; set; }
        public string Name { get; set; }
        public Guid? IdParen { get; set; }
        public string Image { get; set; }
        public string Describe { get; set; }
        public int CountProduct { get; set; }
        public Status Status { get; set; }

        public string? CategoryParent { get; set; }
    }
}
