﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace OneView_MappingSet_MVVM.UI.ViewModel.Services
{
    public interface IErrorHandler
    {
        ICollection<string> ErrorList { get; }
        void HandleError(Exception ex);
    }
}
