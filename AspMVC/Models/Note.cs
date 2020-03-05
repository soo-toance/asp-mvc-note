using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspMVC.Models
{
    public class Note
    {
        /// <summary>
        /// 게시글 번호 
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// 게시글 제목
        /// </summary>
        [Required(ErrorMessage = "제목을 입력하세요.")]
        public string NoteTitle { get; set; }

        /// <summary>
        /// 게시글 내용 
        /// </summary>
        [Required(ErrorMessage = "내용을 입력하세요.")]
        public string NoteCotents { get; set; }

        /// <summary>
        /// 사용자 번호 
        /// </summary>
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")] // 외래키, virtual은 lazy loading
        public virtual User User { get; set; }
    }
}
