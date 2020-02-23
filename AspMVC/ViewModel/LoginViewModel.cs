using System.ComponentModel.DataAnnotations;

namespace AspMVC.ViewModel
{
    public class LoginViewModel
    {
        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required(ErrorMessage = "사용자 ID를 입력하세요.")] // NOT Null 설정 
        public string UserId { get; set; }

        /// <summary>
        /// 사용자 비밀번호 
        /// </summary>
        [Required(ErrorMessage = "사용자 비밀번호를 입력하세요.")] // NOT Null 설정 
        public string UserPassword { get; set; }
    }
}
