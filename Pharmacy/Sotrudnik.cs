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
    
    public partial class Sotrudnik
    {
        public Sotrudnik()
        {
            this.Graphik = new HashSet<Graphik>();
            this.Zapis_priem = new HashSet<Zapis_priem>();
        }
    
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Doljnost { get; set; }
        public Nullable<int> Id_address { get; set; }
        public int Password { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual ICollection<Graphik> Graphik { get; set; }
        public virtual ICollection<Zapis_priem> Zapis_priem { get; set; }
    }
}