using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using PagedList;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    
    public class ProductsController : BaseController
    {
        //private FabricsEntities db = new FabricsEntities();
        //private ProductRepository db = RepositoryHelper.GetProductRepository();

        // GET: Products


        //[ActionName("Index.aspx")]
        [本機測試Attribute]
        public ActionResult Index(string SortBy, string Keyword, int PageNo = 1)
        {
            IQueryable<Product> MyResult = DoSearchAll(ref SortBy, Keyword, PageNo);
            return View(MyResult.ToPagedList(PageNo, 20));
            //return View("Index", MyResult.ToPagedList(PageNo, 20));
        }

        private IQueryable<Product> DoSearchAll(ref string SortBy, string Keyword, int PageNo)
        {
            var MyResult = db.All().AsQueryable();
            if (!String.IsNullOrEmpty(Keyword))
            { MyResult = MyResult.Where(m => m.ProductName.Contains(Keyword)); }
            if (String.IsNullOrEmpty(SortBy))
                SortBy = "+Price";
            if (SortBy.Equals("+Price"))
            {
                MyResult = MyResult.OrderBy(m => m.Price);
            }
            else if (SortBy.Equals("-Price"))
            {
                MyResult = MyResult.OrderByDescending(m => m.Price);
            }
            ViewBag.PageNo = PageNo;
            ViewBag.SortBy = SortBy;
            ViewBag.Keyword = Keyword;
            return MyResult;
        }

        [HttpPost]
        public ActionResult Index(Product[] data, string SortBy, string Keyword, int PageNo = 1)
        {
            if (ModelState.IsValid && data !=null)
            {
                foreach (var MyProduct in data)
                {
                    var dbProduct = db.Find(MyProduct.ProductId);
                    dbProduct.Stock = MyProduct.Stock;
                    dbProduct.Active = MyProduct.Active;
                    dbProduct.ProductName = MyProduct.ProductName;
                    dbProduct.Price = MyProduct.Price;
                }
                db.UnitOfWork.Commit();
            }
            IQueryable<Product> MyResult = DoSearchAll(ref SortBy, Keyword, PageNo);
            return View(MyResult.ToPagedList(PageNo, 20));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Add(product);
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        [HandleError(View = "Error_DbEntityValidationException", ExceptionType = typeof(DbEntityValidationException))]
        public ActionResult Edit(int id)
        {
            //DbEntityValidationException ab;
            //Type a = typeof(DbEntityValidationException);
            ////a.GetType().FullName;
            //ab = Convert.ChangeType(a, a.GetType());
            var aaa = db.Find(id);
            if (TryUpdateModel(aaa,new string[] { "ProductName", "Stock" }))
            {
                db.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }return View(aaa);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult ShowOrderLine(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product.OrderLine);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Find(id);
            db.Delete(product);
            db.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
