using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WebGrease.Css.Ast.Selectors;

namespace InterpretationPreDesign
{
    public class Source
    {
        public string Sourcetype { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string URL { get; set; }
    }

    public class Param
    {
        public string Service { get; set; }
        public string Method { get; set; }
        public string Params { get; set; }
    }

    public class Method
    {
        public string Transform { get; set; }
        public string Process { get; set; }
        public string Save { get; set; }
        public string Report { get; set; }
    }

    public class Transforms
    {
        public string Name { get; set; }
    }

    public partial class SampleWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string ShowSourcesHtml()
        {
            StringBuilder html = new StringBuilder();
            Source source = new Source();
            List<Source> sources = new List<Source>();
            Method method = new Method();
            List<Method> methods = new List<Method>();
            Transforms transform = new Transforms();
            List<Transforms> transforms = new List<Transforms>();
            Param parameter = new Param();
            List<Param> param = new List<Param>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Love.xml");

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                XmlNode attST = xnode.Attributes.GetNamedItem("sourcetype");
                if (attST != null)
                {
                    source.Sourcetype = attST.Value;
                    html.Append(String.Format("<b>Тип источника: </b>{0}<br>", source.Sourcetype));
                }

                XmlNode attN = xnode.Attributes.GetNamedItem("nameS");
                if (attN != null)
                {
                    source.Name = attN.Value;
                    html.Append(String.Format("<b>Имя источника: </b>{0}<br>", source.Name));
                }

                XmlNode attP = xnode.Attributes.GetNamedItem("path");
                if (attP != null)
                {
                    source.Path = attP.Value;
                    html.Append(String.Format("<b>Путь к источнику: </b>{0}<br>", source.Path));
                }

                XmlNode attS = xnode.Attributes.GetNamedItem("server");
                if (attS != null)
                {
                    source.Server = attS.Value;
                    html.Append(String.Format("<b>Сервер: </b>{0}<br>", source.Server));
                }

                XmlNode attDB = xnode.Attributes.GetNamedItem("database");
                if (attDB != null)
                {
                    source.Database = attDB.Value;
                    html.Append(String.Format("<b>База данных: </b>{0}<br>", source.Database));
                }

                XmlNode attURL = xnode.Attributes.GetNamedItem("url");
                if (attURL != null)
                {
                    source.URL = attURL.Value;
                    html.Append(String.Format("<b>URL: </b>{0}<br>", source.URL));
                }

                sources.Add(source);

                XmlNode attNameTr = xnode.Attributes.GetNamedItem("nameT");
                if (attNameTr != null)
                {
                    transform.Name = attNameTr.Value;
                    html.Append(String.Format("<br><b>Способ преобразования: </b>{0}<br>", transform.Name));
                }

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "service")
                    {
                        parameter.Service = childnode.InnerText;
                        html.Append(String.Format("<b>Сервис: </b>{0}<br>", parameter.Service));
                    }

                    if (childnode.Name == "method")
                    {
                        parameter.Method = childnode.InnerText;
                        html.Append(String.Format("<b>Метод: </b>{0}<br>", parameter.Method));
                    }

                    if (childnode.Name == "param")
                    {
                        parameter.Params = childnode.InnerText;
                        html.Append(String.Format("<b>Параметр: </b>{0}<br>", parameter.Params));
                    }
                }

            }






            //foreach (Source s in sources)
            //{
            //    if (s.Sourcetype == "local")
            //    {
            //        html.Append(String.Format(
            //            "<b>Тип источника данных: </b>{0}<br><b>Имя источника данных:</b> {1}<br><b>Путь к источнику данных: </b>{2}<br>",
            //            s.Sourcetype, s.Name, s.Path));
            //    }
            //foreach (Param p in param)
            //{
            //    html.Append(String.Format(
            //        "<b>Способ преобразования </b>{0}<br>",
            //        p.Service/*, m.Process, m.Save, m.Report*/));
            //    /*<b>Способ анализа </b> {1}<br><b>Способ сохранения </b>{2}<br><b>Способ визуализации </b>{3}<br>*/
            //}

            //if (s.Sourcetype == "localDB" || s.Sourcetype == "remoteDB")
            //{
            //    html.Append(String.Format(
            //        "<b>Тип источника данных: </b>{0}<br><b>Имя источника данных:</b> {1}<br><b>Сервер: </b>{2}<br><b>База данных: </b>{3}<br>",
            //        s.Sourcetype, s.Name, s.Server, s.Database));
            //}
            //}


            return html.ToString();
        }
    }
}