//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klient
    {
        public Klient()
        {
            this.Shopping_history = new HashSet<Shopping_history>();
            this.Zapis_priem = new HashSet<Zapis_priem>();
        }
    
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<decimal> Skidka { get; set; }
    
        public virtual ICollection<Shopping_history> Shopping_history { get; set; }
        public virtual ICollection<Zapis_priem> Zapis_priem { get; set; }
    }
}
