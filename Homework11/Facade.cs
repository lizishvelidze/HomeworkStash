using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{
    class Facade
    {
        SubsystemHTML subsystemHTML = new SubsystemHTML();
        SubsystemPDF subsystemPDF = new SubsystemPDF();

        public void OperationHTML()
        {
            subsystemHTML.OperationHTML();
        }

        public void OperationPDF()
        {
            subsystemPDF.OperationPDF();
        }
    }

    class SubsystemHTML
    {
        public void OperationHTML()
        {
            Console.WriteLine(@"
                <header> My Header </header> 
                <body>
                Video provides a powerful way to help you prove your point. When you click Online Video, 
                you can paste in the embed code for the video you want to add.
                </body>
                <footer> My Footer </footer>");
        }
    }

    class SubsystemPDF
    {
        public void OperationPDF()
        {
            Console.WriteLine(@"
                Header: I'm using Facade Pattern
                Body: Video provides a powerful way to help you prove your point. When you click Online Video,
                you can paste in the embed code for the video you want to add.
                You can also type a keyword to search online for the video that best fits your document.
                To make your document look professionally produced, Word provides
                Footer: Page 1");
        }
    }
}

