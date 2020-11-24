using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.Context
{
    public class AppRole:IdentityRole<int> //PrimaryKey tipini generic olarak verdik
    {
    }
}
