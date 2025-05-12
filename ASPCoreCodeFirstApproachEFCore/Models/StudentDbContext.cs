using Microsoft.EntityFrameworkCore;

namespace ASPCoreCodeFirstApproachEFCore.Models
{
                 // child class     // parent class
    public class StudentDbContext : DbContext   
    {
        // ab Constructor banana hai (ctor)  {jo class ka naam hota hai wahi
        //              contructor ka naam bhi hota hai
        public StudentDbContext(DbContextOptions options) : base(options)   //  ye parametarised constructor hai
                        // base keyword ka use -> ye hamare parent class ke cons ko call karne ke liye use me aata hai
                        // DbContextOptions -> class hai  
                        // optoins ==> Object hai
        {
                            
        }
        // DbSet jo hai yahi hamare database ke table ko represent karega  
        // aur database me jo table banega uska naam Students hoga
        public DbSet<StudentModel> Students { get; set; }

    }
}
