﻿namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using SIS.MvcFramework.ViewEngine;
    using System.Runtime.CompilerServices;
    using System.Text;

    public abstract class Controller
    {
        private SisViewEngine viewEngine;

        public Controller()
        {
            this.viewEngine = new SisViewEngine();
        }

        public HttpResponse View(
            object viewModel = null,
            [CallerMemberName] string viewPath = null)
        {
            string viewContent = System.IO.File.ReadAllText(
                "Views/" +
                this.GetType().Name.Replace("Controller", string.Empty) +
                "/" + viewPath + ".cshtml");
            viewContent = this.viewEngine.GetHtml(viewContent, viewModel);

            string layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");
            layout = layout.Replace("@RenderBody()", "____VIEW_GOES_HERE____");
            layout = this.viewEngine.GetHtml(layout, viewModel);

            string responseHtml = layout.Replace("____VIEW_GOES_HERE____", viewContent);

            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            HttpResponse response = new HttpResponse(contentType, fileBytes);

            return response;
        }

        public HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));
            return response;
        }
    }
}