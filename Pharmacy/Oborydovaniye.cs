//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy
{
    using System;
    using System.Collections.Generic;
    
    public partial class Oborydovaniye
    {
        public int id_oborydovaniye { get; set; }
        public string name { get; set; }
        public Nullable<int> id_vracha { get; set; }
        public Nullable<int> id_mesta_hraneniya { get; set; }
    
        public virtual Mesto_hraneniya Mesto_hraneniya { get; set; }
        public virtual Vrachi Vrachi { get; set; }
    }
}
