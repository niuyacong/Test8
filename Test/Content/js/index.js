

//$("#level").click(function(){
//$("#levelChildren").toggle();
//});


$(".panel-heading").click(function(){
	$(this).siblings('.panel-heading').removeClass('panel-heading-b'); // 删除其他兄弟元素的样式 
	$(this).toggleClass('panel-heading-b');// 添加当前元素的样式

});

$(".list-group-item").click(function(){
	$(this).parent().parent().parent().find('.list-group-item').removeClass('list-group-item-b');  // 删除其他兄弟元素的样式
	$(this).toggleClass('list-group-item-b');                            // 添加当前元素的样式
});


//$(".left-nav").click(function(){
//		$(this).toggleClass('left-nav-collect').find(".panel-heading").find("img").toggleClass('panel-heading-collect-img');
//		$(this).children('#collapseListGroup1').children('ul').find('li').toggleClass('list-group-item-collect').find('img').toggleClass('list-group-item-collect-img');
//});

$(".shrink-img").click(function(){
	$(this).toggleClass("shrink-img1");
	$(this).parent('.panel-heading1').parent('div').parent('div').toggleClass('left-nav-collect');
	$(this).parent('.panel-heading1').siblings('.panel-heading').toggleClass('panel-heading-collect').find("img").toggleClass('panel-heading-collect-img');
	$(this).parent('.panel-heading1').parent().find('li').toggleClass('list-group-item-collect').find('img').toggleClass('list-group-item-collect-img');
//系统管理
	$(this).parent('.panel-heading1').parent().find('li').toggleClass('levell');
	$(this).parent('.panel-heading1').parent().find('li').toggleClass('role');
//	统计管理
	$(this).parent('.panel-heading1').parent().find('li').toggleClass('Statistics');
//工时管理
$(this).parent('.panel-heading1').parent().find('li').toggleClass('working');
//项目管理project
$(this).parent('.panel-heading1').parent().find('li').toggleClass('project');
//总列表
$('.panel-heading').toggleClass('whole');
	$(this).parent('.panel-heading1').parent().find('li').toggleClass('role-left');
});

$("li.levell").on('mouseover',function (){
	 if($(this).hasClass('levell')){
	 	 $(".levelChildren").show();
	 }
})
$("li.levell").on('mouseout',function (){
  $(".levelChildren").hide();  
});  

//系统管理
$("li.role").on('mouseover',function (){
		var el = $(this).index();
	 if(!$(this).hasClass('role')){
	 	 $(".roleChildren").eq(el).show();
	 }
})
$("li.role").on('mouseout',function (){
  $(".roleChildren").hide();  
}); 
//	统计管理
$("li.Statistics").on('mouseover',function (){
		var el = $(this).index();
	 if(!$(this).hasClass('Statistics')){
	 	 $(".StatisticsChildren").eq(el).show();
	 }
})
$("li.Statistics").on('mouseout',function (){
  $(".StatisticsChildren").hide();  
});  
//	工时管理
$("li.working").on('mouseover',function (){
		var el = $(this).index();
	 if(!$(this).hasClass('working')){
	 	 $(".workingChildren").eq(el).show();
	 }
})
$("li.working").on('mouseout',function (){
  $(".workingChildren").hide();  
});  
//	项目管理
$("li.project").on('mouseover',function (){
		var el = $(this).index();
	 if(!$(this).hasClass('project')){
	 	 $(".projectChildren").eq(el).show();
	 }
})
$("li.project").on('mouseout',function (){
  $(".projectChildren").hide();  
});  
//总列表
$('.whole').on('mouseover',function (){
	 if(!$(this).hasClass('whole')){
	 	$(this).children(".wholeChildren").show();
	 }
})
$('.whole').on('mouseout',function (){
  $(".wholeChildren").hide();  
}); 


//登录框用户名 和 删除 
$('.lgoin-box>ul>li>input.name').click(function(){
	$(this).parent().css('border-color','#6cb4f5');
	$(this).prev().children().attr('src','img/login_user_name_hight_lighted.png');
	$(".delete").mouseover(function(){
		$(this).children("img").attr("src","img/delete_hight_lighted.png");
	}).mouseout(function(){
		$(this).children("img").attr("src","img/delete1.png");
	});
});

$(".delete").click(function(){
	$(this).prev("input").val("");
});

//登录框密码
$('.lgoin-box>ul>li>input.pass').click(function(){
	$(this).parent().css('border-color','#6cb4f5');
	$(this).prev().children().attr('src','img/the_login_password_hight_lighted.png');

})

$(".Transform").click(function(){

	if ($(this).find("img").attr("src")=="img/close_eyes.png") {
      $(this).find("img").attr("src","img/open_eyes.png");
      $(this).prev("input").attr("type","text");
  } else {
      $(this).children("img").attr("src","img/close_eyes.png");
      $(this).prev("input").attr("type","password");
  }
});

