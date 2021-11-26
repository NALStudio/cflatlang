﻿using CMM.Models.Lang;
using CMM.Models.Lang.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Lang.Operations
{
    public class Assign : CMM_Operation
    {
        public override OperatorDirection Direction => OperatorDirection.LeftAndRight;

        public override string Name => "=";
    }
}
