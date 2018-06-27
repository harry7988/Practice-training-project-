# 2018年4-6月实训项目

> 登录系统才会显示用户名，部分字段需要登录后进行操作，登录的用户名：`test`,密码：`123`，数据库使用localdb（VS自带）

更新记录：  

2018年6月28日 ：
1. 将Git链接下发至群，利用Git合并代码
2. 更新README.MD文档

2018年6月27日 ：
1. 根据需求文档，添加对已有条目的批准方法（`Approve`）
2. 更新基础模板的链接
3. 将登录后页面直接跳转至`ManageEHSSDataController`的`index`方法
4. 添加`ManageEHSSDataController`的权限

2018年6月26日 ：
1. 依据需求文档，添加对条目的编辑操，新建`Create`方法。
2. 为了满足Create方法的正确显示，添加了`Create`对应的视图。
3. 为了传输`Create.cshtml`视图中的必要数据，新建`EHSSDataManageListViewModel`作为数据传输的封装对象。

2018年6月25日 ：
1. 完成`ManageEHSSDataController`的`Create`新增条目操作
2. 完成高级过滤搜索
3. 修正`ManageEHSSData`下的`Creat.cshtml`中的连接错误
4. 修正布局页基础布局的用户显示效果，动态控制注销按钮的显示与隐藏
5. 为`UserController`添加注销方法

2018年4月26日 ：
1. 添加ViewModel文件夹
2. 创建ManageEHSSData的index方法
3. 添加布局`_EHSSbase.cshtml`，创建模板引用即可。

2018年4月23日：
1. 添加DBcontext
2. 添加页面的CShtml内容
3. 将CSS、image文件夹移动至content文件夹
4. 修改CSHTML中的连接，修正为连接到`~/Content/images/bottom.gif`、`~/Content/CSS/bottom.gif`


