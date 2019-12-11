namespace eCommerce.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Microsoft.AspNet.Identity.Owin;
    using PagedList.Mvc;
    using PagedList;
    using eCommerce.BLL.DTO;
    using eCommerce.BLL.Infrastructure;
    using eCommerce.BLL.Interfaces;
    using eCommerce.BLL.Services;
    using eCommerce.Models;
    public class ReviewController : Controller
    {
        private ICommentService commentService;

        public ReviewController(ICommentService iserv)
        {
            this.commentService = iserv;
        }
        int product_id;
        [HttpGet]
        public ActionResult AddReview(int? id)
        {
            if (this.Session["User_ID"] == null)
            {
                return this.RedirectToAction("../User/Login");
            }
            else
            {
                this.product_id = (int)id;
                CommentViewModel reviewModel = new CommentViewModel();
                return this.View(reviewModel);
            }
        }
        [HttpPost]
        public ActionResult AddReview(int id, CommentViewModel commentViewModel)
        {
            commentViewModel.commentId = this.commentService.FindMaxId() + 1;
            commentViewModel.userId = int.Parse(this.Session["User_ID"].ToString());
            commentViewModel.productId = id;

            var commentDTO = new CommentDTO(commentViewModel.commentId, commentViewModel.productId, commentViewModel.userId,commentViewModel.message);
            this.commentService.CreateComment(commentDTO);

            return this.RedirectToAction($"../MainPage/MainPage");
        }
    }
}