﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class OrderHasExecutor
    {
        public int IdOrder { get; set; }
        public Order? Order { get; set; }

        public int IdExecutor { get; set; }
        public Executor? Executor { get; set; }
    }
}