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

        [HttpPost]
        public IActionResult Add(Note model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspNoteDbContext())
                {
                    db.Notes.Add(model);
                    if (db.SaveChanges() > 0) // Commit
                    {
                        return Redirect("Index"); // NoteController가 생략되어있는 상태 
                    }
                }
                ModelState.AddModelError(string.Empty, "게시물을 저잘할 수 없습니다.");
            }

            return View(model);
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