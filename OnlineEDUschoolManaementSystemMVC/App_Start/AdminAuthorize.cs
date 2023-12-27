using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEDUschoolManaementSystemMVC.App_Start
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //1. Check session : đã đăng nhập => cho thực hiện filter
            //Ngược lại thì cho trở lại: trang đăng nhập


            //2. Check quyền: có quyền thì => cho thực hiện filter
            //Ngược lại thì cho trở lại trang => trang báo lỗi quyền truy cập
            //var user = SessionConfig.GetUser(filterContext);
        }
    }
}