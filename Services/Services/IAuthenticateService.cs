﻿using Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface IAuthenticateService
    {
        void SetClaims(User user);

    }
}
