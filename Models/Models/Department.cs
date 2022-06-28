using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Department
    {
        /// <summary>
        /// 部門編號
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        /// <summary>
        /// 部門名稱
        /// </summary>
        [MaxLength(500)]
        public string DepartmentName { get; set; }
    }
}