//登录框验证码
$('.Code>input').click(function(){
	$(this).css('border-color','#6cb4f5');
	$(this).next().css('border-color','#6cb4f5');
})


//组织机构 旋转
$(".company").click(function(){
	$(this).children("div").children("span").toggleClass("rotate");
	$(this).removeClass("panel-heading-b");
});

$(".panel-body").click(function(){
	$(this).children("div").children("span").toggleClass("rotate");
});

$(".Market-body").click(function(){
	$(this).children("div").children("span").toggleClass("rotate");
});


//给级别模块添加class
$("body").on("click",".public",function(){
if($(this).hasClass('Company-title')){
	$(this).parent('.public-ti').find(".public").removeClass('public-element'); 
	$(this).addClass('public-element');
}else if($(this).hasClass('panel-body')){
	$(this).parent().parent('.public-ti').find(".public").removeClass('public-element'); 
	$(this).addClass('public-element');
}else if($(this).hasClass('Market-body')){
	$(this).parent().parent().parent('.public-ti').find(".public").removeClass('public-element'); 
	$(this).addClass('public-element');
}else{
	$(this).parent().parent().parent().parent('.public-ti').find(".public").removeClass('public-element'); 
	$(this).addClass('public-element');
}
});

//添加级别模块
var n=0;
$(".AddElement").click(function () {
    alert(1);
	n++;
	var txt1="<div class='panel-body public' data-toggle='collapse' data-target='#"+n+"'>"
	txt1+="<img src='img/fff.jpg' class='fff' />"
	txt1+="<img src='img/grey_squares.png' class='rhomb-img' />"
	txt1+="<input type='text' value='部门' class='Name-input' />"
	txt1+="<div><a href='##' class='modify-input'>修改</a><a href='##' class='delete-input'>删除</a><span></span></div></div>"
	txt1+="<div id='"+n+"' class='panel-collapse collapse' style='border: 1px solid #e0e1e1;border-top: none;margin-left: 20px;border-right: none;border-left: 1px solid #999999;width: 100%;'><div/>"
	
	var txt2="<div class='Market-body public' data-toggle='collapse' data-target='#"+n+"'>";
	txt2+="<img src='img/fff.jpg' class='fff' />"
	txt2+="<img src='img/grey_squares.png' class='rhomb-img' />"
	txt2+="<input type='text' value='大区' class='Name-input'/>"
	txt2+="<div><a href='##' class='modify-input'>修改</a><a href='##' class='delete-input'>删除</a><span></span></div></div>"
	txt2+="<div id='"+n+"' class='panel-collapse collapse' style='border: 1px solid #e0e1e1;border-top: none;margin-left: 20px;border-right: none;border-left: 1px solid #999999;width: 100%;'><div/>"
		
	var txt3="<div class='Region-body public' >";
	txt3+="<img src='img/fff.jpg' class='fff' />"
	txt3+="<img src='img/grey_squares.png' class='rhomb-img' />"
	txt3+="<input type='text' value='江西江西' class='Name-input'/>"
	txt3+="<div><a href='##' class='modify-input'>修改</a><a href='##' class='delete-input'>删除</a><span></span></div></div>"
	
	
	if($(this).parent().parent().parent('.container-fluid').find(".public-element").hasClass('Company-title')){
		$(this).parent().parent().parent('.container-fluid').find(".public-element").next("#collapseOne").append(txt1);
				
	}else if($(this).parent().parent().parent('.container-fluid').find(".public-element").hasClass('panel-body')){
		$(this).parent().parent().parent('.container-fluid').find(".public-element").next("div").append(txt2);
			
	}else if($(this).parent().parent().parent('.container-fluid').find(".public-element").hasClass('Market-body')){
		$(this).parent().parent().parent('.container-fluid').find(".public-element").next("div").append(txt3);
	}else{
		
	}
});
	
//添加级别模块后鼠标离开焦点后
$('body').on('blur','.Name-input',function(){
	if($(this).next().children(".modify-input").html()=="修改"){
		$(this).css("background-color","#fff");
		$(this).css("border","none");
		$(this).attr("readOnly","true");
	}
})

//修改添加级别模块的名称
$('body').on('click','.modify-input',function(){
	if($(this).html()=="修改"){
		$(this).parent().prev(".Name-input").removeAttr("readOnly","true");
		$(this).parent().prev(".Name-input").css("background-color","#f6f8f9");
		$(this).parent().prev(".Name-input").css("border","1px solid #e0e1e1");
		$(this).html("保存");
	}else{
		$(this).html("修改");
		$(this).parent().prev(".Name-input").attr("readOnly","true");
		$(this).parent().prev(".Name-input").css("background-color","#fff");
		$(this).parent().prev(".Name-input").css("border","none");
	}
})

//删除当前级别模块
$('body').on('click','.delete-input',function(){
	$(this).parent().parent().remove();
})
