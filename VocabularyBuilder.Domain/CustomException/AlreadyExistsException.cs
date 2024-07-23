﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.CustomException
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string msg) : base(msg)
        {
            
        }
    }
}
