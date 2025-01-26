using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class ToDoListController : Controller
{
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public ToDoListController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            
        }
        
     public IActionResult Index(string description, string userName)
    {
        // إذا تم إدخال وصف للبحث
        if (!string.IsNullOrWhiteSpace(description))
        {
            var search = _context.items.Where(s => s.Description.Contains(description)).ToList();
            ViewData["UserName"] = userName; // تمرير اسم المستخدم إلى العرض
            return View(search);
        }

        // في حالة عدم وجود بحث، جلب كل البيانات
        var getdata = _context.items.ToList();
        ViewData["UserName"] = userName; // تمرير اسم المستخدم إلى العرض
        return View(getdata);
    }
    
        public IActionResult CreateList(ToDoItem items) {
            _context.Add(items);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


         public IActionResult DeleteItem(int id) {

            var ItemDelete = _context.items.SingleOrDefault(i=> i.Id == id);
            
            if (ItemDelete != null) {
                _context.items.Remove(ItemDelete);
                _context.SaveChanges();
            }
       
            return RedirectToAction("Index");

        }

        // [HttpPost]
        // public IActionResult EditItem(int id, [FromBody] ToDoItem updatedItem)
        // {
        //     var item = _context.items.SingleOrDefault(e => e.Id == id);
        //     if (item != null)
        //     {
        //         item.Description = updatedItem.Description; // تحديث الوصف الجديد
        //         _context.items.Update(item);
        //         _context.SaveChanges(); // حفظ التعديلات
        //     }
        //     return RedirectToAction("Index");

        // }

            public IActionResult EditItem(int id)
        {
            var item = _context.items.SingleOrDefault(e => e.Id == id);
            return View(item);

        }



        public IActionResult UpdateItem(ToDoItem items) {
            _context.items.Update(items);
            _context.SaveChanges(); // حفظ التعديلات

            return RedirectToAction("Index");


        }
        // [HttpPost]
        // public IActionResult Search(string Description) {
        //      if (Description != null) {
        //         var search = _context.items.Where(s=>s.Description.Contains(Description)).ToList();
        //         return PartialView("_partial/_IndexPartialData", search);


        //     }

        //     var item = _context.items.ToList();
        //     return PartialView("_partial/_IndexPartialData", item);


        // }

       


}