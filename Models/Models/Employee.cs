using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Employee
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 員工姓氏
        /// </summary>
        [MaxLength(500)]
        public string EmployeeName { get; set; }

        /// <summary>
        /// 所屬部門
        /// </summary>
        [MaxLength(500)]
        public string Department { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime DateOfJoin { get; set; }

        /// <summary>
        /// 頭像路徑
        /// </summary>
        [MaxLength(500)]
        public string PhotoFileName { get; set; }
    }
}
