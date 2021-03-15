﻿using System;
using Library.Core.Enum;

namespace Library.Entities.Entities.Dtos.WriterDto
{
    public class WriterAddDto
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GeneralStatus GeneralStatus { get; set; }
    }
}