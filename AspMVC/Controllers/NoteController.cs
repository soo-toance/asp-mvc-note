using Microsoft.AspNetCore.Mvc;
using AspMVC.DataContext;
using System.Linq;

namespace AspMVC.Controllers
{
    public class NoteController : Controller
    {
        /// <summary>
        /// 게시판 리스트
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            using (var db = new AspNoteDbContext())
            {
                var list = db.Notes.ToList(); // 모두 출력 
                return View(list);
            }
        }

        /// <summary>
        /// 게시물 추가 
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 게시물 수정 
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// 게시물 삭제 
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete()
        {
            return View();
        }
    }
}