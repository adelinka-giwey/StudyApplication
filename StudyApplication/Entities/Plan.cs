//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudyApplication.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plan
    {
        public int PlanId { get; set; }
        public int StudentsId { get; set; }
        public int SubjectId { get; set; }
        public int Grade { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}