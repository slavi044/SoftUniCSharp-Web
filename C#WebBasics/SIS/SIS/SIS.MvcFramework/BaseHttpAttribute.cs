namespace MyFirstMvcApp
{
    using SIS.HTTP;

    using System;

    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
