using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
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
    }
    public partial class SampleWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List <Source> sources= new List<Source>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Love.xml");

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                Source source = new Source();
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attST = xnode.Attributes.GetNamedItem("sourcetype");
                    if (attST != null)
                    {
                        source.Sourcetype = attST.Value;
                       // attSTValue = attST.Value;
                       // Response.Write(attSTValue);
                        //Controls.Add(new LiteralControl(attSTValue));
                    }

                    XmlNode attN = xnode.Attributes.GetNamedItem("name");
                    if (attN != null)
                    {
                        source.Name = attN.Value;
                        //attNValue = attN.Value;
                        //Controls.Add(new LiteralControl(attNValue));
                    }

                    XmlNode attP = xnode.Attributes.GetNamedItem("path");
                    if (attP != null)
                        source.Path = attP.Value;
                        //attPValue = attP.Value;
                    //XmlNode attS = xnode.Attributes.GetNamedItem("server");
                    //if (attS != null)
                    //    attSValue = attS.Value;
                    //XmlNode attDB = xnode.Attributes.GetNamedItem("database");
                    //if (attDB != null)
                    //    attDBValue = attDB.Value;
                    //XmlNode attURL = xnode.Attributes.GetNamedItem("url");
                    //if (attURL != null)
                    //    attURLValue = attURL.Value;
                    sources.Add(source);
                }

                foreach (Source s in sources)
                {
                    Response.Write(s.Sourcetype + "\n " + s.Name + "\n " + s.Path);
                }



                //foreach (XmlNode childnode in xnode.ChildNodes)
                //{
                //    if (childnode.Name == "transform")
                //        CNName = childnode.InnerText;
                //    if (childnode.Name == "process")
                //        PName = childnode.InnerText;
                //    if (childnode.Name == "save")
                //        SName = childnode.InnerText;
                //    if (childnode.Name == "report")
                //        RName = childnode.InnerText;
                //}
            }

        }
    }
}