using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using LeFe.Model;

namespace epubFactory
{
	public static class DefaultModel
	{
		private static string BasePath = "/生成模板/";
		public static string Read(string Type)
		{
			string modelPath = Application.StartupPath + BasePath + SofeSetting.Get("生成模板") + "/Text/" + Type + ".xhtml";
			if (File.Exists(modelPath))
			{
				string modelText = "";
				using (StreamReader sr = new StreamReader(modelPath))
				{
					modelText = sr.ReadToEnd();
				}
				return modelText;
			}
			else
			{
				//模板不存在时读取程序中默认模板
				return DefaultModel.ReadDefault(Type);
			}
		}
		/// <summary>
		/// 检查模板文件是否完整
		/// </summary>
		/// <returns></returns>
		public static bool CheckModel()
		{
			return CheckModel(SofeSetting.Get("生成模板"));
		}
		/// <summary>
		/// 检查模板文件是否完整
		/// </summary>
		/// <returns></returns>
		public static bool CheckModel(string modelname)
		{
			bool flag = true;
			string[] Types = { "封面", "标题", "彩页", "彩页文字特效", "简介", "制作信息", "LOGO", "目录插画", "目录", "章节正文", "封底" };
			foreach (var type in Types)
			{
				string modelPath = Application.StartupPath + BasePath + SofeSetting.Get("生成模板") + "/Text/" + type + ".xhtml";
				if (!File.Exists(modelPath))
				{
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// 查找存在的模板
		/// </summary>
		/// <returns></returns>
		public static List<string> SearchModel()
		{
			string modelPath = Application.StartupPath + BasePath;
			List<string> models = new List<string>();
			DirectoryInfo theFolder = new DirectoryInfo(modelPath);
			DirectoryInfo[] subFolders = theFolder.GetDirectories();
			if (subFolders.Length > 0)
			{
				foreach (DirectoryInfo subFolder in subFolders)
				{
					if (Directory.Exists(subFolder.FullName))
					{
						models.Add(subFolder.Name);
					}
				}
			}

			return models;

		}
		public static string SelectModel()
		{
			string modelPath = Application.StartupPath + BasePath;
			if (!Directory.Exists(modelPath))
			{
				MessageBox.Show("没有模板文件可以选择！");
				return "";
			}
			DirectoryInfo theFolder = new DirectoryInfo(modelPath);
			DirectoryInfo[] subFolders = theFolder.GetDirectories();
			if (subFolders.Length > 0)
			{
				FolderBrowserDialog fbd = new FolderBrowserDialog();
				fbd.SelectedPath = modelPath;
				//fbd.RootFolder = new Environment.SpecialFolder();
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					//记录选中的目录  
					return fbd.SelectedPath.Substring(fbd.SelectedPath.LastIndexOf("\\")+2);
				}
			}
			MessageBox.Show("没有模板文件可以选择！");
			return "";
			
		}
		/// <summary>
		/// 获取内置模板
		/// </summary>
		/// <param name="Type"></param>
		/// <returns></returns>
		public static string ReadDefault(string Type)
		{
			if (Type == "封面")
			{
				#region 封面
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN"" ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->
<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />
  <title>封面</title>
</head>
<body>
  <!--请勿对此html做出任何改动-->
  <div class=""cover""><img alt=""cover"" class=""coverborder"" src=""../Images/cover.jpg"" /></div>
</body>
</html>
";
				#endregion
			}
			if (Type == "标题")
			{
				#region 标题
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN""
  ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:xml=""http://www.w3.org/XML/1998/namespace"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->
<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />
  <title>标题</title>
</head>
<body>
  <!--以下仅字体颜色、样式可以自由变换，不允许改变大小；资料填写请参照注释-->
  <div>
	<table class=""bc title-width"">
	  <tr>
		<td class=""bb"" colspan=""2"">　</td>
		<td class=""blb"">　</td>
	  </tr>
	  <tr>
		<td colspan=""2"">　</td>
		<td class=""bl"" rowspan=""2"">　</td>
	  </tr>
	  <tr>
		<td class=""br"" rowspan=""2"">　</td>
		<td class=""center title-width"">
		  <h1>[%书名%]</h1><!--书名-->
		  <!--<h2 class=""em11"">副标题</h2>--><!--副标题-->
		  <!--<h2 class=""em13"">卷数</h2>--><!--卷数-->
		  <p><br /></p>
		  <h3>作者／[%作者名字%]</h3><!--作者-->
		  <h3>插画／[%插画名字%]</h3><!--插画师-->
		</td>
	  </tr>
	  <tr>
		<td colspan=""2"">　</td>
	  </tr>
	  <tr>
		<td class=""brt"">　</td>
		<td class=""bt"" colspan=""2"">　</td>
	  </tr>
	</table>
  </div>
</body>
</html>
";
				#endregion
			}
			if (Type == "彩页")
			{
				#region 彩页
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN"" ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->
<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />
  <title>彩页</title><!--章节名-->
</head>
<body>
  <div class=""duokan-image-single illus""><img alt=""[%彩插%]"" src=""../Images/[%彩插%]"" /></div>
</body>
</html>
";
				#endregion
			}
			if (Type == "彩页文字特效")
			{
				#region 彩页文字特效
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN""
  ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">

<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->

<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />

  <title>彩页</title><!--章节名-->
</head>

<body>
  <div>
	<!--此html用于填写彩页上的文字-->

	<p>请先转为书籍视图界面</p>

	<p>全选后将文本粘贴在此处</p>
  </div>
</body>
</html>
";
				#endregion
			}
			if (Type == "简介")
			{
				#region 简介
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN""
  ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">

<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->

<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />

  <title>简介</title><!--章节名-->
</head>

<body>
  <div>
	<h4>简介</h4>
	<!--<p>请先转为书籍视图界面 全选后将文本粘贴在此处</p>-->
[%简介内容%]
  </div>
</body>
</html>
";
				#endregion
			}
			if (Type.ToUpper() == "制作信息")
			{
				#region 制作信息
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN""
  ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">

<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->

<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />

  <title>制作信息</title>
</head>

<body>
  <div>
	<p class=""meg"">制作信息</p>
	<p class=""message"">——————————</p><!--以下填写制作信息-->
[%制作信息内容%]
	<p class=""message"">——————————</p>
  </div>
</body>
</html>
";
				#endregion
			}
			if (Type.ToUpper() == "LOGO")
			{
				#region LOGO
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN"" ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->
<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />
  <title>制作者与Logo</title>
</head>
<body>
  <div>
	<div class=""logo-img""><img alt="""" class=""logo-width"" src=""../Images/logo.jpg"" /></div>
	<div class=""maker"">
	  <p class=""logo-font"">※制作者※</p>
	  <p class=""logo-font em13"">[%制作者%]</p><!--填写制作者id-->
	</div>
  </div>
</body>
</html>
";
				#endregion
			}
			if (Type.ToUpper() == "目录插画")
			{
				#region 目录插画
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN""
  ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">

<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->

<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />

  <title>目录</title><!--章节名-->
</head>

<body>
  <div class=""duokan-image-single illus""><img alt=""contents"" src=""../Images/contents.jpg"" /></div>
</body>
</html>
";
				#endregion
			}
			if (Type.ToUpper() == "目录")
			{
				#region 目录
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN""
  ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">

<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->

<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />

  <title>目录</title>
</head>

<body>
  <div>
	<p class=""contents em12"">CONTENTS</p><!--请根据链接目标修改代码-->

[%目录内容%]

  </div>
</body>
</html>
";
				#endregion
			}
			if (Type.ToUpper() == "章节正文")
			{
				#region 章节正文
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN""
  ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">

<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:epub=""http://www.idpf.org/2007/ops"" xml:lang=""zh-CN"" xmlns:xml=""http://www.w3.org/XML/1998/namespace"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->

<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />

  <title>[%章节名%]</title><!--章节名-->
</head>

<body>
  <div>
	<!--<h4>[%章节名%]</h4>-->
[%章节内容%]
  </div>
</body>
</html>
";
				#endregion
			}
			if (Type.ToUpper() == "封底")
			{
				#region 封底
				return
					@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN""
  ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">

<html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""zh-CN"" xmlns:epub=""http://www.idpf.org/2007/ops"">
<!--「xml:lang=""zh-CN""」这一段代码必须保留-->

<head>
  <link href=""../Styles/style.css"" rel=""stylesheet"" type=""text/css"" />

  <title>封底</title>
</head>

<body>
  <!--请勿对此html做出任何改动-->

  <div class=""cover""><img alt=""backcover"" class=""coverborder"" src=""../Images/backcover.jpg"" /></div>
</body>
</html>
";
				#endregion
			}
			return "";
		}
		public static string DefaultCSS()
		{
			return
			#region css
 @"/*预设文本样式*/

body{
	padding: 0%;
	margin-top: 0%;
	margin-bottom: 0%;
	margin-left: 1%;
	margin-right: 1%;
	line-height: 130%;
	text-align: justify;
}
h1{
	line-height: 120%;
	text-align: center;
	font-weight: bold;
	font-size: 1.65em;
	margin-top: 0.1em;
	margin-bottom: 0.4em;
}
h2{
	line-height: 120%;
	text-align: center;
	font-weight: bold;
	font-size: 1.25em;
	margin-top: 0.3em;
	margin-bottom: 0.5em;
}
h3{
	font-size: 0.95em;
	line-height: 120%;
	text-align: center;
	text-indent: 0em;
	font-weight: bold;
	margin-top: 0.2em;
	margin-bottom: 0.2em;
}
h4{
	font-size: 1.5em;
	text-align: center;
	line-height: 1.2em;
	text-indent: 0em;
	font-weight: bold;
	margin-top: 1em;
	margin-bottom: 1.5em;
}
div{
	margin: 0px;
	padding: 0px;
	text-align: justify;
}
p{
	text-indent: 2em;
	display: block;
	line-height: 1.3em;
	margin-top: 0.4em;
	margin-bottom: 0.4em;
}




/*图片相关*/

.illus{
	text-indent: 0em;
	text-align: center;
}
.cover{
	margin: 0em;
	padding: 0em;
	text-indent: 0em;
	text-align: center;
}
.coverborder{
	border-style: none solid none solid;
	border-color: #000000;
	border-width: 1px;
}




/*logo相关*/

.logo-img{
	text-align: center;
	margin-top: 30%;
	margin-bottom: 1em;
}
.maker{
	font-weight: bold;
	text-indent: 0em;
	text-align: center;
}
.logo-width{
	width:100%;
}
.logo-font{
	margin-top: -0.3em;
	text-indent: 0em;
}
.cut-line{
	text-indent: 0em;
	line-height: 0%;
	margin-top: 0.3em;
	margin-bottom: 0.3em;
}




/*预设格式相关样式*/

.right{
	text-indent: 0em;
	text-align: right;
}
.left{
	text-indent: 0em;
	text-align: left;
}
.center{
	text-indent: 0em;
	text-align: center;
}
.zin{
	text-indent: 0em;
}
.bold{
	font-weight: bold;
}
.stress{
	font-weight: bold;
	font-size: 1.1em;
	margin-top: 0.3em;
	margin-bottom: 0.3em;
}
.author{
	font-size: 1.2em;
	text-align: right;
	font-weight: bold;
	font-style: italic;
	margin-right: 1em;
}
.dash-break{
	word-break: break-all;
	word-wrap: break-word;
}
.no-d{
	text-decoration: none;
}
.bc{
	border-collapse: collapse;
}
.dash-break{
	word-break: break-all;
	word-wrap: break-word;
}
.message{
	text-indent: 0em;
	line-height: 1.2em;
	margin-top: 0.2em;
	margin-bottom: 0.2em;
}
.meg{
	font-size: 1.3em;
	text-indent: 0em;
	font-weight: bold;
	margin-top: 0.5em;
	margin-bottom: 0.5em;
}




/*文字大小*/

.em05{
	font-size: 0.5em;
}
.em06{
	font-size: 0.6em;
}
.em07{
	font-size: 0.7em;
}
.em08{
	font-size: 0.8em;
}
.em09{
	font-size: 0.9em;
}
.em11{
	font-size: 1.1em;
}
.em12{
	font-size: 1.2em;
}
.em13{
	font-size: 1.3em;
}
.em14{
	font-size: 1.4em;
}
.em15{
	font-size: 1.5em;
}
.em16{
	font-size: 1.6em;
}
.em17{
	font-size: 1.7em;
}
.em18{
	font-size: 1.8em;
}
.em18{
	font-size: 1.9em;
}
.em20{
	font-size: 2em;
}




/*预设目录样式*/

.contents{
	text-indent: 0em;
	text-align: center;
	border-bottom: 0.1em dotted #000000;
	padding: 0.5em 0 0.4em 0;
	margin-bottom: 0.7em;
	font-weight: bold;
}
.mulu{
	text-indent: 0em;
	text-align: center;
}




/*预设title样式*/

.title-width{
	width: 100%;
}
.bb{
	border-bottom: 3px solid #000000;
}
.blb{
	border-left: 3px solid #000000;
	border-bottom: 3px solid #000000;
}
.bl{
	border-left: 3px solid #000000;
}
.br{
	border-right: 3px solid #000000;
}
.brt{
	border-right: 3px solid #000000;
	border-top: 3px solid #000000;
}
.bt{
	border-top: 3px solid #000000;
}




/*图片允许放大*/

/*
html代码：

<div class=""duokan-image-single illus""><img alt=""图片名"" src=""../Images/图片名.jpg"" /></div>
*/




/*预设注释样式*/

.footnote {
	height: 1.2em!important;
	width: auto;
	border:0;
}
.duokan-footnote {
	height: 1.2em!important;
	width: auto;
	border: 0;
}
.duokan-footnote-item {
	text-indent: 0em;
	font-family: ""DK-SONGTI"";
	text-shadow: 0em 0em 0.1em #000000;
	font-size: 0.9em;
	text-align: left;
}
sup {
	font-size: 0.75em;
	line-height: 1.2;
	vertical-align: super!important;
}
.postil{
	font-size: 70%;
	text-indent: 0em;
	line-height: 120%;
	color: #333;
	border-style: dotted;
	border-color: #666;	
	border-width: 1px;
	width:100%;
	margin-left:2.85em
}
/*
html代码：

<a class=""duokan-footnote no-d"" epub:type=""noteref"" href=""#n1"" id=""A_1""><sup><img alt=""note"" class=""footnote"" src=""../Images/note.png"" /></sup></a>

	<aside epub:type=""footnote"" id=""n1"">
	  <ol class=""duokan-footnote-content"">
		<li class=""duokan-footnote-item"" id=""n1"" value=""1"">注：此处填写注释内容</li>
	  </ol>
	</aside>

代码说明：
1. 请将「href=""n1""」「id=""n1""」「value=""1""」这三段代码中的数字改为该注释的顺序
例：第3个注释的该段代码为「href=""n3""」「id=""n3""」「value=""3""」
2. 「注：」根据不同情况可以改为其它文字，例如译者名
*/




/*以下填写自定义css样式*/
";
			#endregion
		}
		/// <summary>
		/// 复制模板的CSS，返回成功或失败
		/// </summary>
		/// <param name="toPath"></param>
		/// <param name="newBook"></param>
		/// <returns></returns>
		public static bool CopyCSS(string toPath, Book newBook)
		{
			string cssModelPathFolder = Application.StartupPath + BasePath + SofeSetting.Get("生成模板") + "/Styles";
			if (!Directory.Exists(cssModelPathFolder))
			{
				return false;
			}
			if (!Directory.Exists(toPath))
			{
				Directory.CreateDirectory(toPath);
			}
			List<BookImage> nlbi = new List<BookImage>();
			DirectoryInfo theFolder = new DirectoryInfo(cssModelPathFolder);
			FileInfo[] fi = theFolder.GetFiles("*.*");
			int cssFileCount = 0;
			foreach (FileInfo tmpfi in fi)
			{
				string extension = tmpfi.Extension.ToLower();
				if (extension == ".css")
				{
					cssFileCount++;
					string imgpath = tmpfi.FullName;
					string filename = imgpath.Substring(imgpath.LastIndexOf(@"\") + 1);
					string ext = filename.Substring(filename.LastIndexOf('.'));
					filename = filename.Substring(0, filename.LastIndexOf('.'));

					BookFileInfo fileInfo = new BookFileInfo();
					fileInfo.chName = "层叠样式表";
					fileInfo.fileAllName = "Styles/" + filename + ext;
					fileInfo.fileName = filename + ext; //带后缀的
					fileInfo.clearName = filename; //不带后缀的
					fileInfo.inContents = false;
					fileInfo.media_type = "text/css";
					newBook.filelist.Add(fileInfo);
				}
			}

			if (cssFileCount==0)
			{
				return false;
			}
			DefaultModel.CopyFolder(cssModelPathFolder, toPath);
			return true;
		}
		/// <summary>
		/// 复制模板文件
		/// </summary>
		public static void CopyImages(string toPath,Book newBook)
		{
			//复制图片
			string imageModelPath = Application.StartupPath + BasePath + SofeSetting.Get("生成模板") + "/Images";
			if (!Directory.Exists(imageModelPath))
			{
				return;
			}
			if (!Directory.Exists(toPath))
			{
				Directory.CreateDirectory(toPath);
			}
			List<BookImage> lbis = ImgManger.SearchFolder(imageModelPath);
			foreach (var bookImage in lbis)
			{
				ImgManger.AddImgFileList("其他", bookImage, newBook);
			}
			DefaultModel.CopyFolder(imageModelPath, toPath);
		}
		public static void CopyMisc(string toPath, Book newBook)
		{
			//复制内容
			string imageModelPath = Application.StartupPath + BasePath + SofeSetting.Get("生成模板") + "/Misc";
			if (!Directory.Exists(imageModelPath))
			{
				return;
			}
			if (!Directory.Exists(toPath))
			{
				Directory.CreateDirectory(toPath);
			}
			List<BookImage> lbis = ImgManger._searchImg(imageModelPath,"|.js|.txt|");
			foreach (var file in lbis)
			{
				var fileInfo = new BookFileInfo
				{
					chName = "文本",
					fileAllName = "Misc/" + file.storeName + file.ext,
					fileName = file.storeName + file.ext,
					clearName = file.storeName + file.ext,
					inContents = false,
					media_type = "text/plain"
				};
				newBook.filelist.Add(fileInfo);
			}
			DefaultModel.CopyFolder(imageModelPath, toPath);
		}
		private static void CopyFolder(string from, string to)
		{
			if (!Directory.Exists(to))
				Directory.CreateDirectory(to);
			// 子文件夹
			foreach (string sub in Directory.GetDirectories(from))
				CopyFolder(sub + "\\", to + Path.GetFileName(sub) + "\\");
			// 文件
			foreach (string file in Directory.GetFiles(from))
				File.Copy(file, to + Path.GetFileName(file), true);
		}
		/*****开始模板设定模块*****/
		private const string XmlFile = "/setting.xml";
		private static SerializableDictionary<string, string> settings = new SerializableDictionary<string, string>();
		public static void Init()
		{
			try
			{
				using (FileStream fileStream = new FileStream(Application.StartupPath + BasePath + SofeSetting.Get("生成模板") + XmlFile, FileMode.OpenOrCreate))
				{
					XmlSerializer xmlFormatter = new XmlSerializer(typeof(SerializableDictionary<string, string>));
					settings = (SerializableDictionary<string, string>)xmlFormatter.Deserialize(fileStream);
				}
			}
			catch (Exception e)
			{
			}
		}
		public static string GetSetting(string key)
		{
			if (settings.Count == 0)
			{
				Init();
			}
			if (!settings.ContainsKey(key))
			{
				string tmp = GetDefault(key);
				if (tmp!="")
				{
					SetSetting(key, tmp);
				}
				return tmp;
			}
			else
			{
				return settings[key];
			}
		}
		/// <summary>
		/// 读取默认设置
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetDefault(string key)
		{
			switch (key)
			{
				case "插图后带字":
					return @"<div class='duokan-image-single illus'><img alt='[%图片名%]' src='../Images/[%图片名%]' /></div>
<p><br/></p>";
				case "插图后不带字":
					return @"<div class='duokan-image-single illus'><img alt='[%图片名%]' src='../Images/[%图片名%]' /></div>";
				case "上注":
					return @"<ruby>[%注释词%]<rt>[%上注%]</rt></ruby>";
				case "下注":
					return @"<p class='postil'>[%下注%]</p>";
				case "尾注开关":
					return @"0";//1为开，0为关。默认关闭尾注
				case "尾注1":
					return @"<a class='duokan-footnote no-d' epub:type='noteref' href='#n[%编号%]' id='A_[%编号%]'><sup><img alt='note' class='footnote' src='../Images/note.png' /></sup></a>";
				case "尾注2":
					return @"<aside epub:type='footnote' id='n[%编号%]'>
<ol class='duokan-footnote-content'>
<li class='duokan-footnote-item' id='n[%编号%]' value='[%编号%]'>[%尾注%]</li>
</ol>
</aside>";
				case "制作信息行":
					return @"<p class='message'>[%该行内容%]</p>";
				case "简介行":
					return @"<p>[%该行内容%]</p>";
				case "目录行":
					return @"<p class='mulu'><a class='no-d' href='../Text/[%章节文件%]'>[%章节名%]</a></p>";
				case "正文行":
					return @"<p>[%该行内容%]</p>";
				case "正文标题":
					return @"<h4>[%标题%]</h4>";
				default:
					return "";
			}
		}
		///<summary> 
		///更新连接字符串 
		///</summary> 
		public static void SetSetting(string key, string value)
		{
			if (settings.ContainsKey(key))
			{
				settings.Remove(key);
			}
			settings.Add(key, value);
			using (FileStream fileStream = new FileStream(Application.StartupPath + BasePath + SofeSetting.Get("生成模板") + XmlFile, FileMode.OpenOrCreate))
			{
				XmlSerializer xmlFormatter = new XmlSerializer(typeof(SerializableDictionary<string, string>));
				xmlFormatter.Serialize(fileStream, settings);
			}
		}
		///<summary> 
		///清空已有内容 
		///</summary> 
		public static void Destroy()
		{
			settings.Clear();
		}
	}
}
