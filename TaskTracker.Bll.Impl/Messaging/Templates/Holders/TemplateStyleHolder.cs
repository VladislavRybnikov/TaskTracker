using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Bll.Impl.Messaging.Templates
{
    public static class TemplateStyleHolder
    {
 
        public static string DefaultStyle =>
            @"body
        {
            display: flex;
            flex-direction: column;
            align-items: center;
            color: black;
        }

        .message-header
        {
            display: flex;

            box-shadow:black 6px 5px;
            width: 80%;
            background-color: #03798a;
            height: 150px;
        }
        .message-content
        {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 50px;
            margin-bottom: 50px;

            width: 60%;
        }

        .message-footer
        {
            justify-content: flex-start;
            box-shadow:black 6px 5px;
            color:#e9e9ec;
            width: 80%;
            background-color: #03798a;
            height: 120px;
        }

        .title
        {
            margin: 40px;
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            color:#e9e9ec;
            font-size: 40px;
        }

        .text
        {
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            margin-left: 20px;
        }

        .base-button-container
        {
            width: 250px;
            height: 100px;
        }
        .base-button
        {
            display: inline-block;
            margin-top: 30px;
            margin-left: 30px;
            box-shadow: 3px 3px;
	        transition: 0.4s;
	        text-decoration: none;
            background-color: #80bfdb;
            padding: 10px 32px;
            text-align: center;
            font-size: 16px;
            cursor: pointer;
            border-radius: 30px;
            color: #9f2112;
        }
        
        .base-button:hover
        {
            box-shadow: 0px 0px;
            margin-top: 33px;
            margin-left: 33px;
	        text-decoration: none;
	        color: white;
        }";
    }
}
